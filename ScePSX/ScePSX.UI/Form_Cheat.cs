using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ScePSX.Properties;

namespace ScePSX.UI;

public class Form_Cheat : Form
{
	public List<PSXCore.CheatCode> cheatCodes = new List<PSXCore.CheatCode>();

	private string DiskID;

	private IContainer components;

	private Button btnadd;

	private Button btndel;

	private TextBox ctb;

	private Label label1;

	private Button btnload;

	private Button btnimp;

	private Button btnsave;

	private Button btnapply;

	private ListView clb;

	public Form_Cheat(string id)
	{
		InitializeComponent();
		ctb.LostFocus += updatecodes;
		if (id == "")
		{
			btnsave.Enabled = false;
			btnload.Enabled = false;
			btnapply.Enabled = false;
		}
		DiskID = id;
		Text = "  " + DiskID + "  " + Resources.Form_Cheat_Form_Cheat_的金手指;
		btnload_Click(this, null);
		if (clb.Items.Count > 0)
		{
			clb.Items[0].Selected = true;
		}
	}

	private void btnadd_Click(object sender, EventArgs e)
	{
		clb.Items.Add(Resources.Form_Cheat_btnadd_Click_新建).SubItems.Add("");
	}

	private void btndel_Click(object sender, EventArgs e)
	{
		if (clb.SelectedItems.Count != 0)
		{
			clb.Items.Remove(clb.SelectedItems[0]);
			ctb.Clear();
		}
	}

	private void updatecodes(object sender, EventArgs e)
	{
		if (clb.SelectedItems.Count != 0)
		{
			clb.SelectedItems[0].SubItems[1].Text = ctb.Text;
		}
	}

	private void updateclbs()
	{
		ctb.Clear();
		clb.Items.Clear();
		foreach (PSXCore.CheatCode cheatCode in cheatCodes)
		{
			ListViewItem listViewItem = clb.Items.Add(cheatCode.Name);
			listViewItem.Checked = cheatCode.Active;
			string text = "";
			foreach (PSXCore.AddrItem item in cheatCode.Item)
			{
				text += $"{item.Address:X8} {item.Value:X4}\r\n";
			}
			listViewItem.SubItems.Add(text);
		}
	}

	private void btnload_Click(object sender, EventArgs e)
	{
		cheatCodes.Clear();
		string text = "./Cheats/" + DiskID + ".txt";
		if (File.Exists(text))
		{
			cheatCodes = PSXCore.ParseTextToCheatCodeList(text);
			updateclbs();
		}
	}

	private void btnimp_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "CheatCodes|*.txt;*.cht";
		openFileDialog.ShowDialog();
		if (File.Exists(openFileDialog.FileName) && !(openFileDialog.FileName == ""))
		{
			cheatCodes.Clear();
			try
			{
				cheatCodes = PSXCore.ParseTextToCheatCodeList(openFileDialog.FileName);
			}
			catch
			{
				return;
			}
			updateclbs();
		}
	}

	private string GetText()
	{
		string text = "";
		for (int i = 0; i < clb.Items.Count; i++)
		{
			ListViewItem listViewItem = clb.Items[i];
			text = text + "\r\n[" + listViewItem.Text + "]\r\n";
			text += "Active = ";
			text = ((!listViewItem.Checked) ? (text + "0\r\n") : (text + "1\r\n"));
			text += listViewItem.SubItems[1].Text;
		}
		return text;
	}

	private void btnapply_Click(object sender, EventArgs e)
	{
		if (FrmMain.Core != null)
		{
			btnsave_Click(sender, e);
			FrmMain.Core.LoadCheats();
		}
	}

	private void btnsave_Click(object sender, EventArgs e)
	{
		string path = "./Cheats/" + DiskID + ".txt";
		string text = GetText();
		File.WriteAllText(path, text);
	}

	private void clb_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (clb.SelectedItems.Count != 0)
		{
			ctb.Text = "";
			if (clb.SelectedItems[0].SubItems.Count >= 2)
			{
				ListViewItem.ListViewSubItem listViewSubItem = clb.SelectedItems[0].SubItems[1];
				ctb.Text += listViewSubItem.Text;
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
		this.btnadd = new System.Windows.Forms.Button();
		this.btndel = new System.Windows.Forms.Button();
		this.ctb = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.btnload = new System.Windows.Forms.Button();
		this.btnimp = new System.Windows.Forms.Button();
		this.btnsave = new System.Windows.Forms.Button();
		this.btnapply = new System.Windows.Forms.Button();
		this.clb = new System.Windows.Forms.ListView();
		base.SuspendLayout();
		this.btnadd.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.btnadd.Location = new System.Drawing.Point(12, 10);
		this.btnadd.Name = "btnadd";
		this.btnadd.Size = new System.Drawing.Size(57, 26);
		this.btnadd.TabIndex = 0;
		this.btnadd.Text = ScePSX.Properties.Resources.Form_Cheat_InitializeComponent_增加;
		this.btnadd.UseVisualStyleBackColor = true;
		this.btnadd.Click += new System.EventHandler(btnadd_Click);
		this.btndel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.btndel.Location = new System.Drawing.Point(75, 10);
		this.btndel.Name = "btndel";
		this.btndel.Size = new System.Drawing.Size(55, 26);
		this.btndel.TabIndex = 1;
		this.btndel.Text = ScePSX.Properties.Resources.Form_Cheat_InitializeComponent_删除;
		this.btndel.UseVisualStyleBackColor = true;
		this.btndel.Click += new System.EventHandler(btndel_Click);
		this.ctb.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.ctb.Location = new System.Drawing.Point(250, 41);
		this.ctb.Multiline = true;
		this.ctb.Name = "ctb";
		this.ctb.Size = new System.Drawing.Size(227, 310);
		this.ctb.TabIndex = 3;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.label1.Location = new System.Drawing.Point(250, 18);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(69, 19);
		this.label1.TabIndex = 4;
		this.label1.Text = ScePSX.Properties.Resources.Form_Cheat_InitializeComponent_地址代码;
		this.btnload.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.btnload.Location = new System.Drawing.Point(22, 361);
		this.btnload.Name = "btnload";
		this.btnload.Size = new System.Drawing.Size(65, 26);
		this.btnload.TabIndex = 5;
		this.btnload.Text = ScePSX.Properties.Resources.Form_Cheat_InitializeComponent_读取;
		this.btnload.UseVisualStyleBackColor = true;
		this.btnload.Click += new System.EventHandler(btnload_Click);
		this.btnimp.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.btnimp.Location = new System.Drawing.Point(162, 361);
		this.btnimp.Name = "btnimp";
		this.btnimp.Size = new System.Drawing.Size(64, 26);
		this.btnimp.TabIndex = 6;
		this.btnimp.Text = ScePSX.Properties.Resources.Form_Cheat_InitializeComponent_导入;
		this.btnimp.UseVisualStyleBackColor = true;
		this.btnimp.Click += new System.EventHandler(btnimp_Click);
		this.btnsave.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.btnsave.Location = new System.Drawing.Point(93, 361);
		this.btnsave.Name = "btnsave";
		this.btnsave.Size = new System.Drawing.Size(63, 26);
		this.btnsave.TabIndex = 7;
		this.btnsave.Text = ScePSX.Properties.Resources.Form_Cheat_InitializeComponent_保存;
		this.btnsave.UseVisualStyleBackColor = true;
		this.btnsave.Click += new System.EventHandler(btnsave_Click);
		this.btnapply.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.btnapply.Location = new System.Drawing.Point(356, 361);
		this.btnapply.Name = "btnapply";
		this.btnapply.Size = new System.Drawing.Size(121, 26);
		this.btnapply.TabIndex = 8;
		this.btnapply.Text = ScePSX.Properties.Resources.Form_Cheat_InitializeComponent_应用金手指;
		this.btnapply.UseVisualStyleBackColor = true;
		this.btnapply.Click += new System.EventHandler(btnapply_Click);
		this.clb.CheckBoxes = true;
		this.clb.Font = new System.Drawing.Font("Microsoft YaHei UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.clb.FullRowSelect = true;
		this.clb.LabelEdit = true;
		this.clb.Location = new System.Drawing.Point(12, 42);
		this.clb.MultiSelect = false;
		this.clb.Name = "clb";
		this.clb.Size = new System.Drawing.Size(223, 309);
		this.clb.TabIndex = 9;
		this.clb.UseCompatibleStateImageBehavior = false;
		this.clb.View = System.Windows.Forms.View.List;
		this.clb.SelectedIndexChanged += new System.EventHandler(clb_SelectedIndexChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(489, 400);
		base.Controls.Add(this.clb);
		base.Controls.Add(this.btnapply);
		base.Controls.Add(this.btnsave);
		base.Controls.Add(this.btnimp);
		base.Controls.Add(this.btnload);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.ctb);
		base.Controls.Add(this.btndel);
		base.Controls.Add(this.btnadd);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "Form_Cheat";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = ScePSX.Properties.Resources.Form_Cheat_InitializeComponent_金手指;
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
