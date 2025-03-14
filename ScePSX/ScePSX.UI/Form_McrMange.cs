using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ScePSX.Properties;

namespace ScePSX.UI;

public class Form_McrMange : Form
{
	private MemCardMange card1;

	private MemCardMange card2;

	private ImageList imageList1;

	private ImageList imageList2;

	private IContainer components;

	private ComboBox cbsave1;

	private ComboBox cbsave2;

	private ListView lv1;

	private Button move1to2;

	private Button move2to1;

	private Button del1;

	private Button out1;

	private Button save1;

	private Button save2;

	private Button out2;

	private Button del2;

	private ColumnHeader GameIcon;

	private ColumnHeader GameName;

	private ColumnHeader ID;

	private ListView lv2;

	private ColumnHeader columnHeader1;

	private ColumnHeader columnHeader2;

	private ColumnHeader columnHeader3;

	private Button copy2to1;

	private Button copy1to2;

	private Button btnimport1;

	private Button btnimport2;

	public Form_McrMange()
	{
		InitializeComponent();
	}

	public Form_McrMange(string id)
		: this()
	{
		card1 = new MemCardMange("./Save/" + id + ".dat");
		card2 = new MemCardMange("./Save/MemCard2.dat");
		InitializeListView();
		FillListView(lv1, card1, imageList1);
		FillListView(lv2, card2, imageList2);
		DirectoryInfo directoryInfo = new DirectoryInfo("./Save");
		if (!directoryInfo.Exists)
		{
			return;
		}
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			if (Path.GetExtension(fileInfo.Name) == ".dat")
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.Name);
				cbsave1.Items.Add(fileNameWithoutExtension);
				cbsave2.Items.Add(fileNameWithoutExtension);
				if (fileNameWithoutExtension == id)
				{
					cbsave1.SelectedIndex = cbsave1.Items.Count - 1;
				}
				if (fileNameWithoutExtension == "MemCard2")
				{
					cbsave2.SelectedIndex = cbsave2.Items.Count - 1;
				}
			}
		}
	}

	private void InitializeListView()
	{
		imageList1 = new ImageList();
		imageList1.ImageSize = new Size(32, 32);
		lv1.SmallImageList = imageList1;
		lv1.Columns.Clear();
		lv1.Columns.Add("", 50);
		lv1.Columns.Add("Name", 250);
		imageList2 = new ImageList();
		imageList2.ImageSize = new Size(32, 32);
		lv2.SmallImageList = imageList2;
		lv2.Columns.Clear();
		lv2.Columns.Add("", 50);
		lv2.Columns.Add("Name", 250);
		cbsave1.DropDownStyle = ComboBoxStyle.DropDownList;
		cbsave2.DropDownStyle = ComboBoxStyle.DropDownList;
		cbsave1.SelectedIndexChanged += Cbsave1_SelectedIndexChanged;
		cbsave2.SelectedIndexChanged += Cbsave2_SelectedIndexChanged;
	}

	private void FillListView(ListView listView, MemCardMange card, ImageList imageList)
	{
		listView.Items.Clear();
		imageList.Images.Clear();
		for (int i = 0; i < 15; i++)
		{
			MemCardMange.SlotData slotData = card.Slots[i];
			if (slotData != null && slotData.type == MemCardMange.SlotTypes.initial)
			{
				ListViewItem listViewItem = new ListViewItem(i.ToString());
				listViewItem.SubItems.Add(slotData.Name);
				Bitmap iconBitmap = slotData.GetIconBitmap(0);
				if (iconBitmap != null)
				{
					imageList.Images.Add(iconBitmap);
					listViewItem.ImageIndex = imageList.Images.Count - 1;
				}
				listView.Items.Add(listViewItem);
			}
		}
	}

	private void Cbsave1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cbsave1.SelectedIndex != -1)
		{
			string text = cbsave1.SelectedItem.ToString();
			if (cbsave2.SelectedItem != null && text == cbsave2.SelectedItem.ToString())
			{
				MessageBox.Show(Resources.Form_McrMange_Cbsave1_SelectedIndexChanged_同名, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				cbsave1.SelectedIndex = -1;
			}
			else
			{
				card1 = new MemCardMange("./Save/" + text + ".dat");
				FillListView(lv1, card1, imageList1);
			}
		}
	}

	private void Cbsave2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cbsave2.SelectedIndex != -1)
		{
			string text = cbsave2.SelectedItem.ToString();
			if (cbsave1.SelectedItem != null && text == cbsave1.SelectedItem.ToString())
			{
				MessageBox.Show(Resources.Form_McrMange_Cbsave1_SelectedIndexChanged_同名, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				cbsave2.SelectedIndex = -1;
			}
			else
			{
				card2 = new MemCardMange("./Save/" + text + ".dat");
				FillListView(lv2, card2, imageList2);
			}
		}
	}

	private void move1to2_Click(object sender, EventArgs e)
	{
		if (lv1.SelectedItems.Count != 0)
		{
			int slotNumber = int.Parse(lv1.SelectedItems[0].Text);
			byte[] saveBytes = card1.GetSaveBytes(slotNumber);
			if (card2.AddSaveBytes(slotNumber, saveBytes))
			{
				card1.DeleteSlot(slotNumber);
				FillListView(lv1, card1, imageList1);
				FillListView(lv2, card2, imageList2);
			}
			else
			{
				MessageBox.Show(Resources.Form_McrMange_move1to2_Click_空位, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void move2to1_Click(object sender, EventArgs e)
	{
		if (lv2.SelectedItems.Count != 0)
		{
			int slotNumber = int.Parse(lv2.SelectedItems[0].Text);
			byte[] saveBytes = card2.GetSaveBytes(slotNumber);
			if (card1.AddSaveBytes(slotNumber, saveBytes))
			{
				card2.DeleteSlot(slotNumber);
				FillListView(lv1, card1, imageList1);
				FillListView(lv2, card2, imageList2);
			}
			else
			{
				MessageBox.Show(Resources.Form_McrMange_move1to2_Click_空位, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void del1_Click(object sender, EventArgs e)
	{
		if (lv1.SelectedItems.Count != 0)
		{
			int slotNumber = int.Parse(lv1.SelectedItems[0].Text);
			card1.DeleteSlot(slotNumber);
			FillListView(lv1, card1, imageList1);
		}
	}

	private void out1_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Filter = "Memory Card (*.mcr)|*.mcr",
			FileName = "MemCard1.mcr"
		};
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			card1.SaveCard(saveFileDialog.FileName);
		}
	}

	private void save1_Click(object sender, EventArgs e)
	{
		string text = cbsave1.SelectedItem.ToString();
		card1.SaveCard("./Save/" + text + ".dat");
	}

	private void del2_Click(object sender, EventArgs e)
	{
		if (lv2.SelectedItems.Count != 0)
		{
			int slotNumber = int.Parse(lv2.SelectedItems[0].Text);
			card2.DeleteSlot(slotNumber);
			FillListView(lv2, card2, imageList2);
		}
	}

	private void out2_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Filter = "Memory Card (*.mcr)|*.mcr",
			FileName = "MemCard2.mcr"
		};
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			card2.SaveCard(saveFileDialog.FileName);
		}
	}

	private void save2_Click(object sender, EventArgs e)
	{
		string text = cbsave2.SelectedItem.ToString();
		card2.SaveCard("./Save/" + text + ".dat");
	}

	private void copy1to2_Click(object sender, EventArgs e)
	{
		if (lv1.SelectedItems.Count != 0)
		{
			int slotNumber = int.Parse(lv1.SelectedItems[0].Text);
			byte[] saveBytes = card1.GetSaveBytes(slotNumber);
			if (card2.AddSaveBytes(slotNumber, saveBytes))
			{
				FillListView(lv2, card2, imageList2);
			}
			else
			{
				MessageBox.Show(Resources.Form_McrMange_move1to2_Click_空位, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void copy2to1_Click(object sender, EventArgs e)
	{
		if (lv2.SelectedItems.Count != 0)
		{
			int slotNumber = int.Parse(lv2.SelectedItems[0].Text);
			byte[] saveBytes = card2.GetSaveBytes(slotNumber);
			if (card1.AddSaveBytes(slotNumber, saveBytes))
			{
				FillListView(lv1, card1, imageList1);
			}
			else
			{
				MessageBox.Show(Resources.Form_McrMange_move1to2_Click_空位, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void btnimport1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = "Memory Card (*.mcr.*.dat,*.mcd,&.mc)|*.mcr;*.dat;*.mcd;&.mc"
		};
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			MemCardMange memCardMange = new MemCardMange(openFileDialog.FileName);
			if (memCardMange != null)
			{
				card1 = memCardMange;
				FillListView(lv1, card1, imageList1);
			}
		}
	}

	private void btnimport2_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = "Memory Card (*.mcr.*.dat,*.mcd,&.mc)|*.mcr;*.dat;*.mcd;&.mc"
		};
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			MemCardMange memCardMange = new MemCardMange(openFileDialog.FileName);
			if (memCardMange != null)
			{
				card2 = memCardMange;
				FillListView(lv2, card2, imageList2);
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
		this.cbsave1 = new System.Windows.Forms.ComboBox();
		this.cbsave2 = new System.Windows.Forms.ComboBox();
		this.lv1 = new System.Windows.Forms.ListView();
		this.GameIcon = new System.Windows.Forms.ColumnHeader();
		this.ID = new System.Windows.Forms.ColumnHeader();
		this.GameName = new System.Windows.Forms.ColumnHeader();
		this.move1to2 = new System.Windows.Forms.Button();
		this.move2to1 = new System.Windows.Forms.Button();
		this.del1 = new System.Windows.Forms.Button();
		this.out1 = new System.Windows.Forms.Button();
		this.save1 = new System.Windows.Forms.Button();
		this.save2 = new System.Windows.Forms.Button();
		this.out2 = new System.Windows.Forms.Button();
		this.del2 = new System.Windows.Forms.Button();
		this.lv2 = new System.Windows.Forms.ListView();
		this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
		this.copy2to1 = new System.Windows.Forms.Button();
		this.copy1to2 = new System.Windows.Forms.Button();
		this.btnimport1 = new System.Windows.Forms.Button();
		this.btnimport2 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.cbsave1.FormattingEnabled = true;
		this.cbsave1.Location = new System.Drawing.Point(25, 12);
		this.cbsave1.Name = "cbsave1";
		this.cbsave1.Size = new System.Drawing.Size(274, 25);
		this.cbsave1.TabIndex = 0;
		this.cbsave2.FormattingEnabled = true;
		this.cbsave2.Location = new System.Drawing.Point(424, 12);
		this.cbsave2.Name = "cbsave2";
		this.cbsave2.Size = new System.Drawing.Size(274, 25);
		this.cbsave2.TabIndex = 1;
		this.lv1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.GameIcon, this.ID, this.GameName });
		this.lv1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.lv1.FullRowSelect = true;
		this.lv1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		this.lv1.LabelWrap = false;
		this.lv1.Location = new System.Drawing.Point(25, 43);
		this.lv1.MultiSelect = false;
		this.lv1.Name = "lv1";
		this.lv1.Size = new System.Drawing.Size(344, 374);
		this.lv1.TabIndex = 2;
		this.lv1.UseCompatibleStateImageBehavior = false;
		this.lv1.View = System.Windows.Forms.View.Details;
		this.GameIcon.Text = "";
		this.GameIcon.Width = 32;
		this.ID.Text = "ID";
		this.ID.Width = 80;
		this.GameName.Text = "Name";
		this.GameName.Width = 120;
		this.move1to2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Bold);
		this.move1to2.Location = new System.Drawing.Point(378, 109);
		this.move1to2.Name = "move1to2";
		this.move1to2.Size = new System.Drawing.Size(37, 32);
		this.move1to2.TabIndex = 4;
		this.move1to2.Text = ">>";
		this.move1to2.UseVisualStyleBackColor = true;
		this.move1to2.Click += new System.EventHandler(move1to2_Click);
		this.move2to1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Bold);
		this.move2to1.Location = new System.Drawing.Point(378, 165);
		this.move2to1.Name = "move2to1";
		this.move2to1.Size = new System.Drawing.Size(37, 32);
		this.move2to1.TabIndex = 5;
		this.move2to1.Text = "<<";
		this.move2to1.UseVisualStyleBackColor = true;
		this.move2to1.Click += new System.EventHandler(move2to1_Click);
		this.del1.Location = new System.Drawing.Point(23, 423);
		this.del1.Name = "del1";
		this.del1.Size = new System.Drawing.Size(73, 32);
		this.del1.TabIndex = 6;
		this.del1.Text = ScePSX.Properties.Resources.Form_McrMange_InitializeComponent_删除选中;
		this.del1.UseVisualStyleBackColor = true;
		this.del1.Click += new System.EventHandler(del1_Click);
		this.out1.Location = new System.Drawing.Point(105, 423);
		this.out1.Name = "out1";
		this.out1.Size = new System.Drawing.Size(73, 32);
		this.out1.TabIndex = 8;
		this.out1.Text = ScePSX.Properties.Resources.Form_McrMange_InitializeComponent_导出;
		this.out1.UseVisualStyleBackColor = true;
		this.out1.Click += new System.EventHandler(out1_Click);
		this.save1.Location = new System.Drawing.Point(187, 423);
		this.save1.Name = "save1";
		this.save1.Size = new System.Drawing.Size(73, 32);
		this.save1.TabIndex = 9;
		this.save1.Text = ScePSX.Properties.Resources.Form_McrMange_InitializeComponent_保存修改;
		this.save1.UseVisualStyleBackColor = true;
		this.save1.Click += new System.EventHandler(save1_Click);
		this.save2.Location = new System.Drawing.Point(695, 423);
		this.save2.Name = "save2";
		this.save2.Size = new System.Drawing.Size(73, 32);
		this.save2.TabIndex = 12;
		this.save2.Text = ScePSX.Properties.Resources.Form_McrMange_InitializeComponent_保存修改;
		this.save2.UseVisualStyleBackColor = true;
		this.save2.Click += new System.EventHandler(save2_Click);
		this.out2.Location = new System.Drawing.Point(613, 423);
		this.out2.Name = "out2";
		this.out2.Size = new System.Drawing.Size(73, 32);
		this.out2.TabIndex = 11;
		this.out2.Text = ScePSX.Properties.Resources.Form_McrMange_InitializeComponent_导出;
		this.out2.UseVisualStyleBackColor = true;
		this.out2.Click += new System.EventHandler(out2_Click);
		this.del2.Location = new System.Drawing.Point(531, 423);
		this.del2.Name = "del2";
		this.del2.Size = new System.Drawing.Size(73, 32);
		this.del2.TabIndex = 10;
		this.del2.Text = ScePSX.Properties.Resources.Form_McrMange_InitializeComponent_删除选中;
		this.del2.UseVisualStyleBackColor = true;
		this.del2.Click += new System.EventHandler(del2_Click);
		this.lv2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.columnHeader1, this.columnHeader2, this.columnHeader3 });
		this.lv2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.lv2.FullRowSelect = true;
		this.lv2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		this.lv2.LabelWrap = false;
		this.lv2.Location = new System.Drawing.Point(424, 43);
		this.lv2.MultiSelect = false;
		this.lv2.Name = "lv2";
		this.lv2.Size = new System.Drawing.Size(344, 374);
		this.lv2.TabIndex = 13;
		this.lv2.UseCompatibleStateImageBehavior = false;
		this.lv2.View = System.Windows.Forms.View.Details;
		this.columnHeader1.Text = "";
		this.columnHeader1.Width = 32;
		this.columnHeader2.Text = "ID";
		this.columnHeader2.Width = 80;
		this.columnHeader3.Text = "Name";
		this.columnHeader3.Width = 120;
		this.copy2to1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Bold);
		this.copy2to1.Location = new System.Drawing.Point(378, 275);
		this.copy2to1.Name = "copy2to1";
		this.copy2to1.Size = new System.Drawing.Size(37, 32);
		this.copy2to1.TabIndex = 15;
		this.copy2to1.Text = "<";
		this.copy2to1.UseVisualStyleBackColor = true;
		this.copy2to1.Click += new System.EventHandler(copy2to1_Click);
		this.copy1to2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Bold);
		this.copy1to2.Location = new System.Drawing.Point(378, 219);
		this.copy1to2.Name = "copy1to2";
		this.copy1to2.Size = new System.Drawing.Size(37, 32);
		this.copy1to2.TabIndex = 14;
		this.copy1to2.Text = ">";
		this.copy1to2.UseVisualStyleBackColor = true;
		this.copy1to2.Click += new System.EventHandler(copy1to2_Click);
		this.btnimport1.Location = new System.Drawing.Point(305, 10);
		this.btnimport1.Name = "btnimport1";
		this.btnimport1.Size = new System.Drawing.Size(64, 28);
		this.btnimport1.TabIndex = 16;
		this.btnimport1.Text = ScePSX.Properties.Resources.Form_McrMange_InitializeComponent_Import;
		this.btnimport1.UseVisualStyleBackColor = true;
		this.btnimport1.Click += new System.EventHandler(btnimport1_Click);
		this.btnimport2.Location = new System.Drawing.Point(704, 9);
		this.btnimport2.Name = "btnimport2";
		this.btnimport2.Size = new System.Drawing.Size(64, 28);
		this.btnimport2.TabIndex = 17;
		this.btnimport2.Text = ScePSX.Properties.Resources.Form_McrMange_InitializeComponent_Import;
		this.btnimport2.UseVisualStyleBackColor = true;
		this.btnimport2.Click += new System.EventHandler(btnimport2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(790, 467);
		base.Controls.Add(this.btnimport2);
		base.Controls.Add(this.btnimport1);
		base.Controls.Add(this.copy2to1);
		base.Controls.Add(this.copy1to2);
		base.Controls.Add(this.lv2);
		base.Controls.Add(this.save2);
		base.Controls.Add(this.out2);
		base.Controls.Add(this.del2);
		base.Controls.Add(this.save1);
		base.Controls.Add(this.out1);
		base.Controls.Add(this.del1);
		base.Controls.Add(this.move2to1);
		base.Controls.Add(this.move1to2);
		base.Controls.Add(this.lv1);
		base.Controls.Add(this.cbsave2);
		base.Controls.Add(this.cbsave1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "Form_McrMange";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = ScePSX.Properties.Resources.Form_McrMange_InitializeComponent_MemcardMange;
		base.ResumeLayout(false);
	}
}
