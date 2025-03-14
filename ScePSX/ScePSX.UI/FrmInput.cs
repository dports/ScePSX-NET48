using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ScePSX.Properties;
using SDL2;

namespace ScePSX.UI;

public class FrmInput : Form
{
	public static KeyMappingManager KMM1 = new KeyMappingManager();

	public static KeyMappingManager KMM2 = new KeyMappingManager();

	public static Dictionary<SDL.SDL_GameControllerButton, Controller.InputAction> AnalogMap;

	private Controller.InputAction SetKey;

	private Button Btn;

	private IContainer components;

	private Button L1;

	private Button L2;

	private Button R2;

	private Button R1;

	private Button U;

	private Button L;

	private Button R;

	private Button D;

	private Button SELE;

	private Button START;

	private Button SQUAD;

	private Button TRI;

	private Button O;

	private Button X;

	private Button BtnSave;

	private Panel plwait;

	private Label label1;

	private ComboBox cbcon;

	private ComboBox cbmode;

	public FrmInput()
	{
		InitializeComponent();
		InitKeyMap();
		InitControllerMap();
		if (SDL.SDL_NumJoysticks() > 0)
		{
			cbmode.Items.Add(SDL.SDL_JoystickNameForIndex(0));
		}
		cbcon.SelectedIndex = 0;
		cbmode.SelectedIndex = 0;
		cbmode.Enabled = false;
		base.KeyUp += FrmInput_KeyUp;
	}

	public static void InitKeyMap()
	{
		try
		{
			KMM1._keyMapping = FrmMain.ini.ReadDictionary<Keys, Controller.InputAction>("Player1Key");
			KMM2._keyMapping = FrmMain.ini.ReadDictionary<Keys, Controller.InputAction>("Player2Key");
		}
		catch
		{
		}
		if (KMM1._keyMapping.Count == 0)
		{
			KMM1.SetKeyMapping(Keys.D2, Controller.InputAction.Select);
			KMM1.SetKeyMapping(Keys.D1, Controller.InputAction.Start);
			KMM1.SetKeyMapping(Keys.W, Controller.InputAction.DPadUp);
			KMM1.SetKeyMapping(Keys.D, Controller.InputAction.DPadRight);
			KMM1.SetKeyMapping(Keys.S, Controller.InputAction.DPadDown);
			KMM1.SetKeyMapping(Keys.A, Controller.InputAction.DPadLeft);
			KMM1.SetKeyMapping(Keys.R, Controller.InputAction.L2);
			KMM1.SetKeyMapping(Keys.T, Controller.InputAction.R2);
			KMM1.SetKeyMapping(Keys.Q, Controller.InputAction.L1);
			KMM1.SetKeyMapping(Keys.E, Controller.InputAction.R1);
			KMM1.SetKeyMapping(Keys.J, Controller.InputAction.Triangle);
			KMM1.SetKeyMapping(Keys.K, Controller.InputAction.Circle);
			KMM1.SetKeyMapping(Keys.I, Controller.InputAction.Cross);
			KMM1.SetKeyMapping(Keys.U, Controller.InputAction.Square);
		}
		if (KMM2._keyMapping.Count == 0)
		{
			KMM2.SetKeyMapping(Keys.D2, Controller.InputAction.Select);
			KMM2.SetKeyMapping(Keys.D1, Controller.InputAction.Start);
			KMM2.SetKeyMapping(Keys.W, Controller.InputAction.DPadUp);
			KMM2.SetKeyMapping(Keys.D, Controller.InputAction.DPadRight);
			KMM2.SetKeyMapping(Keys.S, Controller.InputAction.DPadDown);
			KMM2.SetKeyMapping(Keys.A, Controller.InputAction.DPadLeft);
			KMM2.SetKeyMapping(Keys.R, Controller.InputAction.L2);
			KMM2.SetKeyMapping(Keys.T, Controller.InputAction.R2);
			KMM2.SetKeyMapping(Keys.Q, Controller.InputAction.L1);
			KMM2.SetKeyMapping(Keys.E, Controller.InputAction.R1);
			KMM2.SetKeyMapping(Keys.J, Controller.InputAction.Triangle);
			KMM2.SetKeyMapping(Keys.K, Controller.InputAction.Circle);
			KMM2.SetKeyMapping(Keys.I, Controller.InputAction.Cross);
			KMM2.SetKeyMapping(Keys.U, Controller.InputAction.Square);
		}
		FrmMain.ini.WriteDictionary("Player1Key", KMM1._keyMapping);
		FrmMain.ini.WriteDictionary("Player2Key", KMM2._keyMapping);
	}

	public static void InitControllerMap()
	{
		AnalogMap = new Dictionary<SDL.SDL_GameControllerButton, Controller.InputAction>
		{
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A,
				Controller.InputAction.Circle
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_B,
				Controller.InputAction.Cross
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_X,
				Controller.InputAction.Triangle
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_Y,
				Controller.InputAction.Square
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_BACK,
				Controller.InputAction.Select
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_START,
				Controller.InputAction.Start
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
				Controller.InputAction.L1
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
				Controller.InputAction.R1
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP,
				Controller.InputAction.DPadUp
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_DOWN,
				Controller.InputAction.DPadDown
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_LEFT,
				Controller.InputAction.DPadLeft
			},
			{
				SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
				Controller.InputAction.DPadRight
			}
		};
	}

	private void FrmInput_Shown(object sender, EventArgs e)
	{
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		FrmMain.ini.WriteDictionary("Player1Key", KMM1._keyMapping);
		FrmMain.ini.WriteDictionary("Player2Key", KMM2._keyMapping);
		FrmMain.ini.WriteDictionary("JoyKeyMap", AnalogMap);
	}

	private void FrmInput_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			plwait.Visible = false;
			_ = cbmode.SelectedIndex;
			_ = 1;
		}
		else if (plwait.Visible && cbmode.SelectedIndex != 1)
		{
			Btn.Text = e.KeyCode.ToString();
			if (cbcon.SelectedIndex == 0)
			{
				KMM1.SetKeyMapping(e.KeyCode, SetKey);
			}
			else
			{
				KMM2.SetKeyMapping(e.KeyCode, SetKey);
			}
			plwait.Visible = false;
		}
	}

	private void ReadyGetKey(object sender, Controller.InputAction val)
	{
		plwait.Visible = true;
		Btn = (Button)sender;
		SetKey = val;
		_ = cbmode.SelectedIndex;
		_ = 1;
	}

	private void L2_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.L2);
	}

	private void L1_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.L1);
	}

	private void R2_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.R2);
	}

	private void R1_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.R1);
	}

	private void U_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.DPadUp);
	}

	private void L_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.DPadLeft);
	}

	private void D_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.DPadDown);
	}

	private void R_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.DPadRight);
	}

	private void TRI_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.Triangle);
	}

	private void SQUAD_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.Square);
	}

	private void O_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.Circle);
	}

	private void X_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.Cross);
	}

	private void SELE_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.Select);
	}

	private void START_Click(object sender, EventArgs e)
	{
		ReadyGetKey(sender, Controller.InputAction.Start);
	}

	private void cbcon_SelectedIndexChanged(object sender, EventArgs e)
	{
		KeyMappingManager keyMappingManager = ((cbcon.SelectedIndex != 0) ? KMM2 : KMM1);
		foreach (KeyValuePair<Keys, Controller.InputAction> item in keyMappingManager._keyMapping)
		{
			if (item.Value == Controller.InputAction.Start)
			{
				START.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.Select)
			{
				SELE.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.DPadUp)
			{
				U.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.DPadDown)
			{
				D.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.DPadLeft)
			{
				L.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.DPadRight)
			{
				R.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.L1)
			{
				L1.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.R1)
			{
				R1.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.L2)
			{
				L2.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.R2)
			{
				R2.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.Cross)
			{
				X.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.Circle)
			{
				O.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.Triangle)
			{
				TRI.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
			if (item.Value == Controller.InputAction.Square)
			{
				SQUAD.Text = keyMappingManager.GetKeyCode(item.Value).ToString().ToUpper();
			}
		}
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
		this.L1 = new System.Windows.Forms.Button();
		this.L2 = new System.Windows.Forms.Button();
		this.R2 = new System.Windows.Forms.Button();
		this.R1 = new System.Windows.Forms.Button();
		this.U = new System.Windows.Forms.Button();
		this.L = new System.Windows.Forms.Button();
		this.R = new System.Windows.Forms.Button();
		this.D = new System.Windows.Forms.Button();
		this.SELE = new System.Windows.Forms.Button();
		this.START = new System.Windows.Forms.Button();
		this.SQUAD = new System.Windows.Forms.Button();
		this.TRI = new System.Windows.Forms.Button();
		this.O = new System.Windows.Forms.Button();
		this.X = new System.Windows.Forms.Button();
		this.BtnSave = new System.Windows.Forms.Button();
		this.plwait = new System.Windows.Forms.Panel();
		this.label1 = new System.Windows.Forms.Label();
		this.cbcon = new System.Windows.Forms.ComboBox();
		this.cbmode = new System.Windows.Forms.ComboBox();
		this.plwait.SuspendLayout();
		base.SuspendLayout();
		this.L1.Location = new System.Drawing.Point(18, 65);
		this.L1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.L1.Name = "L1";
		this.L1.Size = new System.Drawing.Size(58, 25);
		this.L1.TabIndex = 2;
		this.L1.Text = "L1: Q";
		this.L1.UseVisualStyleBackColor = true;
		this.L1.Click += new System.EventHandler(L1_Click);
		this.L2.Location = new System.Drawing.Point(18, 39);
		this.L2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.L2.Name = "L2";
		this.L2.Size = new System.Drawing.Size(58, 25);
		this.L2.TabIndex = 3;
		this.L2.Text = "L2: Z";
		this.L2.UseVisualStyleBackColor = true;
		this.L2.Click += new System.EventHandler(L2_Click);
		this.R2.Location = new System.Drawing.Point(245, 39);
		this.R2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.R2.Name = "R2";
		this.R2.Size = new System.Drawing.Size(58, 25);
		this.R2.TabIndex = 5;
		this.R2.Text = "R2: C";
		this.R2.UseVisualStyleBackColor = true;
		this.R2.Click += new System.EventHandler(R2_Click);
		this.R1.Location = new System.Drawing.Point(245, 65);
		this.R1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.R1.Name = "R1";
		this.R1.Size = new System.Drawing.Size(58, 25);
		this.R1.TabIndex = 4;
		this.R1.Text = "R1: E";
		this.R1.UseVisualStyleBackColor = true;
		this.R1.Click += new System.EventHandler(R1_Click);
		this.U.Location = new System.Drawing.Point(43, 103);
		this.U.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.U.Name = "U";
		this.U.Size = new System.Drawing.Size(54, 25);
		this.U.TabIndex = 6;
		this.U.Text = "U:  W";
		this.U.UseVisualStyleBackColor = true;
		this.U.Click += new System.EventHandler(U_Click);
		this.L.Location = new System.Drawing.Point(18, 133);
		this.L.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.L.Name = "L";
		this.L.Size = new System.Drawing.Size(54, 25);
		this.L.TabIndex = 7;
		this.L.Text = "L:  A";
		this.L.UseVisualStyleBackColor = true;
		this.L.Click += new System.EventHandler(L_Click);
		this.R.Location = new System.Drawing.Point(76, 133);
		this.R.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.R.Name = "R";
		this.R.Size = new System.Drawing.Size(54, 25);
		this.R.TabIndex = 8;
		this.R.Text = "R: D";
		this.R.UseVisualStyleBackColor = true;
		this.R.Click += new System.EventHandler(R_Click);
		this.D.Location = new System.Drawing.Point(43, 162);
		this.D.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.D.Name = "D";
		this.D.Size = new System.Drawing.Size(54, 25);
		this.D.TabIndex = 9;
		this.D.Text = "D: S";
		this.D.UseVisualStyleBackColor = true;
		this.D.Click += new System.EventHandler(D_Click);
		this.SELE.Location = new System.Drawing.Point(163, 77);
		this.SELE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.SELE.Name = "SELE";
		this.SELE.Size = new System.Drawing.Size(54, 25);
		this.SELE.TabIndex = 10;
		this.SELE.Text = "Sel:e 2";
		this.SELE.UseVisualStyleBackColor = true;
		this.SELE.Click += new System.EventHandler(SELE_Click);
		this.START.Location = new System.Drawing.Point(105, 77);
		this.START.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.START.Name = "START";
		this.START.Size = new System.Drawing.Size(54, 25);
		this.START.TabIndex = 11;
		this.START.Text = "Start: 1";
		this.START.UseVisualStyleBackColor = true;
		this.START.Click += new System.EventHandler(START_Click);
		this.SQUAD.Location = new System.Drawing.Point(199, 133);
		this.SQUAD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.SQUAD.Name = "SQUAD";
		this.SQUAD.Size = new System.Drawing.Size(64, 25);
		this.SQUAD.TabIndex = 12;
		this.SQUAD.Text = "Squad: J";
		this.SQUAD.UseVisualStyleBackColor = true;
		this.SQUAD.Click += new System.EventHandler(SQUAD_Click);
		this.TRI.Location = new System.Drawing.Point(231, 103);
		this.TRI.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.TRI.Name = "TRI";
		this.TRI.Size = new System.Drawing.Size(54, 25);
		this.TRI.TabIndex = 13;
		this.TRI.Text = "TrI: I";
		this.TRI.UseVisualStyleBackColor = true;
		this.TRI.Click += new System.EventHandler(TRI_Click);
		this.O.Location = new System.Drawing.Point(268, 133);
		this.O.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.O.Name = "O";
		this.O.Size = new System.Drawing.Size(61, 25);
		this.O.TabIndex = 14;
		this.O.Text = "O: K";
		this.O.UseVisualStyleBackColor = true;
		this.O.Click += new System.EventHandler(O_Click);
		this.X.Location = new System.Drawing.Point(231, 162);
		this.X.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.X.Name = "X";
		this.X.Size = new System.Drawing.Size(54, 25);
		this.X.TabIndex = 15;
		this.X.Text = "X: J";
		this.X.UseVisualStyleBackColor = true;
		this.X.Click += new System.EventHandler(X_Click);
		this.BtnSave.Location = new System.Drawing.Point(135, 197);
		this.BtnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.BtnSave.Name = "BtnSave";
		this.BtnSave.Size = new System.Drawing.Size(73, 25);
		this.BtnSave.TabIndex = 16;
		this.BtnSave.Text = ScePSX.Properties.Resources.FrmInput_InitializeComponent_保存设置;
		this.BtnSave.UseVisualStyleBackColor = true;
		this.BtnSave.Click += new System.EventHandler(BtnSave_Click);
		this.plwait.Controls.Add(this.label1);
		this.plwait.Font = new System.Drawing.Font("Microsoft YaHei UI", 12f, System.Drawing.FontStyle.Bold);
		this.plwait.Location = new System.Drawing.Point(81, 65);
		this.plwait.Name = "plwait";
		this.plwait.Size = new System.Drawing.Size(171, 85);
		this.plwait.TabIndex = 17;
		this.plwait.Visible = false;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(1, 32);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(168, 22);
		this.label1.TabIndex = 0;
		this.label1.Text = ScePSX.Properties.Resources.FrmInput_InitializeComponent_按下;
		this.cbcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbcon.FormattingEnabled = true;
		this.cbcon.Items.AddRange(new object[2] { "Controller 1", "Controller 2" });
		this.cbcon.Location = new System.Drawing.Point(18, 6);
		this.cbcon.Name = "cbcon";
		this.cbcon.Size = new System.Drawing.Size(139, 25);
		this.cbcon.TabIndex = 18;
		this.cbcon.SelectedIndexChanged += new System.EventHandler(cbcon_SelectedIndexChanged);
		this.cbmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbmode.FormattingEnabled = true;
		this.cbmode.Items.AddRange(new object[1] { "KeyBoard" });
		this.cbmode.Location = new System.Drawing.Point(184, 6);
		this.cbmode.Name = "cbmode";
		this.cbmode.Size = new System.Drawing.Size(136, 25);
		this.cbmode.TabIndex = 19;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.ClientSize = new System.Drawing.Size(338, 232);
		base.Controls.Add(this.cbmode);
		base.Controls.Add(this.cbcon);
		base.Controls.Add(this.plwait);
		base.Controls.Add(this.BtnSave);
		base.Controls.Add(this.X);
		base.Controls.Add(this.O);
		base.Controls.Add(this.TRI);
		base.Controls.Add(this.SQUAD);
		base.Controls.Add(this.START);
		base.Controls.Add(this.SELE);
		base.Controls.Add(this.D);
		base.Controls.Add(this.R);
		base.Controls.Add(this.L);
		base.Controls.Add(this.U);
		base.Controls.Add(this.R2);
		base.Controls.Add(this.R1);
		base.Controls.Add(this.L2);
		base.Controls.Add(this.L1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		base.MaximizeBox = false;
		base.Name = "FrmInput";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = ScePSX.Properties.Resources.FrmInput_InitializeComponent_按键设置;
		base.Shown += new System.EventHandler(FrmInput_Shown);
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(FrmInput_KeyUp);
		this.plwait.ResumeLayout(false);
		this.plwait.PerformLayout();
		base.ResumeLayout(false);
	}
}
