using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ScePSX;

public class PSXCore : ICoreHandler
{
	public struct AddrItem
	{
		public uint Address;

		public uint Value;

		public byte Width;
	}

	public struct CheatCode
	{
		public string Name;

		public List<AddrItem> Item;

		public bool Active;
	}

	private const int PSX_MHZ = 33868800;

	private const int CYCLES_PER_FRAME = 564480;

	public int SYNC_CYCLES_BUS = 110;

	public int SYNC_CYCLES_FIX = 1;

	public int SYNC_CPU_TICK = 42;

	public int SYNC_LOOPS;

	public double SYNC_CYCLES_IDLE = 60.0;

	private Task MainTask;

	public BUS PsxBus;

	public string DiskID = "";

	public bool Pauseing;

	public bool Pauseed;

	public bool Running;

	public bool Boost;

	private IAudioHandler _Audio;

	private IRenderHandler _IRender;

	public List<CheatCode> cheatCodes = new List<CheatCode>();

	public PSXCore(IRenderHandler render, IAudioHandler audio, string RomFile, string BiosFile, string diskid = "")
	{
		_Audio = audio;
		_IRender = render;
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine("ScePSX Booting...");
		Console.ResetColor();
		PsxBus = new BUS(this, BiosFile, RomFile, diskid);
		DiskID = PsxBus.DiskID;
		if (DiskID == "")
		{
			Console.WriteLine("ScePSX Boot Fail...");
			Console.ResetColor();
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("ScePSX Running...");
			Console.ResetColor();
		}
	}

	public void Start()
	{
		if (!(DiskID == "") && MainTask == null && !Running && PsxBus != null)
		{
			Running = true;
			Pauseing = false;
			MainTask = Task.Factory.StartNew(PSX_EXECUTE, TaskCreationOptions.LongRunning);
		}
	}

	public void Pause()
	{
		Pauseing = !Pauseing;
	}

	public void Stop()
	{
		if (Running)
		{
			Running = false;
			Pauseing = false;
			MainTask.Wait();
		}
	}

	public void LoadCheats()
	{
		cheatCodes.Clear();
		string text = "./Cheats/" + DiskID + ".txt";
		if (!File.Exists(text))
		{
			return;
		}
		cheatCodes = ParseTextToCheatCodeList(text);
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine($"[CHEAT] {cheatCodes.Count} Codes Loaded");
		foreach (CheatCode cheatCode in cheatCodes)
		{
			if (cheatCode.Active)
			{
				Console.WriteLine("    " + cheatCode.Name + " [Active]");
			}
			else
			{
				Console.WriteLine("    " + cheatCode.Name + " [Non Active]");
			}
		}
		Console.ResetColor();
	}

	public static List<CheatCode> ParseTextToCheatCodeList(string fn, bool isfile = true)
	{
		string text = ((!isfile) ? fn : File.ReadAllText(fn));
		List<CheatCode> list = new List<CheatCode>();
		string text2 = null;
		bool active = false;
		List<AddrItem> list2 = null;
		string[] array = text.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text3 in array)
		{
			if (text3.StartsWith("[") && text3.EndsWith("]"))
			{
				if (text2 != null)
				{
					list.Add(new CheatCode
					{
						Name = text2,
						Item = list2,
						Active = active
					});
				}
				text2 = text3.Substring(1, text3.Length - 2).Trim();
				active = true;
				list2 = new List<AddrItem>();
				continue;
			}
			if (text3.StartsWith("Active", StringComparison.OrdinalIgnoreCase))
			{
				Match match = Regex.Match(text3, "Active\\s*=\\s*(true|false|0|1)", RegexOptions.IgnoreCase);
				if (match.Success)
				{
					active = ((match.Groups[1].Value == "true" || match.Groups[1].Value == "1") ? true : false);
				}
				continue;
			}
			Match match2 = Regex.Match(text3, "^([0-9A-F]{8})\\s+([0-9A-F]{1,8})$", RegexOptions.IgnoreCase);
			if (match2.Success && text2 != null)
			{
				uint address = Convert.ToUInt32(match2.Groups[1].Value, 16);
				uint value = Convert.ToUInt32(match2.Groups[2].Value, 16);
				byte width = (byte)((match2.Groups[2].Value.Length <= 2) ? 1 : ((match2.Groups[2].Value.Length <= 4) ? 2 : 4));
				list2.Add(new AddrItem
				{
					Address = address,
					Value = value,
					Width = width
				});
			}
		}
		if (text2 != null)
		{
			list.Add(new CheatCode
			{
				Name = text2,
				Item = list2,
				Active = active
			});
		}
		return list;
	}

	public void LoadState(string Fix = "")
	{
		if (!Running)
		{
			return;
		}
		string text = "./SaveState/" + DiskID + "_Save" + Fix + ".dat";
		if (File.Exists(text))
		{
			Pauseing = true;
			while (!Pauseed)
			{
				Thread.Sleep(10);
				Pauseing = true;
			}
			PsxBus = StateFromFile<BUS>(text);
			PsxBus.DeSerializable(this);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("State LOADED.");
			Console.ResetColor();
			Pauseing = false;
		}
	}

	public void SaveState(string Fix = "")
	{
		if (Running)
		{
			Pauseing = true;
			while (!Pauseed)
			{
				Thread.Sleep(10);
				Pauseing = true;
			}
			string filePath = "./SaveState/" + DiskID + "_Save" + Fix + ".dat";
			PsxBus.ReadySerializable();
			StateToFile(PsxBus, filePath);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("State SAVEED.");
			Console.ResetColor();
			Pauseing = false;
		}
	}

	private BUS StateFromFile<BUS>(string filePath)
	{
		using FileStream stream = new FileStream(filePath, FileMode.Open);
		using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
		using MemoryStream memoryStream = new MemoryStream();
		gZipStream.CopyTo(memoryStream);
		memoryStream.Position = 0L;
		return (BUS)new BinaryFormatter().Deserialize(memoryStream);
	}

	private void StateToFile<BUS>(BUS obj, string filePath)
	{
		using MemoryStream memoryStream = new MemoryStream();
		new BinaryFormatter().Serialize(memoryStream, obj);
		using FileStream stream = new FileStream(filePath, FileMode.Create);
		using GZipStream destination = new GZipStream(stream, CompressionMode.Compress);
		memoryStream.Position = 0L;
		memoryStream.CopyTo(destination);
	}

	private unsafe void ApplyCheats()
	{
		foreach (CheatCode cheatCode in cheatCodes)
		{
			if (!cheatCode.Active)
			{
				continue;
			}
			foreach (AddrItem item in cheatCode.Item)
			{
				uint mask = PsxBus.GetMask(item.Address);
				switch (item.Width)
				{
				case 1:
					PsxBus.write(mask & 0x1FFFFF, (byte)item.Value, PsxBus.ramPtr);
					break;
				case 2:
					PsxBus.write(mask & 0x1FFFFF, (ushort)item.Value, PsxBus.ramPtr);
					break;
				case 4:
					PsxBus.write(mask & 0x1FFFFF, item.Value, PsxBus.ramPtr);
					break;
				}
			}
		}
	}

	private void CalibrateSyncParams()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		for (int i = 0; i < 1000; i++)
		{
			PsxBus.cpu.tick();
		}
		double num = stopwatch.Elapsed.TotalMilliseconds / 1000.0;
		SYNC_CPU_TICK = (int)(0.1 / num);
		SYNC_LOOPS = 564480 / SYNC_CYCLES_BUS + SYNC_CYCLES_FIX;
		Console.WriteLine($"CalibrateSyncParams SYNC_CYCLES {SYNC_CPU_TICK} SYNC_LOOPS {SYNC_LOOPS}");
	}

	private void PSX_EXECUTE()
	{
		double num = 1000.0 / SYNC_CYCLES_IDLE;
		Stopwatch stopwatch = new Stopwatch();
		double num2 = 0.0;
		SYNC_LOOPS = 564480 / SYNC_CYCLES_BUS + SYNC_CYCLES_FIX;
		int num3 = SYNC_LOOPS * SYNC_CPU_TICK;
		while (Running)
		{
			stopwatch.Restart();
			if (!Pauseing)
			{
				Pauseed = false;
				for (int i = 0; i < num3; i++)
				{
					PsxBus.cpu.tick();
					if (i % SYNC_CPU_TICK == 0)
					{
						PsxBus.tick(SYNC_CYCLES_BUS);
						PsxBus.cpu.handleInterrupts();
					}
				}
				ApplyCheats();
			}
			else
			{
				Pauseed = true;
			}
			if (Boost)
			{
				continue;
			}
			double totalMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
			double num4 = num - totalMilliseconds + num2;
			if (num4 > 1.0)
			{
				Thread.Sleep((int)(num4 - 0.1));
				SpinWait spinWait = default(SpinWait);
				while (stopwatch.Elapsed.TotalMilliseconds < num)
				{
					spinWait.SpinOnce();
				}
			}
			else
			{
				Thread.Yield();
			}
			num2 += num - stopwatch.Elapsed.TotalMilliseconds;
			num2 = Math.Max(0.0 - num, Math.Min(num2, num));
		}
	}

	public void Button(Controller.InputAction button, bool Down = false, int conidx = 0)
	{
		if (conidx == 0)
		{
			PsxBus.controller1.Button(button, Down);
		}
		if (conidx == 1)
		{
			PsxBus.controller2.Button(button, Down);
		}
	}

	public void AnalogAxis(float lx, float ly, float rx, float ry, int conidx = 0)
	{
		if (conidx == 0)
		{
			PsxBus.controller1.AnalogAxis(lx, ly, rx, ry);
		}
		if (conidx == 1)
		{
			PsxBus.controller2.AnalogAxis(lx, ly, rx, ry);
		}
	}

	void ICoreHandler.SamplesReady(byte[] samples)
	{
		_Audio.PlaySamples(samples);
	}

	void ICoreHandler.FrameReady(int[] pixels, int width, int height)
	{
		_IRender.RenderFrame(pixels, width, height);
	}
}
