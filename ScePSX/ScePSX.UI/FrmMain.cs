using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ScePSX.Properties;
using ScePSX.Render;
using SDL2;

namespace ScePSX.UI;

public class FrmMain : Form, IAudioHandler, IRenderHandler
{
	public static string version = "ScePSX Beta 0.1.4";

	private static string mypath = Application.StartupPath;

	public static IniFile ini = new IniFile(mypath + "\\ScePSX.ini");

	private string currbios;

	private string shaderpath;

	private int StatusDelay;

	private string gamename;

	private int StateSlot;

	private int CoreWidth;

	private int CoreHeight;

	public static PSXCore Core;

	private nint controller1;

	private nint controller2;

	private bool KeyFirst;

	private bool isAnalog;

	private int concount;

	private int _frameCount;

	private Stopwatch _fpsStopwatch = Stopwatch.StartNew();

	private float _currentFps;

	private static uint audiodeviceid;

	private SDL.SDL_AudioCallback audioCallbackDelegate;

	private CircularBuffer<byte> SamplesBuffer;

	private System.Windows.Forms.Timer timer;

	public ScaleParam scale;

	private bool cutblackline;

	private int[] cutbuff = new int[524288];

	private RomList romList;

	private RenderMode Rendermode = RenderMode.OpenGL;

	private RendererManager Render = new RendererManager();

	private IContainer components;

	private MenuStrip MainMenu;

	private ToolStripMenuItem MnuFile;

	private ToolStripMenuItem MnuDebug;

	private ToolStripMenuItem CpuDbgMnu;

	private ToolStripMenuItem MemEditMnu;

	private ToolStripMenuItem RenderToolStripMenuItem;

	private ToolStripMenuItem directx3DRender;

	private ToolStripMenuItem openGLRender;

	private ToolStripMenuItem LoadDIsk;

	private ToolStripSeparator toolStripMenuItem1;

	private ToolStripMenuItem KeyTool;

	private ToolStripSeparator toolStripMenuItem2;

	private ToolStripMenuItem SaveStripMenuItem;

	private ToolStripMenuItem LoadStripMenuItem;

	private ToolStripMenuItem UnLoadStripMenuItem;

	private ToolStripMenuItem SwapDisk;

	private ToolStripSeparator toolStripMenuItem3;

	private ToolStripSeparator toolStripMenuItem4;

	private ToolStripMenuItem CheatCode;

	private ToolStripSeparator toolStripMenuItem5;

	private ToolStripMenuItem FreeSpeed;

	private ToolStripMenuItem xBRScaleAdd;

	private ToolStripMenuItem xBRScaleDec;

	private ToolStripMenuItem directx2DRender;

	private ToolStripMenuItem CutBlackLineMnu;

	private ToolStripSeparator toolStripMenuItem6;

	private ToolStripMenuItem frameskipmnu;

	private ToolStripMenuItem MnuPause;

	private ToolStripMenuItem SysSetMnu;

	private ToolStripMenuItem NetPlayMnu;

	private ToolStripMenuItem NetPlaySetMnu;

	private ToolStripMenuItem AboutMnu;

	private ToolStripMenuItem CloseRomMnu;

	private ToolStripMenuItem SearchMnu;

	private StatusStrip StatusBar;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private ToolStripStatusLabel toolStripStatusLabel2;

	private ToolStripStatusLabel toolStripStatusLabel3;

	private ToolStripStatusLabel toolStripStatusLabel4;

	private ToolStripStatusLabel toolStripStatusLabel5;

	private ToolStripStatusLabel toolStripStatusLabel6;

	private ToolStripStatusLabel toolStripStatusLabel7;

	private ToolStripStatusLabel toolStripStatusLabel8;

	private ToolStripMenuItem VulkanRenderMnu;

	[DllImport("kernel32.dll")]
	public static extern bool AllocConsole();

	[DllImport("kernel32.dll")]
	public static extern bool FreeConsole();

	public FrmMain()
	{
		InitializeComponent();
		if (ini.ReadInt("Main", "Console") == 1)
		{
			AllocConsole();
		}
		base.KeyDown += ButtonsDown;
		base.KeyUp += ButtonsUp;
		if (!Directory.Exists("./Save"))
		{
			Directory.CreateDirectory("./Save");
		}
		if (!Directory.Exists("./BIOS"))
		{
			Directory.CreateDirectory("./BIOS");
		}
		if (!Directory.Exists("./Cheats"))
		{
			Directory.CreateDirectory("./Cheats");
		}
		if (!Directory.Exists("./SaveState"))
		{
			Directory.CreateDirectory("./SaveState");
		}
		if (!Directory.Exists("./Shaders"))
		{
			Directory.CreateDirectory("./Shaders");
		}
		if (!Directory.Exists("./Icons"))
		{
			Directory.CreateDirectory("./Icons");
		}
		CloseRomMnu_Click(null, null);
		shaderpath = ini.Read("main", "shader");
		Rendermode = (RenderMode)ini.ReadInt("Main", "Render");
		openGLRender.Checked = Rendermode == RenderMode.OpenGL;
		directx2DRender.Checked = Rendermode == RenderMode.Directx2D;
		directx3DRender.Checked = Rendermode == RenderMode.Directx3D;
		VulkanRenderMnu.Checked = Rendermode == RenderMode.Vulkan;
		switch (ini.ReadInt("OpenGL", "MSAA"))
		{
		case 0:
			Render.oglMSAA = 0;
			break;
		case 1:
			Render.oglMSAA = 4;
			break;
		case 2:
			Render.oglMSAA = 6;
			break;
		case 3:
			Render.oglMSAA = 8;
			break;
		case 4:
			Render.oglMSAA = 16;
			break;
		}
		Render.frameskip = ini.ReadInt("main", "skipframe");
		Render.oglShaderPath = "./Shaders/" + shaderpath;
		frameskipmnu.Checked = ini.ReadInt("main", "frameskip") == 1;
		cutblackline = ini.ReadInt("main", "cutblackline") == 1;
		CutBlackLineMnu.Checked = cutblackline;
		KeyFirst = ini.ReadInt("main", "keyfirst") == 1;
		isAnalog = ini.ReadInt("main", "isAnalog") == 1;
		FrmInput.InitKeyMap();
		FrmInput.InitControllerMap();
		timer = new System.Windows.Forms.Timer();
		timer.Interval = 1000;
		timer.Tick += Timer_Elapsed;
		timer.Enabled = true;
		timer.Start();
		currbios = ini.Read("main", "bios");
		if (currbios == null)
		{
			currbios = "SCPH1001.BIN";
		}
		SDLInit();
		InitShaderMnu();
		BackColor = Color.Black;
		StatusBar.BackColor = Color.White;
		base.Load += MainForm_Load;
		base.FormClosing += MainForm_Closing;
	}

	private void MainForm_Load(object sender, EventArgs e)
	{
		string[] array = ini.Read("Main", "FromPos").Split('|');
		if (array.Length >= 4)
		{
			base.Location = new Point(Convert.ToInt16(array[0]), Convert.ToInt16(array[1]));
			base.Size = new Size(Convert.ToInt16(array[2]), Convert.ToInt16(array[3]));
			if (!Screen.PrimaryScreen.WorkingArea.Contains(base.Bounds))
			{
				base.Location = new Point(0, 0);
			}
		}
	}

	private void MainForm_Closing(object sender, FormClosingEventArgs e)
	{
		string value = $"{base.Location.X}|{base.Location.Y}|{base.Size.Width}|{base.Size.Height}";
		ini.Write("Main", "FromPos", value);
	}

	private void UpdateStatus(int index, string text, bool clean = false)
	{
		if (index < 0 || index >= StatusBar.Items.Count)
		{
			return;
		}
		if (clean)
		{
			foreach (ToolStripItem item in StatusBar.Items)
			{
				item.Text = "";
			}
		}
		StatusBar.Items[index].Text = text;
	}

	private void Timer_Elapsed(object sender, EventArgs e)
	{
		CheckController();
		if (Core == null)
		{
			Text = version;
			return;
		}
		if (StatusDelay > 0)
		{
			StatusDelay--;
		}
		else
		{
			UpdateStatus(1, $"F3+ F4- {Resources.FrmMain_Timer_Elapsed_存档槽} [{StateSlot}]");
			UpdateStatus(2, "F9[" + (KeyFirst ? Resources.FrmMain_Timer_Elapsed_键盘优先 : Resources.FrmMain_Timer_Elapsed_手柄优先) + "]");
			UpdateStatus(3, "F10[" + (isAnalog ? Resources.FrmMain_Timer_Elapsed_多轴手柄 : Resources.FrmMain_Timer_Elapsed_数字手柄) + "]");
		}
		if (Core.Pauseed)
		{
			UpdateStatus(1, Resources.FrmMain_Timer_Elapsed_暂停中, clean: true);
		}
		Text = version + "  -  " + gamename;
		int num = CoreWidth;
		int num2 = CoreHeight;
		string text = Rendermode.ToString();
		if (Rendermode == RenderMode.OpenGL && Render.oglMSAA > 0)
		{
			text += $" {Render.oglMSAA}xMSAA";
		}
		if (scale.scale > 0)
		{
			num *= scale.scale;
			num2 *= scale.scale;
		}
		UpdateStatus(0, Core.DiskID);
		UpdateStatus(5, text);
		UpdateStatus(6, $"{((scale.scale > 0) ? scale.mode.ToString() : "")} IR {num}*{num2}");
		UpdateStatus(7, $"FPS {_currentFps:F1}");
	}

	~FrmMain()
	{
		if (Core != null)
		{
			Core.Stop();
		}
		if (audiodeviceid != 0)
		{
			SDL.SDL_CloseAudioDevice(audiodeviceid);
		}
		if (controller1 != 0)
		{
			SDL.SDL_GameControllerClose(controller1);
			SDL.SDL_JoystickClose(controller1);
		}
		SDL.SDL_Quit();
	}

	private void SDLInit()
	{
		SDL.SDL_Init(8208u);
		audioCallbackDelegate = AudioCallbackImpl;
		SDL.SDL_AudioSpec sDL_AudioSpec = default(SDL.SDL_AudioSpec);
		sDL_AudioSpec.channels = 2;
		sDL_AudioSpec.format = 32784;
		sDL_AudioSpec.freq = 44100;
		sDL_AudioSpec.samples = 2048;
		sDL_AudioSpec.callback = audioCallbackDelegate;
		sDL_AudioSpec.userdata = IntPtr.Zero;
		SDL.SDL_AudioSpec desired = sDL_AudioSpec;
		SDL.SDL_AudioSpec obtained = default(SDL.SDL_AudioSpec);
		SetAudioBuffer();
		audiodeviceid = SDL.SDL_OpenAudioDevice(null, 0, ref desired, out obtained, 0);
		if (audiodeviceid != 0)
		{
			SDL.SDL_PauseAudioDevice(audiodeviceid, 0);
		}
	}

	private void SetAudioBuffer()
	{
		if (audiodeviceid != 0)
		{
			SDL.SDL_PauseAudioDevice(audiodeviceid, 1);
		}
		int num = ini.ReadInt("Audio", "Buffer");
		if (num < 50)
		{
			num = 50;
		}
		int capacity = (num * 176 + 2048 - 1) / 2048 * 2048;
		SamplesBuffer = new CircularBuffer<byte>(capacity);
		if (audiodeviceid != 0)
		{
			SDL.SDL_PauseAudioDevice(audiodeviceid, 0);
		}
	}

	private void InitShaderMnu()
	{
		if (shaderpath == null)
		{
			shaderpath = "Base";
		}
		DirectoryInfo[] directories = new DirectoryInfo(mypath + "/Shaders").GetDirectories();
		foreach (DirectoryInfo directoryInfo in directories)
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.Name = directoryInfo.Name;
			toolStripMenuItem.Text = directoryInfo.Name;
			toolStripMenuItem.Tag = 20;
			toolStripMenuItem.CheckOnClick = true;
			toolStripMenuItem.Click += Mnu_Click;
			toolStripMenuItem.CheckedChanged += Mnu_CheckedChanged;
			openGLRender.DropDownItems.Add(toolStripMenuItem);
			if (shaderpath == directoryInfo.Name)
			{
				toolStripMenuItem.Checked = true;
				shaderpath = toolStripMenuItem.Text;
			}
		}
	}

	private void InitStateMnu()
	{
		SaveStripMenuItem.DropDownItems.Clear();
		LoadStripMenuItem.DropDownItems.Clear();
		SaveStripMenuItem.Enabled = true;
		LoadStripMenuItem.Enabled = true;
		UnLoadStripMenuItem.Enabled = true;
		StateSlot = ini.ReadInt("main", "StateSlot");
		for (int i = 0; i < 10; i++)
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			string text = mypath + "/SaveState/" + Core.DiskID + "_Save" + i + ".dat";
			string text2;
			if (File.Exists(text))
			{
				text2 = i + " - " + File.GetLastWriteTime(text).ToLocalTime();
			}
			else
			{
				text2 = i + " - None";
				toolStripMenuItem2.Enabled = false;
			}
			if (i == StateSlot)
			{
				toolStripMenuItem.Checked = true;
			}
			toolStripMenuItem.Name = text;
			toolStripMenuItem.Text = text2;
			toolStripMenuItem.Tag = 30 + i;
			toolStripMenuItem.CheckOnClick = true;
			toolStripMenuItem.Click += Mnu_Click;
			toolStripMenuItem.CheckedChanged += Mnu_CheckedChanged;
			SaveStripMenuItem.DropDownItems.Add(toolStripMenuItem);
			toolStripMenuItem2.Name = text;
			toolStripMenuItem2.Text = text2;
			toolStripMenuItem2.Tag = 40 + i;
			toolStripMenuItem2.Click += Mnu_Click;
			LoadStripMenuItem.DropDownItems.Add(toolStripMenuItem2);
		}
	}

	private void AddMenu(string name, string Text, object tag, ToolStripMenuItem Parent, bool chk = false, bool ch = true)
	{
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Text = Text;
		toolStripMenuItem.Name = name;
		toolStripMenuItem.CheckOnClick = ch;
		toolStripMenuItem.Checked = chk;
		toolStripMenuItem.Tag = tag;
		toolStripMenuItem.Click += Mnu_Click;
		if (ch)
		{
			toolStripMenuItem.CheckedChanged += Mnu_CheckedChanged;
		}
		Parent.DropDownItems.Add(toolStripMenuItem);
	}

	private void Mnu_CheckedChanged(object sender, EventArgs e)
	{
		ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
		ToolStrip currentParent = toolStripMenuItem.GetCurrentParent();
		if (!toolStripMenuItem.Checked || currentParent == null)
		{
			return;
		}
		object tag = toolStripMenuItem.Tag;
		if (tag is int && (int)tag == 20)
		{
			shaderpath = toolStripMenuItem.Text;
			ini.Write("main", "shader", shaderpath);
		}
		foreach (ToolStripMenuItem item in currentParent.Items)
		{
			if (item != null && item != toolStripMenuItem && item.Checked)
			{
				item.Checked = false;
				break;
			}
		}
	}

	private void Mnu_Click(object sender, EventArgs e)
	{
		ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
		if ((int)toolStripMenuItem.Tag >= 30 && (int)toolStripMenuItem.Tag < 40)
		{
			StateSlot = (int)toolStripMenuItem.Tag - 30;
			SaveState(StateSlot);
			Mnu_CheckedChanged(sender, e);
			ini.WriteInt("main", "StateSlot", StateSlot);
			string path = mypath + "/SaveState/" + Core.DiskID + "_Save" + StateSlot + ".dat";
			string text2 = (toolStripMenuItem.Text = StateSlot + " - " + File.GetLastWriteTime(path).ToLocalTime());
			{
				foreach (ToolStripMenuItem dropDownItem in LoadStripMenuItem.DropDownItems)
				{
					if ((int)dropDownItem.Tag == 40 + StateSlot)
					{
						dropDownItem.Text = text2;
						break;
					}
				}
				return;
			}
		}
		if ((int)toolStripMenuItem.Tag >= 40 && (int)toolStripMenuItem.Tag < 50)
		{
			StateSlot = (int)toolStripMenuItem.Tag - 40;
			LoadState(StateSlot);
		}
	}

	private void SearchMnu_Click(object sender, EventArgs e)
	{
		if (Core == null && romList != null)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = ini.Read("main", "LastPath");
			openFileDialog.ValidateNames = false;
			openFileDialog.CheckFileExists = false;
			openFileDialog.CheckPathExists = true;
			openFileDialog.FileName = "select";
			if (openFileDialog.ShowDialog() != DialogResult.Cancel && openFileDialog.FileName != "")
			{
				romList.SearchDir(Path.GetDirectoryName(openFileDialog.FileName));
			}
		}
	}

	private void CloseRomMnu_Click(object sender, EventArgs e)
	{
		if (Core != null)
		{
			Core.Stop();
			Core = null;
		}
		romList = new RomList();
		romList.Parent = this;
		romList.Dock = DockStyle.Fill;
		base.Controls.Add(romList);
		romList.Enabled = true;
		romList.Visible = true;
		romList.BorderStyle = BorderStyle.FixedSingle;
		romList.DoubleClick += romList_DoubleClick;
		romList.FillByini();
		romList.BringToFront();
		UpdateStatus(0, "", clean: true);
	}

	private void directx2DRender_Click(object sender, EventArgs e)
	{
		directx3DRender.Checked = false;
		openGLRender.Checked = false;
		VulkanRenderMnu.Checked = false;
		Rendermode = RenderMode.Directx2D;
		ini.WriteInt("Main", "Render", (int)Rendermode);
		if (Core != null && Core.Running)
		{
			Render.SelectRenderer(Rendermode, this);
		}
	}

	private void directx3DToolStripMenuItem_Click(object sender, EventArgs e)
	{
		openGLRender.Checked = false;
		directx2DRender.Checked = false;
		VulkanRenderMnu.Checked = false;
		Rendermode = RenderMode.Directx3D;
		ini.WriteInt("Main", "Render", (int)Rendermode);
		if (Core != null && Core.Running)
		{
			Render.SelectRenderer(Rendermode, this);
		}
	}

	private void openGLToolStripMenuItem_Click(object sender, EventArgs e)
	{
		directx2DRender.Checked = false;
		directx3DRender.Checked = false;
		VulkanRenderMnu.Checked = false;
		Render.oglShaderPath = "./Shaders/" + shaderpath;
		Rendermode = RenderMode.OpenGL;
		ini.WriteInt("Main", "Render", (int)Rendermode);
		if (Core != null && Core.Running)
		{
			Render.SelectRenderer(Rendermode, this);
		}
	}

	private void VulkanRenderMnu_Click(object sender, EventArgs e)
	{
		openGLRender.Checked = false;
		directx2DRender.Checked = false;
		directx3DRender.Checked = false;
		Rendermode = RenderMode.Vulkan;
		ini.WriteInt("Main", "Render", (int)Rendermode);
		if (Core != null && Core.Running)
		{
			Render.SelectRenderer(Rendermode, this);
		}
	}

	private void frameskipmnu_CheckedChanged(object sender, EventArgs e)
	{
		if (Rendermode != RenderMode.OpenGL && Render._currentRenderer != null)
		{
			if (!frameskipmnu.Checked)
			{
				Render._currentRenderer.SetParam(0);
			}
			else
			{
				Render._currentRenderer.SetParam(ini.ReadInt("Main", "SkipFrame"));
			}
		}
		ini.WriteInt("main", "frameskip", Convert.ToInt16(frameskipmnu.Checked));
	}

	private void CutBlackLineMnu_CheckedChanged(object sender, EventArgs e)
	{
		cutblackline = CutBlackLineMnu.Checked;
		ini.WriteInt("main", "cutblackline", Convert.ToInt16(cutblackline));
	}

	private void LoadDisk_Click(object sender, EventArgs e)
	{
		LoadRom();
	}

	private void romList_DoubleClick(object sender, EventArgs e)
	{
		RomList.Game game = romList.SelectedGame();
		if (game != null)
		{
			LoadRom(game.fullName, game);
		}
	}

	private void SwapDisk_Click(object sender, EventArgs e)
	{
		SwapDisc();
	}

	private void xBRScaleAdd_Click(object sender, EventArgs e)
	{
		if (Core != null && Core.Running && scale.scale < 8)
		{
			scale.scale = ((scale.scale == 0) ? 2 : (scale.scale * 2));
		}
	}

	private void xBRScaleDec_Click(object sender, EventArgs e)
	{
		if (Core != null && Core.Running && scale.scale > 0)
		{
			scale.scale /= 2;
		}
	}

	private void MnuPause_Click(object sender, EventArgs e)
	{
		if (Core != null && Core.Running)
		{
			Core.Pause();
		}
	}

	private void UnLoadStripMenuItem_Click(object sender, EventArgs e)
	{
		UnLoadState();
	}

	private void ShowFrom(Form Frm)
	{
		Frm.StartPosition = FormStartPosition.Manual;
		Frm.Owner = this;
		Point p = new Point(base.ClientSize.Width / 2, base.ClientSize.Height / 2);
		Point point = PointToScreen(p);
		Frm.Location = new Point(point.X - Frm.Width / 2, point.Y - Frm.Height / 2);
		Frm.Show();
	}

	private void CheatCode_Click(object sender, EventArgs e)
	{
		if (Core != null && Core.Running)
		{
			ShowFrom(new Form_Cheat(Core.DiskID));
		}
	}

	private void MnuDebug_Click(object sender, EventArgs e)
	{
		ShowFrom(new Form_Mem());
	}

	private void KeyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ShowFrom(new FrmInput());
	}

	private void AboutMnu_Click(object sender, EventArgs e)
	{
		ShowFrom(new FrmAbout());
	}

	private void NetPlaySetMnu_Click(object sender, EventArgs e)
	{
		ShowFrom(new FrmNetPlay());
	}

	private void SysSetMnu_Click(object sender, EventArgs e)
	{
		ShowFrom(new Form_Set());
	}

	private void SaveState(int Slot = 0)
	{
		if (Core != null && Core.Running)
		{
			Core.SaveState(Slot.ToString());
			UpdateStatus(1, $"{Resources.FrmMain_SaveState_saved} [{StateSlot}]", clean: true);
			StatusDelay = 3;
		}
	}

	private void LoadState(int Slot = 0)
	{
		if (Core != null && Core.Running)
		{
			Core.SaveState("~");
			Core.LoadState(Slot.ToString());
		}
	}

	private void UnLoadState()
	{
		if (Core != null && Core.Running)
		{
			Core.LoadState("~");
		}
	}

	private void ButtonsDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Space)
		{
			if (Core != null && Core.Running)
			{
				Core.Pause();
			}
			return;
		}
		if (e.KeyCode == Keys.F3)
		{
			StateSlot = ((StateSlot < 9) ? (StateSlot + 1) : StateSlot);
			return;
		}
		if (e.KeyCode == Keys.F4)
		{
			StateSlot = ((StateSlot > 0) ? (StateSlot - 1) : StateSlot);
			return;
		}
		if (e.KeyCode == Keys.F5)
		{
			foreach (ToolStripMenuItem dropDownItem in SaveStripMenuItem.DropDownItems)
			{
				if ((int)dropDownItem.Tag == 30 + StateSlot)
				{
					Mnu_Click(dropDownItem, null);
					break;
				}
			}
			return;
		}
		if (e.KeyCode == Keys.F6)
		{
			LoadState(StateSlot);
			return;
		}
		if (e.KeyCode == Keys.F7)
		{
			UnLoadState();
			return;
		}
		if (e.KeyCode == Keys.F9)
		{
			KeyFirst = !KeyFirst;
			ini.WriteInt("main", "keyfirst", KeyFirst ? 1 : 0);
			return;
		}
		if (e.KeyCode == Keys.F10)
		{
			isAnalog = !isAnalog;
			ini.WriteInt("main", "isAnalog", isAnalog ? 1 : 0);
			if (Core != null)
			{
				Core.PsxBus.controller1.IsAnalog = isAnalog;
			}
			return;
		}
		if (e.KeyCode == Keys.Tab && Core != null)
		{
			Core.Boost = true;
			return;
		}
		if (e.KeyCode == Keys.F11)
		{
			if (Core != null && Core.Running && scale.scale < 8)
			{
				scale.scale = ((scale.scale == 0) ? 2 : (scale.scale * 2));
			}
			return;
		}
		if (e.KeyCode == Keys.F12)
		{
			if (Core != null && Core.Running && scale.scale > 0)
			{
				scale.scale /= 2;
			}
			return;
		}
		Controller.InputAction keyButton = FrmInput.KMM1.GetKeyButton(e.KeyCode);
		if (keyButton != (Controller.InputAction)255 && Core != null && Core.Running)
		{
			Core.Button(keyButton, Down: true);
			if (!KeyFirst)
			{
				KeyFirst = true;
			}
		}
		Controller.InputAction keyButton2 = FrmInput.KMM2.GetKeyButton(e.KeyCode);
		if (keyButton2 != (Controller.InputAction)255 && Core != null && Core.Running)
		{
			Core.Button(keyButton2, Down: true, 1);
		}
	}

	private void ButtonsUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Tab && Core != null)
		{
			Core.Boost = false;
			return;
		}
		Controller.InputAction keyButton = FrmInput.KMM1.GetKeyButton(e.KeyCode);
		if (keyButton != (Controller.InputAction)255 && Core != null && Core.Running)
		{
			Core.Button(keyButton);
		}
		Controller.InputAction keyButton2 = FrmInput.KMM2.GetKeyButton(e.KeyCode);
		if (keyButton2 != (Controller.InputAction)255 && Core != null && Core.Running)
		{
			Core.Button(keyButton2, Down: false, 1);
		}
	}

	private void LoadRom(string fn = "", RomList.Game game = null)
	{
		if (!File.Exists("./BIOS/" + currbios))
		{
			UpdateStatus(0, Resources.FrmMain_LoadRom_nobios + " (Bios Not Found)", clean: true);
			timer.Enabled = false;
			timer.Stop();
			return;
		}
		if (fn == "")
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = ini.Read("main", "LastPath");
			openFileDialog.Filter = "ISO|*.bin;*.iso;*.cue;*.img";
			if (openFileDialog.ShowDialog() == DialogResult.Cancel || !File.Exists(openFileDialog.FileName))
			{
				return;
			}
			fn = openFileDialog.FileName;
			gamename = Path.GetFileNameWithoutExtension(fn);
		}
		ini.Write("main", "LastPath", Path.GetDirectoryName(fn));
		if (Core != null)
		{
			Core.Stop();
		}
		IniFile iniFile = ini;
		string diskid = "";
		if (game != null)
		{
			gamename = game.Name;
			diskid = game.ID;
			string text = "./Save/" + game.ID + ".ini";
			if (File.Exists(text))
			{
				ini = new IniFile(text);
			}
		}
		currbios = ini.Read("main", "bios");
		Core = new PSXCore(this, this, fn, mypath + "/BIOS/" + currbios, diskid);
		if (Core.DiskID == "")
		{
			Core = null;
			return;
		}
		iniFile.Write("history", Core.DiskID, fn + "|" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
		SetAudioBuffer();
		if (ini.ReadInt("Main", "Console") == 1)
		{
			Core.PsxBus.cpu.biosdebug = ini.ReadInt("Main", "BiosDebug") == 1;
			Core.PsxBus.cpu.debug = ini.ReadInt("Main", "CPUDebug") == 1;
			Core.PsxBus.cpu.ttydebug = ini.ReadInt("Main", "TTYDebug") == 1;
		}
		Core.SYNC_CYCLES_IDLE = ini.ReadFloat("CPU", "FrameIdle");
		Core.SYNC_CPU_TICK = ini.ReadInt("CPU", "CpuTicks");
		Core.SYNC_CYCLES_BUS = ini.ReadInt("CPU", "BusCycles");
		Core.SYNC_CYCLES_FIX = ini.ReadInt("CPU", "CyclesFix");
		romList.Dispose();
		scale.scale = 0;
		scale.mode = (ScaleMode)ini.ReadInt("Main", "ScaleMode");
		Render.SelectRenderer(Rendermode, this);
		CPU.SetExecution(ini.ReadInt("Main", "CpuMode") == 1);
		Core.Start();
		Core.PsxBus.controller1.IsAnalog = isAnalog;
		CheatCode.Enabled = true;
		if (iniFile != null)
		{
			ini = iniFile;
		}
		InitStateMnu();
	}

	private void SwapDisc()
	{
		if (Core == null)
		{
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = ini.Read("main", "LastPath");
		openFileDialog.Filter = "ISO|*.bin;*.iso;*.cue;*.img";
		openFileDialog.ShowDialog();
		if (File.Exists(openFileDialog.FileName))
		{
			ini.Write("main", "LastPath", Path.GetDirectoryName(openFileDialog.FileName));
			Core.Pauseing = true;
			while (!Core.Pauseed)
			{
				Core.Pauseing = true;
				Application.DoEvents();
				Thread.Sleep(10);
			}
			Core.PsxBus.SwapDisk(openFileDialog.FileName);
			Core.Pauseing = false;
			UpdateStatus(1, Resources.FrmMain_SwapDisc_更换光盘 + " " + Core.DiskID, clean: true);
			StatusDelay = 3;
		}
	}

	public void RenderFrame(int[] pixels, int width, int height)
	{
		CoreWidth = width;
		CoreHeight = height;
		if (cutblackline)
		{
			CoreHeight = PixelsScaler.CutBlackLine(pixels, cutbuff, width, height);
			if (CoreHeight == 0)
			{
				CoreHeight = height;
			}
			else
			{
				pixels = cutbuff;
				height = CoreHeight;
			}
		}
		QueryControllerState(1);
		QueryControllerState(2);
		Render.RenderBuffer(pixels, width, height, scale);
		_frameCount++;
		double totalSeconds = _fpsStopwatch.Elapsed.TotalSeconds;
		if (totalSeconds >= 1.0)
		{
			_currentFps = (float)((double)_frameCount / totalSeconds);
			_frameCount = 0;
			_fpsStopwatch.Restart();
		}
	}

	private unsafe void AudioCallbackImpl(nint userdata, nint stream, int len)
	{
		byte[] array = new byte[len];
		int num = SamplesBuffer.Read(array, 0, len);
		fixed (byte* source = array)
		{
			Buffer.MemoryCopy(source, (void*)stream, len, num);
		}
		if (num < len)
		{
			new Span<byte>((void*)(stream + num), len - num).Fill(0);
		}
	}

	public void PlaySamples(byte[] samples)
	{
		SamplesBuffer.Write(samples, 0, null);
	}

	private void CheckController()
	{
		concount = SDL.SDL_NumJoysticks();
		if (controller1 == 0 && concount >= 1)
		{
			if (SDL.SDL_IsGameController(0) == SDL.SDL_bool.SDL_TRUE)
			{
				controller1 = SDL.SDL_GameControllerOpen(0);
			}
			else
			{
				controller1 = SDL.SDL_JoystickOpen(0);
			}
			Console.WriteLine("Controller Device 1 : " + SDL.SDL_JoystickNameForIndex(0) + " Connected");
		}
		if (controller2 == 0 && concount >= 2)
		{
			if (SDL.SDL_IsGameController(1) == SDL.SDL_bool.SDL_TRUE)
			{
				controller2 = SDL.SDL_GameControllerOpen(1);
			}
			else
			{
				controller2 = SDL.SDL_JoystickOpen(1);
			}
			Console.WriteLine("Controller Device 2 : " + SDL.SDL_JoystickNameForIndex(1) + " Connected");
		}
	}

	private void QueryControllerState(int conidx)
	{
		nint num;
		switch (conidx)
		{
		case 1:
			num = controller1;
			break;
		case 2:
			num = controller2;
			break;
		default:
			return;
		}
		if (Core == null || num == 0)
		{
			return;
		}
		conidx--;
		bool flag = false;
		foreach (SDL.SDL_GameControllerButton value6 in Enum.GetValues(typeof(SDL.SDL_GameControllerButton)))
		{
			bool flag2 = SDL.SDL_GameControllerGetButton(num, value6) == 1;
			if (!isAnalog && flag2 && flag2 && value6 >= SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP && value6 <= SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_MISC1)
			{
				flag = true;
			}
			if (flag2 && KeyFirst)
			{
				KeyFirst = false;
			}
			if (!KeyFirst && FrmInput.AnalogMap.TryGetValue(value6, out var value))
			{
				Core.Button(value, flag2, conidx);
			}
		}
		if (KeyFirst)
		{
			return;
		}
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		short value2 = SDL.SDL_GameControllerGetAxis(num, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX);
		short value3 = SDL.SDL_GameControllerGetAxis(num, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTY);
		short value4 = SDL.SDL_GameControllerGetAxis(num, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTX);
		short value5 = SDL.SDL_GameControllerGetAxis(num, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTY);
		num2 = NormalizeAxis(value2);
		num3 = NormalizeAxis(value3);
		num4 = NormalizeAxis(value4);
		num5 = NormalizeAxis(value5);
		short num6 = SDL.SDL_GameControllerGetAxis(num, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT);
		short num7 = SDL.SDL_GameControllerGetAxis(num, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT);
		Core.Button(Controller.InputAction.L2, num6 > 16384, conidx);
		Core.Button(Controller.InputAction.R2, num7 > 16384, conidx);
		Core.AnalogAxis(num2, num3, num4, num5, conidx);
		if (!flag)
		{
			int hat = 0;
			int num8 = 0;
			nint num9 = SDL.SDL_GameControllerGetJoystick(num);
			if (num9 != IntPtr.Zero)
			{
				num8 = SDL.SDL_JoystickGetHat(num9, hat);
				Core.Button(Controller.InputAction.DPadUp, (num8 & 1) != 0, conidx);
				Core.Button(Controller.InputAction.DPadDown, (num8 & 4) != 0, conidx);
				Core.Button(Controller.InputAction.DPadLeft, (num8 & 8) != 0, conidx);
				Core.Button(Controller.InputAction.DPadRight, (num8 & 2) != 0, conidx);
			}
			if (!isAnalog && num8 == 0)
			{
				Core.Button(Controller.InputAction.DPadUp, num3 < -0.5f, conidx);
				Core.Button(Controller.InputAction.DPadDown, num3 > 0.5f, conidx);
				Core.Button(Controller.InputAction.DPadLeft, num2 < -0.5f, conidx);
				Core.Button(Controller.InputAction.DPadRight, num2 > 0.5f, conidx);
			}
		}
	}

	private float NormalizeAxis(short value)
	{
		float num = MathHelper.Clamp((float)value / 32767f, -1f, 1f);
		if (Math.Abs(num) < 0.1f)
		{
			num = 0f;
		}
		return num;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScePSX.UI.FrmMain));
		this.MainMenu = new System.Windows.Forms.MenuStrip();
		this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
		this.LoadDIsk = new System.Windows.Forms.ToolStripMenuItem();
		this.SwapDisk = new System.Windows.Forms.ToolStripMenuItem();
		this.CloseRomMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
		this.SearchMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.SysSetMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.KeyTool = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
		this.SaveStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.LoadStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.UnLoadStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
		this.CheatCode = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
		this.FreeSpeed = new System.Windows.Forms.ToolStripMenuItem();
		this.MnuPause = new System.Windows.Forms.ToolStripMenuItem();
		this.MnuDebug = new System.Windows.Forms.ToolStripMenuItem();
		this.CpuDbgMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.MemEditMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.RenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.CutBlackLineMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.frameskipmnu = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
		this.directx2DRender = new System.Windows.Forms.ToolStripMenuItem();
		this.directx3DRender = new System.Windows.Forms.ToolStripMenuItem();
		this.openGLRender = new System.Windows.Forms.ToolStripMenuItem();
		this.VulkanRenderMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
		this.xBRScaleAdd = new System.Windows.Forms.ToolStripMenuItem();
		this.xBRScaleDec = new System.Windows.Forms.ToolStripMenuItem();
		this.NetPlayMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.NetPlaySetMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.AboutMnu = new System.Windows.Forms.ToolStripMenuItem();
		this.StatusBar = new System.Windows.Forms.StatusStrip();
		this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
		this.MainMenu.SuspendLayout();
		this.StatusBar.SuspendLayout();
		base.SuspendLayout();
		this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.MnuFile, this.MnuDebug, this.RenderToolStripMenuItem, this.NetPlayMnu, this.AboutMnu });
		this.MainMenu.Location = new System.Drawing.Point(0, 0);
		this.MainMenu.Name = "MainMenu";
		this.MainMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
		this.MainMenu.Size = new System.Drawing.Size(684, 25);
		this.MainMenu.TabIndex = 0;
		this.MainMenu.Text = "menuStrip1";
		this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[16]
		{
			this.LoadDIsk, this.SwapDisk, this.CloseRomMnu, this.toolStripMenuItem1, this.SearchMnu, this.SysSetMnu, this.KeyTool, this.toolStripMenuItem2, this.SaveStripMenuItem, this.LoadStripMenuItem,
			this.UnLoadStripMenuItem, this.toolStripMenuItem3, this.CheatCode, this.toolStripMenuItem5, this.FreeSpeed, this.MnuPause
		});
		this.MnuFile.Name = "MnuFile";
		this.MnuFile.Size = new System.Drawing.Size(57, 21);
		this.MnuFile.Text = ScePSX.Properties.Resources.File;
		this.LoadDIsk.Name = "LoadDIsk";
		this.LoadDIsk.Size = new System.Drawing.Size(191, 22);
		this.LoadDIsk.Text = ScePSX.Properties.Resources.LoadDIsk;
		this.LoadDIsk.Click += new System.EventHandler(LoadDisk_Click);
		this.SwapDisk.Name = "SwapDisk";
		this.SwapDisk.Size = new System.Drawing.Size(191, 22);
		this.SwapDisk.Text = ScePSX.Properties.Resources.SwapDisc;
		this.SwapDisk.Click += new System.EventHandler(SwapDisk_Click);
		this.CloseRomMnu.Name = "CloseRomMnu";
		this.CloseRomMnu.Size = new System.Drawing.Size(191, 22);
		this.CloseRomMnu.Text = ScePSX.Properties.Resources.BackToMain;
		this.CloseRomMnu.Click += new System.EventHandler(CloseRomMnu_Click);
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
		this.SearchMnu.Name = "SearchMnu";
		this.SearchMnu.Size = new System.Drawing.Size(191, 22);
		this.SearchMnu.Text = ScePSX.Properties.Resources.SearchDir;
		this.SearchMnu.Click += new System.EventHandler(SearchMnu_Click);
		this.SysSetMnu.Name = "SysSetMnu";
		this.SysSetMnu.Size = new System.Drawing.Size(191, 22);
		this.SysSetMnu.Text = ScePSX.Properties.Resources.Setting;
		this.SysSetMnu.Click += new System.EventHandler(SysSetMnu_Click);
		this.KeyTool.Name = "KeyTool";
		this.KeyTool.Size = new System.Drawing.Size(191, 22);
		this.KeyTool.Text = ScePSX.Properties.Resources.KeySet;
		this.KeyTool.Click += new System.EventHandler(KeyToolStripMenuItem_Click);
		this.toolStripMenuItem2.Name = "toolStripMenuItem2";
		this.toolStripMenuItem2.Size = new System.Drawing.Size(188, 6);
		this.SaveStripMenuItem.Enabled = false;
		this.SaveStripMenuItem.Name = "SaveStripMenuItem";
		this.SaveStripMenuItem.Size = new System.Drawing.Size(191, 22);
		this.SaveStripMenuItem.Text = ScePSX.Properties.Resources.SaveState;
		this.LoadStripMenuItem.Enabled = false;
		this.LoadStripMenuItem.Name = "LoadStripMenuItem";
		this.LoadStripMenuItem.Size = new System.Drawing.Size(191, 22);
		this.LoadStripMenuItem.Text = ScePSX.Properties.Resources.LoadState;
		this.UnLoadStripMenuItem.Enabled = false;
		this.UnLoadStripMenuItem.Name = "UnLoadStripMenuItem";
		this.UnLoadStripMenuItem.Size = new System.Drawing.Size(191, 22);
		this.UnLoadStripMenuItem.Text = ScePSX.Properties.Resources.UnLoad;
		this.toolStripMenuItem3.Name = "toolStripMenuItem3";
		this.toolStripMenuItem3.Size = new System.Drawing.Size(188, 6);
		this.CheatCode.Enabled = false;
		this.CheatCode.Name = "CheatCode";
		this.CheatCode.Size = new System.Drawing.Size(191, 22);
		this.CheatCode.Text = ScePSX.Properties.Resources.CheatCode;
		this.CheatCode.Click += new System.EventHandler(CheatCode_Click);
		this.toolStripMenuItem5.Name = "toolStripMenuItem5";
		this.toolStripMenuItem5.Size = new System.Drawing.Size(188, 6);
		this.FreeSpeed.Name = "FreeSpeed";
		this.FreeSpeed.Size = new System.Drawing.Size(191, 22);
		this.FreeSpeed.Text = ScePSX.Properties.Resources.FastSpeed;
		this.MnuPause.Name = "MnuPause";
		this.MnuPause.Size = new System.Drawing.Size(191, 22);
		this.MnuPause.Text = ScePSX.Properties.Resources.pause;
		this.MnuPause.Click += new System.EventHandler(MnuPause_Click);
		this.MnuDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.CpuDbgMnu, this.MemEditMnu });
		this.MnuDebug.Name = "MnuDebug";
		this.MnuDebug.Size = new System.Drawing.Size(76, 21);
		this.MnuDebug.Text = ScePSX.Properties.Resources.debug;
		this.CpuDbgMnu.Enabled = false;
		this.CpuDbgMnu.Name = "CpuDbgMnu";
		this.CpuDbgMnu.Size = new System.Drawing.Size(167, 22);
		this.CpuDbgMnu.Text = "CPU";
		this.MemEditMnu.Name = "MemEditMnu";
		this.MemEditMnu.Size = new System.Drawing.Size(167, 22);
		this.MemEditMnu.Text = ScePSX.Properties.Resources.memedit;
		this.MemEditMnu.Click += new System.EventHandler(MnuDebug_Click);
		this.RenderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[10] { this.CutBlackLineMnu, this.frameskipmnu, this.toolStripMenuItem6, this.directx2DRender, this.directx3DRender, this.openGLRender, this.VulkanRenderMnu, this.toolStripMenuItem4, this.xBRScaleAdd, this.xBRScaleDec });
		this.RenderToolStripMenuItem.Name = "RenderToolStripMenuItem";
		this.RenderToolStripMenuItem.Size = new System.Drawing.Size(78, 21);
		this.RenderToolStripMenuItem.Text = ScePSX.Properties.Resources.Render;
		this.CutBlackLineMnu.CheckOnClick = true;
		this.CutBlackLineMnu.Name = "CutBlackLineMnu";
		this.CutBlackLineMnu.Size = new System.Drawing.Size(384, 22);
		this.CutBlackLineMnu.Text = ScePSX.Properties.Resources.cutline;
		this.CutBlackLineMnu.CheckedChanged += new System.EventHandler(CutBlackLineMnu_CheckedChanged);
		this.frameskipmnu.Checked = true;
		this.frameskipmnu.CheckOnClick = true;
		this.frameskipmnu.CheckState = System.Windows.Forms.CheckState.Checked;
		this.frameskipmnu.Name = "frameskipmnu";
		this.frameskipmnu.Size = new System.Drawing.Size(384, 22);
		this.frameskipmnu.Text = ScePSX.Properties.Resources.Frameskip;
		this.frameskipmnu.CheckedChanged += new System.EventHandler(frameskipmnu_CheckedChanged);
		this.toolStripMenuItem6.Name = "toolStripMenuItem6";
		this.toolStripMenuItem6.Size = new System.Drawing.Size(381, 6);
		this.directx2DRender.CheckOnClick = true;
		this.directx2DRender.Name = "directx2DRender";
		this.directx2DRender.Size = new System.Drawing.Size(384, 22);
		this.directx2DRender.Text = "DirectxD2D";
		this.directx2DRender.Click += new System.EventHandler(directx2DRender_Click);
		this.directx3DRender.CheckOnClick = true;
		this.directx3DRender.Name = "directx3DRender";
		this.directx3DRender.Size = new System.Drawing.Size(384, 22);
		this.directx3DRender.Text = "DirectxD3D";
		this.directx3DRender.Click += new System.EventHandler(directx3DToolStripMenuItem_Click);
		this.openGLRender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.openGLRender.CheckOnClick = true;
		this.openGLRender.Name = "openGLRender";
		this.openGLRender.Size = new System.Drawing.Size(384, 22);
		this.openGLRender.Text = "OpenGL";
		this.openGLRender.Click += new System.EventHandler(openGLToolStripMenuItem_Click);
		this.VulkanRenderMnu.CheckOnClick = true;
		this.VulkanRenderMnu.Name = "VulkanRenderMnu";
		this.VulkanRenderMnu.Size = new System.Drawing.Size(384, 22);
		this.VulkanRenderMnu.Text = "Vulkan";
		this.VulkanRenderMnu.Click += new System.EventHandler(VulkanRenderMnu_Click);
		this.toolStripMenuItem4.Name = "toolStripMenuItem4";
		this.toolStripMenuItem4.Size = new System.Drawing.Size(381, 6);
		this.xBRScaleAdd.Name = "xBRScaleAdd";
		this.xBRScaleAdd.Size = new System.Drawing.Size(384, 22);
		this.xBRScaleAdd.Text = "IR Scale++ (F11)";
		this.xBRScaleAdd.Click += new System.EventHandler(xBRScaleAdd_Click);
		this.xBRScaleDec.Name = "xBRScaleDec";
		this.xBRScaleDec.Size = new System.Drawing.Size(384, 22);
		this.xBRScaleDec.Text = "IR Scale --  (F12)";
		this.xBRScaleDec.Click += new System.EventHandler(xBRScaleDec_Click);
		this.NetPlayMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.NetPlaySetMnu });
		this.NetPlayMnu.Name = "NetPlayMnu";
		this.NetPlayMnu.Size = new System.Drawing.Size(82, 21);
		this.NetPlayMnu.Text = ScePSX.Properties.Resources.netplay;
		this.NetPlaySetMnu.Name = "NetPlaySetMnu";
		this.NetPlaySetMnu.Size = new System.Drawing.Size(116, 22);
		this.NetPlaySetMnu.Text = ScePSX.Properties.Resources.netplayset;
		this.NetPlaySetMnu.Click += new System.EventHandler(NetPlaySetMnu_Click);
		this.AboutMnu.Name = "AboutMnu";
		this.AboutMnu.Size = new System.Drawing.Size(71, 21);
		this.AboutMnu.Text = ScePSX.Properties.Resources.about;
		this.AboutMnu.Click += new System.EventHandler(AboutMnu_Click);
		this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.toolStripStatusLabel1, this.toolStripStatusLabel2, this.toolStripStatusLabel3, this.toolStripStatusLabel4, this.toolStripStatusLabel5, this.toolStripStatusLabel6, this.toolStripStatusLabel7, this.toolStripStatusLabel8 });
		this.StatusBar.Location = new System.Drawing.Point(0, 476);
		this.StatusBar.Name = "StatusBar";
		this.StatusBar.Size = new System.Drawing.Size(684, 22);
		this.StatusBar.TabIndex = 1;
		this.toolStripStatusLabel1.Font = new System.Drawing.Font("Arial", 9f);
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
		this.toolStripStatusLabel2.Font = new System.Drawing.Font("Arial", 9f);
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
		this.toolStripStatusLabel3.Font = new System.Drawing.Font("Arial", 9f);
		this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
		this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
		this.toolStripStatusLabel4.Font = new System.Drawing.Font("Arial", 9f);
		this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
		this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 17);
		this.toolStripStatusLabel5.Font = new System.Drawing.Font("Arial", 9f);
		this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
		this.toolStripStatusLabel5.Size = new System.Drawing.Size(669, 17);
		this.toolStripStatusLabel5.Spring = true;
		this.toolStripStatusLabel6.Font = new System.Drawing.Font("Arial", 9f);
		this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
		this.toolStripStatusLabel6.Size = new System.Drawing.Size(0, 17);
		this.toolStripStatusLabel7.Font = new System.Drawing.Font("Arial", 9f);
		this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
		this.toolStripStatusLabel7.Size = new System.Drawing.Size(0, 17);
		this.toolStripStatusLabel8.Font = new System.Drawing.Font("Arial", 9f);
		this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
		this.toolStripStatusLabel8.Size = new System.Drawing.Size(0, 17);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(684, 498);
		base.Controls.Add(this.StatusBar);
		base.Controls.Add(this.MainMenu);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MainMenuStrip = this.MainMenu;
		base.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		base.Name = "FrmMain";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ScePSX";
		this.MainMenu.ResumeLayout(false);
		this.MainMenu.PerformLayout();
		this.StatusBar.ResumeLayout(false);
		this.StatusBar.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
