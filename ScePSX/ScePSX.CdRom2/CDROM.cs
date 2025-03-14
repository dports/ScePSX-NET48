using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ScePSX.CdRom2;

[Serializable]
public class CDROM
{
	[Serializable]
	private struct SectorHeader
	{
		public byte mm;

		public byte ss;

		public byte ff;

		public byte mode;
	}

	[Serializable]
	private struct SectorSubHeader
	{
		public byte file;

		public byte channel;

		public byte subMode;

		public byte codingInfo;

		public bool isEndOfRecord => (subMode & 1) != 0;

		public bool isVideo => (subMode & 2) != 0;

		public bool isAudio => (subMode & 4) != 0;

		public bool isData => (subMode & 8) != 0;

		public bool isTrigger => (subMode & 0x10) != 0;

		public bool isForm2 => (subMode & 0x20) != 0;

		public bool isRealTime => (subMode & 0x40) != 0;

		public bool isEndOfFile => (subMode & 0x80) != 0;
	}

	private enum Mode
	{
		Idle,
		Seek,
		Read,
		Play,
		TOC
	}

	private Queue<byte> parameterBuffer = new Queue<byte>(16);

	private Queue<byte> responseBuffer = new Queue<byte>(16);

	private CDSector currentSector = new CDSector(2352);

	private CDSector lastReadSector = new CDSector(2352);

	private bool isBusy;

	private byte IE;

	private byte IF;

	private byte INDEX;

	private byte STAT;

	private int seekLoc;

	private int readLoc;

	private bool isDoubleSpeed;

	private bool isXAADPCM;

	private bool isSectorSizeRAW;

	private bool isIgnoreBit;

	private bool isXAFilter;

	private bool isReport;

	private bool isAutoPause;

	private bool isCDDA;

	private byte filterFile;

	private byte filterChannel;

	private bool mutedAudio;

	private bool mutedXAADPCM;

	private byte pendingVolumeLtoL = byte.MaxValue;

	private byte pendingVolumeLtoR;

	private byte pendingVolumeRtoL;

	private byte pendingVolumeRtoR = byte.MaxValue;

	private byte volumeLtoL = byte.MaxValue;

	private byte volumeLtoR;

	private byte volumeRtoL;

	private byte volumeRtoR = byte.MaxValue;

	private bool cdDebug;

	private bool isLidOpen;

	private SectorHeader sectorHeader;

	private SectorSubHeader sectorSubHeader;

	private Mode mode;

	private int counter;

	private int swapdiskcount;

	private Queue<byte> interruptQueue = new Queue<byte>();

	private CDData cd;

	private SPU spu;

	public CDROM(CDData cd, SPU spu)
	{
		this.cd = cd;
		this.spu = spu;
		swapdiskcount = 0;
	}

	public Span<uint> processDmaRead(int size)
	{
		return currentSector.Read(size);
	}

	public void SwapDisk(CDData cd)
	{
		isLidOpen = true;
		STAT = 24;
		mode = Mode.Idle;
		interruptQueue.Clear();
		responseBuffer.Clear();
		swapdiskcount = 33868800;
		this.cd = cd;
	}

	public bool tick(int cycles)
	{
		counter += cycles;
		if (interruptQueue.Count != 0 && IF == 0)
		{
			IF |= interruptQueue.Dequeue();
		}
		if ((IF & IE) != 0)
		{
			isBusy = false;
			return true;
		}
		if (isLidOpen)
		{
			if (swapdiskcount > 0)
			{
				swapdiskcount -= cycles;
			}
			else
			{
				STAT = 0;
				mode = Mode.Idle;
				isLidOpen = false;
			}
		}
		switch (mode)
		{
		case Mode.Idle:
			counter = 0;
			return false;
		case Mode.Seek:
			if (counter < 11289600 || interruptQueue.Count != 0)
			{
				return false;
			}
			counter = 0;
			mode = Mode.Idle;
			STAT = (byte)(STAT & -65);
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(2);
			break;
		case Mode.Read:
		case Mode.Play:
		{
			if (counter < 33868800 / (isDoubleSpeed ? 150 : 75) || interruptQueue.Count != 0)
			{
				return false;
			}
			counter = 0;
			byte[] array = cd.Read(readLoc++);
			if (cdDebug)
			{
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine($"[CDROM] Reading readLoc: {readLoc - 1} seekLoc: {seekLoc} size: {array.Length}");
				Console.ResetColor();
			}
			if (mode == Mode.Play)
			{
				if (!mutedAudio && isCDDA)
				{
					applyVolume(array);
					spu.pushCdBufferSamples(array);
				}
				if (isAutoPause && cd.isTrackChange)
				{
					responseBuffer.Enqueue(STAT);
					interruptQueue.Enqueue(4);
					pause();
				}
				_ = isReport;
				return false;
			}
			sectorHeader.mm = array[12];
			sectorHeader.ss = array[13];
			sectorHeader.ff = array[14];
			sectorHeader.mode = array[15];
			sectorSubHeader.file = array[16];
			sectorSubHeader.channel = array[17];
			sectorSubHeader.subMode = array[18];
			sectorSubHeader.codingInfo = array[19];
			if (isXAADPCM && sectorSubHeader.isForm2)
			{
				if (sectorSubHeader.isEndOfFile && cdDebug)
				{
					Console.WriteLine("[CDROM] XA ON: End of File!");
				}
				if (sectorSubHeader.isRealTime && sectorSubHeader.isAudio)
				{
					if (isXAFilter && (filterFile != sectorSubHeader.file || filterChannel != sectorSubHeader.channel))
					{
						if (cdDebug)
						{
							Console.WriteLine("[CDROM] XA Filter: file || channel");
						}
						return false;
					}
					if (cdDebug)
					{
						Console.WriteLine("[CDROM] XA ON: Realtime + Audio");
					}
					if (!mutedAudio && !mutedXAADPCM)
					{
						byte[] array2 = XaAdpcm.Decode(array, sectorSubHeader.codingInfo);
						applyVolume(array2);
						spu.pushCdBufferSamples(array2);
					}
					return false;
				}
			}
			Span<byte> span;
			if (!isSectorSizeRAW)
			{
				span = array.AsSpan();
				Span<byte> data = span.Slice(24, 2048);
				lastReadSector.fillWith(data);
			}
			else
			{
				span = array.AsSpan();
				Span<byte> data2 = span.Slice(12);
				lastReadSector.fillWith(data2);
			}
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(1);
			break;
		}
		case Mode.TOC:
			if (counter < 33868800 / (isDoubleSpeed ? 150 : 75) || interruptQueue.Count != 0)
			{
				return false;
			}
			mode = Mode.Idle;
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(2);
			counter = 0;
			break;
		}
		return false;
	}

	public uint read(uint addr)
	{
		switch (addr)
		{
		case 528488448u:
			return STATUS();
		case 528488449u:
			if (responseBuffer.Count > 0)
			{
				return responseBuffer.Dequeue();
			}
			return 255u;
		case 528488450u:
			return currentSector.ReadByte();
		case 528488451u:
			switch (INDEX)
			{
			case 0:
			case 2:
				return (uint)(0xE0 | IE);
			case 1:
			case 3:
				return (uint)(0xE0 | IF);
			default:
				if (cdDebug)
				{
					Console.WriteLine("[CDROM] [L03.x] Unimplemented");
				}
				return 0u;
			}
		default:
			return 0u;
		}
	}

	public void write(uint addr, uint value)
	{
		switch (addr)
		{
		case 528488448u:
			INDEX = (byte)(value & 3);
			break;
		case 528488449u:
			if (INDEX == 0)
			{
				ExecuteCommand(value);
			}
			else if (INDEX == 3)
			{
				pendingVolumeRtoR = (byte)value;
			}
			break;
		case 528488450u:
			switch (INDEX)
			{
			case 0:
				parameterBuffer.Enqueue((byte)value);
				break;
			case 1:
				IE = (byte)(value & 0x1F);
				break;
			case 2:
				pendingVolumeLtoL = (byte)value;
				break;
			case 3:
				pendingVolumeRtoL = (byte)value;
				break;
			default:
				if (cdDebug)
				{
					Console.WriteLine($"[CDROM] [Unhandled Write] Access: {addr:x8} Value: {value:x8}");
				}
				break;
			}
			break;
		case 528488451u:
			switch (INDEX)
			{
			case 0:
				if ((value & 0x80) != 0)
				{
					if (!currentSector.HasData())
					{
						currentSector.fillWith(lastReadSector.Read());
					}
				}
				else
				{
					currentSector.Clear();
				}
				break;
			case 1:
				IF &= (byte)(~(value & 0x1F));
				if (interruptQueue.Count > 0)
				{
					IF |= interruptQueue.Dequeue();
				}
				if ((value & 0x40) == 64)
				{
					parameterBuffer.Clear();
				}
				break;
			case 2:
				pendingVolumeLtoR = (byte)value;
				break;
			case 3:
				mutedXAADPCM = (value & 1) != 0;
				if ((value & 0x20) != 0)
				{
					volumeLtoL = pendingVolumeLtoL;
					volumeLtoR = pendingVolumeLtoR;
					volumeRtoL = pendingVolumeRtoL;
					volumeRtoR = pendingVolumeRtoR;
				}
				break;
			default:
				if (cdDebug)
				{
					Console.WriteLine($"[CDROM] [Unhandled Write] Access: {addr:x8} Value: {value:x8}");
				}
				break;
			}
			break;
		default:
			if (cdDebug)
			{
				Console.WriteLine($"[CDROM] [Unhandled Write] Access: {addr:x8} Value: {value:x8}");
			}
			break;
		}
	}

	private void ExecuteCommand(uint value)
	{
		if (cdDebug)
		{
			Console.WriteLine($"[CDROM] Command {value:x4}");
		}
		interruptQueue.Clear();
		responseBuffer.Clear();
		isBusy = true;
		switch (value)
		{
		case 1u:
			getStat();
			break;
		case 2u:
			setLoc();
			break;
		case 3u:
			play();
			break;
		case 6u:
			readN();
			break;
		case 7u:
			motorOn();
			break;
		case 8u:
			stop();
			break;
		case 9u:
			pause();
			break;
		case 10u:
			init();
			break;
		case 11u:
			mute();
			break;
		case 12u:
			demute();
			break;
		case 13u:
			setFilter();
			break;
		case 14u:
			setMode();
			break;
		case 16u:
			getLocL();
			break;
		case 17u:
			getLocP();
			break;
		case 18u:
			setSession();
			break;
		case 19u:
			getTN();
			break;
		case 20u:
			getTD();
			break;
		case 21u:
			seekL();
			break;
		case 22u:
			seekP();
			break;
		case 25u:
			test();
			break;
		case 26u:
			getID();
			break;
		case 27u:
			readS();
			break;
		case 30u:
			readTOC();
			break;
		case 31u:
			videoCD();
			break;
		case 80u:
		case 81u:
		case 82u:
		case 83u:
		case 84u:
		case 85u:
		case 86u:
		case 87u:
			lockUnlock();
			break;
		default:
			UnimplementedCDCommand(value);
			break;
		}
	}

	private void mute()
	{
		mutedAudio = true;
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
	}

	private void readTOC()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
		}
		else
		{
			mode = Mode.TOC;
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(3);
		}
	}

	private void motorOn()
	{
		STAT = 2;
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(2);
	}

	private void getLocL()
	{
		if (cdDebug)
		{
			Console.WriteLine($"mm: {sectorHeader.mm} ss: {sectorHeader.ss} ff: {sectorHeader.ff} mode: {sectorHeader.mode} file: {sectorSubHeader.file} channel: {sectorSubHeader.channel} subMode: {sectorSubHeader.subMode} codingInfo: {sectorSubHeader.codingInfo}");
		}
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
		}
		else
		{
			Span<byte> parameters2 = stackalloc byte[8] { sectorHeader.mm, sectorHeader.ss, sectorHeader.ff, sectorHeader.mode, sectorSubHeader.file, sectorSubHeader.channel, sectorSubHeader.subMode, sectorSubHeader.codingInfo };
			responseBuffer.EnqueueRange(parameters2);
			interruptQueue.Enqueue(3);
		}
	}

	private void getLocP()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
			return;
		}
		CDTrack trackFromLoc = cd.getTrackFromLoc(readLoc);
		var (value, value2, value3) = getMMSSFFfromLBA(readLoc - trackFromLoc.LbaStart);
		var (value4, value5, value6) = getMMSSFFfromLBA(readLoc);
		if (cdDebug)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"track: {trackFromLoc.Index} index: {1} mm: {value} ss: {value2} ff: {value3} amm: {value4} ass: {value5} aff: {value6}");
			Console.WriteLine($"track: {trackFromLoc.Index} index: {1} mm: {DecToBcd(value)} ss: {DecToBcd(value2)} ff: {DecToBcd(value3)} amm: {DecToBcd(value4)} ass: {DecToBcd(value5)} aff: {DecToBcd(value6)}");
			Console.ResetColor();
		}
		Span<byte> parameters2 = stackalloc byte[8]
		{
			trackFromLoc.Index,
			1,
			DecToBcd(value),
			DecToBcd(value2),
			DecToBcd(value3),
			DecToBcd(value4),
			DecToBcd(value5),
			DecToBcd(value6)
		};
		responseBuffer.EnqueueRange(parameters2);
		interruptQueue.Enqueue(3);
	}

	private void lockUnlock()
	{
		interruptQueue.Enqueue(5);
	}

	private void videoCD()
	{
		Queue<byte> queue = responseBuffer;
		Span<byte> parameters = stackalloc byte[2] { 17, 64 };
		queue.EnqueueRange(parameters);
		interruptQueue.Enqueue(5);
	}

	private void setSession()
	{
		parameterBuffer.Clear();
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
		}
		else
		{
			STAT = 66;
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(3);
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(2);
		}
	}

	private void setFilter()
	{
		filterFile = parameterBuffer.Dequeue();
		filterChannel = parameterBuffer.Dequeue();
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
	}

	private void readS()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
		}
		else
		{
			readLoc = seekLoc;
			STAT = 2;
			STAT |= 32;
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(3);
			mode = Mode.Read;
		}
	}

	private void seekP()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
		}
		else
		{
			readLoc = seekLoc;
			STAT = 66;
			mode = Mode.Seek;
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(3);
		}
	}

	private void play()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
			return;
		}
		int num = 0;
		if (parameterBuffer.Count > 0)
		{
			num = BcdToDec(parameterBuffer.Dequeue());
			readLoc = (seekLoc = cd.tracks[num].LbaStart);
		}
		else
		{
			readLoc = seekLoc;
		}
		Console.WriteLine($"[CDROM] CDDA Play Track: {num} Loc: {readLoc}");
		STAT = 130;
		mode = Mode.Play;
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
	}

	private void stop()
	{
		STAT = 0;
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(2);
		mode = Mode.Idle;
	}

	private void getTD()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
			return;
		}
		int num = BcdToDec(parameterBuffer.Dequeue());
		if (num == 0)
		{
			(byte mm, byte ss, byte ff) mMSSFFfromLBA = getMMSSFFfromLBA(cd.getLBA());
			byte item = mMSSFFfromLBA.mm;
			byte item2 = mMSSFFfromLBA.ss;
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[3]
			{
				STAT,
				DecToBcd(item),
				DecToBcd(item2)
			};
			queue.EnqueueRange(parameters);
			if (cdDebug)
			{
				Console.WriteLine($"[CDROM] Track: {num} STAT: {STAT:x2} {item}:{item2}");
			}
		}
		else
		{
			(byte mm, byte ss, byte ff) mMSSFFfromLBA2 = getMMSSFFfromLBA(cd.tracks[num - 1].LbaStart);
			byte item3 = mMSSFFfromLBA2.mm;
			byte item4 = mMSSFFfromLBA2.ss;
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[3]
			{
				STAT,
				DecToBcd(item3),
				DecToBcd(item4)
			};
			queue.EnqueueRange(parameters);
			if (cdDebug)
			{
				Console.WriteLine($"[CDROM] Track: {num} STAT: {STAT:x2} {item3}:{item4}");
			}
		}
		interruptQueue.Enqueue(3);
	}

	private unsafe void getTN()
	{
		Queue<byte> queue;
		Span<byte> parameters;
		if (isLidOpen)
		{
			queue = responseBuffer;
			parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
			return;
		}
		if (cdDebug)
		{
			Console.WriteLine($"[CDROM] First Track: 1 - Last Track: {cd.tracks.Count}");
		}
		queue = responseBuffer;
		parameters = stackalloc byte[3]
		{
			STAT,
			1,
			DecToBcd((byte)cd.tracks.Count)
		};
		queue.EnqueueRange(parameters);
		interruptQueue.Enqueue(3);
	}

	private void demute()
	{
		mutedAudio = false;
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
	}

	private void init()
	{
		STAT = 2;
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(2);
	}

	private void pause()
	{
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
		STAT = 2;
		mode = Mode.Idle;
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(2);
	}

	private void readN()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
		}
		else
		{
			readLoc = seekLoc;
			STAT = 2;
			STAT |= 32;
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(3);
			mode = Mode.Read;
		}
	}

	private void setMode()
	{
		uint num = parameterBuffer.Dequeue();
		isDoubleSpeed = ((num >> 7) & 1) == 1;
		isXAADPCM = ((num >> 6) & 1) == 1;
		isSectorSizeRAW = ((num >> 5) & 1) == 1;
		isIgnoreBit = ((num >> 4) & 1) == 1;
		isXAFilter = ((num >> 3) & 1) == 1;
		isReport = ((num >> 2) & 1) == 1;
		isAutoPause = ((num >> 1) & 1) == 1;
		isCDDA = (num & 1) == 1;
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
	}

	private void seekL()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
		}
		else
		{
			readLoc = seekLoc;
			STAT = 66;
			mode = Mode.Seek;
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(3);
		}
	}

	private void setLoc()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
			return;
		}
		byte value = parameterBuffer.Dequeue();
		byte value2 = parameterBuffer.Dequeue();
		byte value3 = parameterBuffer.Dequeue();
		int num = BcdToDec(value);
		int num2 = BcdToDec(value2);
		int num3 = BcdToDec(value3);
		seekLoc = num3 + num2 * 75 + num * 60 * 75;
		if (seekLoc < 0)
		{
			seekLoc = 0;
		}
		if (cdDebug)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine($"[CDROM] setLoc {value:x2}:{value2:x2}:{value3:x2} Loc: {seekLoc:x8}");
			Console.ResetColor();
		}
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
	}

	private void getID()
	{
		if (isLidOpen)
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 17, 128 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(5);
			return;
		}
		STAT = 64;
		STAT |= 2;
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
		Span<byte> parameters2 = stackalloc byte[8] { 2, 0, 32, 0, 83, 67, 69, 65 };
		responseBuffer.EnqueueRange(parameters2);
		interruptQueue.Enqueue(2);
	}

	private void getStat()
	{
		if (!isLidOpen)
		{
			STAT = (byte)(STAT & -25);
			STAT |= 2;
		}
		responseBuffer.Enqueue(STAT);
		interruptQueue.Enqueue(3);
	}

	private void UnimplementedCDCommand(uint value)
	{
		Console.WriteLine($"[CDROM] Unimplemented CD Command {value}");
	}

	private void test()
	{
		uint num = parameterBuffer.Dequeue();
		responseBuffer.Clear();
		switch (num)
		{
		case 4u:
			Console.WriteLine("[CDROM] AntiMod Chip Meassures");
			STAT = 2;
			responseBuffer.Enqueue(STAT);
			interruptQueue.Enqueue(3);
			break;
		case 5u:
		{
			Console.WriteLine("[CDROM] AntiMod Chip Bypass");
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[2] { 0, 0 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(3);
			break;
		}
		case 32u:
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[4] { 148, 9, 25, 192 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(3);
			break;
		}
		case 34u:
		{
			Queue<byte> queue = responseBuffer;
			Span<byte> parameters = stackalloc byte[10] { 102, 111, 114, 32, 85, 83, 47, 65, 69, 80 };
			queue.EnqueueRange(parameters);
			interruptQueue.Enqueue(3);
			break;
		}
		case 96u:
			responseBuffer.Enqueue(0);
			interruptQueue.Enqueue(3);
			break;
		default:
			Console.WriteLine($"[CDROM] Unimplemented 0x19 Test Command {num:x8}");
			break;
		}
	}

	private byte STATUS()
	{
		return (byte)(0u | (isBusy ? 1u : 0u) | (uint)(dataBuffer_hasData() << 6) | (uint)(responseBuffer_hasData() << 5) | (uint)(parametterBuffer_hasSpace() << 4) | (uint)(parametterBuffer_isEmpty() << 3) | (uint)(isXAADPCM ? 4 : 0) | INDEX);
	}

	private int dataBuffer_hasData()
	{
		return currentSector.HasData() ? 1 : 0;
	}

	private int parametterBuffer_isEmpty()
	{
		return (parameterBuffer.Count == 0) ? 1 : 0;
	}

	private int parametterBuffer_hasSpace()
	{
		return (parameterBuffer.Count < 16) ? 1 : 0;
	}

	private int responseBuffer_hasData()
	{
		return (responseBuffer.Count > 0) ? 1 : 0;
	}

	private static byte DecToBcd(byte value)
	{
		return (byte)(value + 6 * (value / 10));
	}

	private static int BcdToDec(byte value)
	{
		return value - 6 * (value >> 4);
	}

	private static (byte mm, byte ss, byte ff) getMMSSFFfromLBA(int lba)
	{
		int num = lba % 75;
		lba /= 75;
		int num2 = lba % 60;
		lba /= 60;
		return (mm: (byte)lba, ss: (byte)num2, ff: (byte)num);
	}

	private void applyVolume(byte[] rawSector)
	{
		Span<short> span = MemoryMarshal.Cast<byte, short>(rawSector);
		for (int i = 0; i < span.Length; i += 2)
		{
			short num = span[i];
			short num2 = span[i + 1];
			int value = (num * volumeLtoL >> 7) + (num2 * volumeRtoL >> 7);
			int value2 = (num * volumeLtoR >> 7) + (num2 * volumeRtoR >> 7);
			span[i] = (short)MathHelper.Clamp(value, -32768, 32767);
			span[i + 1] = (short)MathHelper.Clamp(value2, -32768, 32767);
		}
	}
}
