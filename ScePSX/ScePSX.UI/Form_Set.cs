using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ScePSX.Properties;

namespace ScePSX.UI;

public class Form_Set : Form
{
	private string id;

	private IniFile ini;

	private IContainer components;

	private Button btnsave;

	private GroupBox groupBox1;

	private Label label4;

	private TextBox tbcputicks;

	private Label label3;

	private TextBox tbbuscycles;

	private Label label2;

	private CheckBox cbconsole;

	private ComboBox cbmsaa;

	private TextBox tbframeskip;

	private Label label5;

	private TextBox tbaudiobuffer;

	private Label label6;

	private Label label8;

	private TextBox tbframeidle;

	private TextBox tbcylesfix;

	private Label label9;

	private CheckBox chkcpu;

	private CheckBox chkbios;

	private CheckBox chkTTY;

	private Label label1;

	private ComboBox cbbios;

	private Button btndel;

	private Label label10;

	private ComboBox cbcpumode;

	private Label label11;

	private ComboBox cbscalemode;

	private Label label7;

	private Label label12;

	private ComboBox cbgpu;

	private Label label13;

	private ComboBox cbgpures;

	private CheckBox chkrealcolor;

	private CheckBox chkpgxp;

	private CheckBox chkpgxpt;

	public Form_Set(string id = "")
	{
		InitializeComponent();
		this.id = id;
		if (id == "")
		{
			loadini(FrmMain.ini);
			btndel.Visible = false;
		}
		else
		{
			string path = "./Save/" + id + ".ini";
			ini = new IniFile("./Save/" + id + ".ini");
			if (!File.Exists(path))
			{
				loadini(FrmMain.ini);
			}
			else
			{
				loadini(ini);
			}
			btndel.Visible = true;
			Text = " " + id + " " + Resources.Form_Set_Form_Set_set;
		}
		cbgpu.SelectedIndex = 0;
		cbgpures.SelectedIndex = 1;
	}

	private void edtxt_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void btnsave_Click(object sender, EventArgs e)
	{
		if (id == "")
		{
			saveini(FrmMain.ini);
		}
		else
		{
			saveini(ini);
		}
	}

	private void btndel_Click(object sender, EventArgs e)
	{
		if (!(id == ""))
		{
			string path = "./Save/" + id + ".ini";
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			loadini(FrmMain.ini);
		}
	}

	private void loadini(IniFile ini)
	{
		tbbuscycles.Text = ini.Read("CPU", "BusCycles");
		tbcylesfix.Text = ini.Read("CPU", "CyclesFix");
		tbframeidle.Text = ini.Read("CPU", "FrameIdle");
		tbframeskip.Text = ini.Read("Main", "SkipFrame");
		tbcputicks.Text = ini.Read("CPU", "CpuTicks");
		tbaudiobuffer.Text = ini.Read("Audio", "Buffer");
		cbmsaa.SelectedIndex = ini.ReadInt("OpenGL", "MSAA");
		cbscalemode.SelectedIndex = ini.ReadInt("Main", "ScaleMode");
		chkbios.Checked = ini.ReadInt("Main", "BiosDebug") == 1;
		chkcpu.Checked = ini.ReadInt("Main", "CPUDebug") == 1;
		chkTTY.Checked = ini.ReadInt("Main", "TTYDebug") == 1;
		cbconsole.Checked = ini.ReadInt("Main", "Console") == 1;
		cbcpumode.SelectedIndex = ini.ReadInt("Main", "CpuMode");
		string text = ini.Read("main", "bios");
		DirectoryInfo directoryInfo = new DirectoryInfo("./BIOS");
		if (!directoryInfo.Exists || directoryInfo.GetFiles().Length == 0)
		{
			return;
		}
		cbbios.Items.Clear();
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			cbbios.Items.Add(fileInfo.Name);
			if (text == fileInfo.Name)
			{
				cbbios.SelectedIndex = cbbios.Items.Count - 1;
			}
		}
	}

	private void saveini(IniFile ini)
	{
		try
		{
			ini.WriteInt("CPU", "BusCycles", int.Parse(tbbuscycles.Text));
			ini.WriteInt("CPU", "CyclesFix", int.Parse(tbcylesfix.Text));
			ini.WriteFloat("CPU", "FrameIdle", double.Parse(tbframeidle.Text));
			ini.WriteInt("Main", "SkipFrame", int.Parse(tbframeskip.Text));
			ini.WriteInt("CPU", "CpuTicks", int.Parse(tbcputicks.Text));
			ini.WriteInt("Audio", "Buffer", int.Parse(tbaudiobuffer.Text));
			ini.WriteInt("OpenGL", "MSAA", cbmsaa.SelectedIndex);
			ini.WriteInt("Main", "BiosDebug", chkbios.Checked ? 1 : 0);
			ini.WriteInt("Main", "CPUDebug", chkcpu.Checked ? 1 : 0);
			ini.WriteInt("Main", "TTYDebug", chkTTY.Checked ? 1 : 0);
			ini.WriteInt("Main", "Console", cbconsole.Checked ? 1 : 0);
			ini.WriteInt("Main", "CpuMode", cbcpumode.SelectedIndex);
			ini.WriteInt("Main", "ScaleMode", cbscalemode.SelectedIndex);
			ini.Write("main", "bios", cbbios.Items[cbbios.SelectedIndex].ToString());
		}
		catch
		{
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
		this.btnsave = new System.Windows.Forms.Button();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.cbscalemode = new System.Windows.Forms.ComboBox();
		this.label7 = new System.Windows.Forms.Label();
		this.chkTTY = new System.Windows.Forms.CheckBox();
		this.chkcpu = new System.Windows.Forms.CheckBox();
		this.chkbios = new System.Windows.Forms.CheckBox();
		this.tbcylesfix = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.tbframeidle = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.tbaudiobuffer = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.tbframeskip = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.cbmsaa = new System.Windows.Forms.ComboBox();
		this.label4 = new System.Windows.Forms.Label();
		this.tbcputicks = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.tbbuscycles = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.cbconsole = new System.Windows.Forms.CheckBox();
		this.label1 = new System.Windows.Forms.Label();
		this.cbbios = new System.Windows.Forms.ComboBox();
		this.btndel = new System.Windows.Forms.Button();
		this.label10 = new System.Windows.Forms.Label();
		this.cbcpumode = new System.Windows.Forms.ComboBox();
		this.label11 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.cbgpu = new System.Windows.Forms.ComboBox();
		this.label13 = new System.Windows.Forms.Label();
		this.cbgpures = new System.Windows.Forms.ComboBox();
		this.chkrealcolor = new System.Windows.Forms.CheckBox();
		this.chkpgxp = new System.Windows.Forms.CheckBox();
		this.chkpgxpt = new System.Windows.Forms.CheckBox();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.btnsave.Location = new System.Drawing.Point(348, 266);
		this.btnsave.Name = "btnsave";
		this.btnsave.Size = new System.Drawing.Size(75, 27);
		this.btnsave.TabIndex = 0;
		this.btnsave.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_save;
		this.btnsave.UseVisualStyleBackColor = true;
		this.btnsave.Click += new System.EventHandler(btnsave_Click);
		this.groupBox1.Controls.Add(this.cbscalemode);
		this.groupBox1.Controls.Add(this.label7);
		this.groupBox1.Controls.Add(this.chkTTY);
		this.groupBox1.Controls.Add(this.chkcpu);
		this.groupBox1.Controls.Add(this.chkbios);
		this.groupBox1.Controls.Add(this.tbcylesfix);
		this.groupBox1.Controls.Add(this.label9);
		this.groupBox1.Controls.Add(this.tbframeidle);
		this.groupBox1.Controls.Add(this.label8);
		this.groupBox1.Controls.Add(this.tbaudiobuffer);
		this.groupBox1.Controls.Add(this.label6);
		this.groupBox1.Controls.Add(this.tbframeskip);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.cbmsaa);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.Controls.Add(this.tbcputicks);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.tbbuscycles);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.cbconsole);
		this.groupBox1.Location = new System.Drawing.Point(12, 12);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(411, 171);
		this.groupBox1.TabIndex = 2;
		this.groupBox1.TabStop = false;
		this.cbscalemode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbscalemode.FormattingEnabled = true;
		this.cbscalemode.Items.AddRange(new object[3] { "Neighbor", "JINC", "xBR" });
		this.cbscalemode.Location = new System.Drawing.Point(331, 44);
		this.cbscalemode.Name = "cbscalemode";
		this.cbscalemode.Size = new System.Drawing.Size(66, 25);
		this.cbscalemode.TabIndex = 20;
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(229, 49);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(54, 17);
		this.label7.TabIndex = 19;
		this.label7.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_内部分辨率放大;
		this.chkTTY.AutoSize = true;
		this.chkTTY.Location = new System.Drawing.Point(334, 17);
		this.chkTTY.Name = "chkTTY";
		this.chkTTY.Size = new System.Drawing.Size(71, 21);
		this.chkTTY.TabIndex = 18;
		this.chkTTY.Text = "TTY log";
		this.chkTTY.UseVisualStyleBackColor = true;
		this.chkcpu.AutoSize = true;
		this.chkcpu.Location = new System.Drawing.Point(250, 18);
		this.chkcpu.Name = "chkcpu";
		this.chkcpu.Size = new System.Drawing.Size(74, 21);
		this.chkcpu.TabIndex = 17;
		this.chkcpu.Text = "CPU log";
		this.chkcpu.UseVisualStyleBackColor = true;
		this.chkbios.AutoSize = true;
		this.chkbios.Location = new System.Drawing.Point(156, 18);
		this.chkbios.Name = "chkbios";
		this.chkbios.Size = new System.Drawing.Size(75, 21);
		this.chkbios.TabIndex = 16;
		this.chkbios.Text = "Bios log";
		this.chkbios.UseVisualStyleBackColor = true;
		this.tbcylesfix.Location = new System.Drawing.Point(331, 74);
		this.tbcylesfix.Name = "tbcylesfix";
		this.tbcylesfix.Size = new System.Drawing.Size(66, 23);
		this.tbcylesfix.TabIndex = 15;
		this.tbcylesfix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(edtxt_KeyPress);
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(229, 78);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(55, 17);
		this.label9.TabIndex = 14;
		this.label9.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_cyles;
		this.tbframeidle.Location = new System.Drawing.Point(331, 103);
		this.tbframeidle.Name = "tbframeidle";
		this.tbframeidle.Size = new System.Drawing.Size(66, 23);
		this.tbframeidle.TabIndex = 13;
		this.tbframeidle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(edtxt_KeyPress);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(229, 107);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(72, 17);
		this.label8.TabIndex = 12;
		this.label8.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_limit;
		this.tbaudiobuffer.Location = new System.Drawing.Point(116, 104);
		this.tbaudiobuffer.Name = "tbaudiobuffer";
		this.tbaudiobuffer.Size = new System.Drawing.Size(96, 23);
		this.tbaudiobuffer.TabIndex = 10;
		this.tbaudiobuffer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(edtxt_KeyPress);
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(16, 109);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(102, 17);
		this.label6.TabIndex = 9;
		this.label6.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_audio;
		this.tbframeskip.Location = new System.Drawing.Point(331, 134);
		this.tbframeskip.Name = "tbframeskip";
		this.tbframeskip.Size = new System.Drawing.Size(66, 23);
		this.tbframeskip.TabIndex = 8;
		this.tbframeskip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(edtxt_KeyPress);
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(229, 137);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(72, 17);
		this.label5.TabIndex = 7;
		this.label5.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_fsk;
		this.cbmsaa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbmsaa.FormattingEnabled = true;
		this.cbmsaa.Items.AddRange(new object[5] { "None MSAA", "4xMSAA", "6xMSAA", "8xMSAA", "16xMSAA" });
		this.cbmsaa.Location = new System.Drawing.Point(116, 133);
		this.cbmsaa.Name = "cbmsaa";
		this.cbmsaa.Size = new System.Drawing.Size(96, 25);
		this.cbmsaa.TabIndex = 6;
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(16, 136);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(94, 17);
		this.label4.TabIndex = 5;
		this.label4.Text = "OpenGL MSAA";
		this.tbcputicks.Location = new System.Drawing.Point(116, 75);
		this.tbcputicks.Name = "tbcputicks";
		this.tbcputicks.Size = new System.Drawing.Size(96, 23);
		this.tbcputicks.TabIndex = 4;
		this.tbcputicks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(edtxt_KeyPress);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(16, 78);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(65, 17);
		this.label3.TabIndex = 3;
		this.label3.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_CPUt;
		this.tbbuscycles.Location = new System.Drawing.Point(116, 46);
		this.tbbuscycles.Name = "tbbuscycles";
		this.tbbuscycles.Size = new System.Drawing.Size(96, 23);
		this.tbbuscycles.TabIndex = 2;
		this.tbbuscycles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(edtxt_KeyPress);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(16, 49);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(62, 17);
		this.label2.TabIndex = 1;
		this.label2.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_bt;
		this.cbconsole.AutoSize = true;
		this.cbconsole.Location = new System.Drawing.Point(16, 18);
		this.cbconsole.Name = "cbconsole";
		this.cbconsole.Size = new System.Drawing.Size(115, 21);
		this.cbconsole.TabIndex = 0;
		this.cbconsole.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_con;
		this.cbconsole.UseVisualStyleBackColor = true;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(13, 193);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(37, 17);
		this.label1.TabIndex = 3;
		this.label1.Text = "BIOS";
		this.cbbios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbbios.FormattingEnabled = true;
		this.cbbios.Location = new System.Drawing.Point(74, 190);
		this.cbbios.Name = "cbbios";
		this.cbbios.Size = new System.Drawing.Size(141, 25);
		this.cbbios.TabIndex = 4;
		this.btndel.Location = new System.Drawing.Point(241, 267);
		this.btndel.Name = "btndel";
		this.btndel.Size = new System.Drawing.Size(101, 27);
		this.btndel.TabIndex = 5;
		this.btndel.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_gbs;
		this.btndel.UseVisualStyleBackColor = true;
		this.btndel.Click += new System.EventHandler(btndel_Click);
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(230, 193);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(32, 17);
		this.label10.TabIndex = 6;
		this.label10.Text = "CPU";
		this.cbcpumode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbcpumode.FormattingEnabled = true;
		this.cbcpumode.Items.AddRange(new object[2]
		{
			ScePSX.Properties.Resources.Form_Set_InitializeComponent_性能优化模式,
			ScePSX.Properties.Resources.Form_Set_InitializeComponent_完整指令模式
		});
		this.cbcpumode.Location = new System.Drawing.Point(309, 190);
		this.cbcpumode.Name = "cbcpumode";
		this.cbcpumode.Size = new System.Drawing.Size(109, 25);
		this.cbcpumode.TabIndex = 7;
		this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label11.Location = new System.Drawing.Point(17, 270);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(211, 23);
		this.label11.TabIndex = 8;
		this.label11.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_不清楚作用的设置尽量不要修改;
		this.label12.AutoSize = true;
		this.label12.Location = new System.Drawing.Point(13, 231);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(33, 17);
		this.label12.TabIndex = 9;
		this.label12.Text = "GPU";
		this.cbgpu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbgpu.Enabled = false;
		this.cbgpu.FormattingEnabled = true;
		this.cbgpu.Items.AddRange(new object[3] { "software", "OpenGL", "Vulkan" });
		this.cbgpu.Location = new System.Drawing.Point(74, 227);
		this.cbgpu.Name = "cbgpu";
		this.cbgpu.Size = new System.Drawing.Size(141, 25);
		this.cbgpu.TabIndex = 10;
		this.label13.AutoSize = true;
		this.label13.Location = new System.Drawing.Point(230, 231);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(58, 17);
		this.label13.TabIndex = 11;
		this.label13.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_GPU分辨率;
		this.cbgpures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbgpures.Enabled = false;
		this.cbgpures.FormattingEnabled = true;
		this.cbgpures.Items.AddRange(new object[10]
		{
			ScePSX.Properties.Resources.Form_Set_InitializeComponent_自适应,
			"1x",
			"2x",
			"3x(720P)",
			"4x",
			"5x(1080P)",
			"6x(1440P)",
			"7x",
			"8x",
			"9x(4K)"
		});
		this.cbgpures.Location = new System.Drawing.Point(309, 227);
		this.cbgpures.Name = "cbgpures";
		this.cbgpures.Size = new System.Drawing.Size(109, 25);
		this.cbgpures.TabIndex = 12;
		this.chkrealcolor.AutoSize = true;
		this.chkrealcolor.Location = new System.Drawing.Point(15, 266);
		this.chkrealcolor.Name = "chkrealcolor";
		this.chkrealcolor.Size = new System.Drawing.Size(89, 21);
		this.chkrealcolor.TabIndex = 13;
		this.chkrealcolor.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_真彩色渲染;
		this.chkrealcolor.UseVisualStyleBackColor = true;
		this.chkrealcolor.Visible = false;
		this.chkpgxp.AutoSize = true;
		this.chkpgxp.Location = new System.Drawing.Point(126, 266);
		this.chkpgxp.Name = "chkpgxp";
		this.chkpgxp.Size = new System.Drawing.Size(123, 21);
		this.chkpgxp.TabIndex = 14;
		this.chkpgxp.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_PGXP几何校正;
		this.chkpgxp.UseVisualStyleBackColor = true;
		this.chkpgxp.Visible = false;
		this.chkpgxpt.AutoSize = true;
		this.chkpgxpt.Location = new System.Drawing.Point(250, 266);
		this.chkpgxpt.Name = "chkpgxpt";
		this.chkpgxpt.Size = new System.Drawing.Size(112, 21);
		this.chkpgxpt.TabIndex = 15;
		this.chkpgxpt.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_透视校正;
		this.chkpgxpt.UseVisualStyleBackColor = true;
		this.chkpgxpt.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(435, 311);
		base.Controls.Add(this.chkpgxpt);
		base.Controls.Add(this.chkpgxp);
		base.Controls.Add(this.chkrealcolor);
		base.Controls.Add(this.cbgpures);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.cbgpu);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.cbcpumode);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.btndel);
		base.Controls.Add(this.cbbios);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.btnsave);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "Form_Set";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = ScePSX.Properties.Resources.Form_Set_InitializeComponent_设置;
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
