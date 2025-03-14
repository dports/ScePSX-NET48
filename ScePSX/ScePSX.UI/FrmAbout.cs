using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ScePSX.Properties;

namespace ScePSX.UI;

public class FrmAbout : Form
{
	private IContainer components;

	private Label labver;

	private Label label2;

	private TextBox textBox1;

	private Label label3;

	private LinkLabel linkLabel1;

	public FrmAbout()
	{
		InitializeComponent();
		labver.Text = FrmMain.version;
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
		this.labver = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		base.SuspendLayout();
		this.labver.AutoSize = true;
		this.labver.Font = new System.Drawing.Font("Microsoft YaHei UI", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.labver.Location = new System.Drawing.Point(26, 21);
		this.labver.Name = "labver";
		this.labver.Size = new System.Drawing.Size(150, 22);
		this.labver.TabIndex = 0;
		this.labver.Text = "ScePSX Beta 0.05";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(26, 141);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(56, 17);
		this.label2.TabIndex = 1;
		this.label2.Text = ScePSX.Properties.Resources.FrmAbout_InitializeComponent_维护者;
		this.textBox1.Location = new System.Drawing.Point(34, 161);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.ReadOnly = true;
		this.textBox1.Size = new System.Drawing.Size(254, 58);
		this.textBox1.TabIndex = 2;
		this.textBox1.Text = "unknowall - sgfree@hotmail.com";
		this.label3.Location = new System.Drawing.Point(34, 53);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(350, 56);
		this.label3.TabIndex = 3;
		this.label3.Text = ScePSX.Properties.Resources.FrmAbout_InitializeComponent_read + "\r\n\r\n" + ScePSX.Properties.Resources.FrmAbout_InitializeComponent_read2 + "\r\n";
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Location = new System.Drawing.Point(35, 111);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(225, 17);
		this.linkLabel1.TabIndex = 4;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "https://github.com/unknowall/ScePSX";
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(318, 239);
		base.Controls.Add(this.linkLabel1);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.labver);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "FrmAbout";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = ScePSX.Properties.Resources.FrmAbout_InitializeComponent_关于;
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
