using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using HexBoxControl;
using ScePSX.Properties;

namespace ScePSX.UI;

public class Form_Mem : Form
{
	private const long PSX_BASE = 2147483648L;

	private byte[] blankdata = new byte[1024];

	private MemorySearch memsearch;

	private static List<(int Address, object Value)> SearchResults = new List<(int, object)>();

	private IContainer components;

	private DataGridView ml;

	private SplitContainer splitContainer1;

	private GroupBox gbst;

	private RadioButton rbfloat;

	private RadioButton rbDword;

	private RadioButton rbWord;

	private RadioButton rbbyte;

	private Label labse;

	private Label label2;

	private Button btns;

	private Button btnr;

	private TextBox findb;

	private DataGridViewTextBoxColumn address;

	private DataGridViewTextBoxColumn val;

	private Button btngo;

	private TextBox tbgoto;

	private Label label1;

	private Button btnupd;

	private CheckBox chkupd;

	private HexBox HexBox;

	private ComboBox CboEncode;

	private ComboBox CboView;

	public unsafe Form_Mem()
	{
		InitializeComponent();
		ComboBox.ObjectCollection items = CboView.Items;
		object[] names = Enum.GetNames(typeof(HexBoxViewMode));
		items.AddRange(names);
		CboView.SelectedIndex = 2;
		CboEncode.Items.AddRange(new object[3]
		{
			new AnsiCharConvertor(),
			new AsciiCharConvertor(),
			new Utf8CharConvertor()
		});
		CboEncode.SelectedIndex = 0;
		HexBox.ResetOffset = false;
		HexBox.AddressOffset = 2147483648L;
		if (FrmMain.Core != null)
		{
			HexBox.Dump = ConvertBytePointerToByteArray(FrmMain.Core.PsxBus.ramPtr, 2097152);
		}
		else
		{
			HexBox.Dump = blankdata;
		}
		updateml();
		Timer timer = new Timer();
		timer.Interval = 1000;
		timer.Tick += updtimer;
		timer.Start();
	}

	private unsafe byte[] ConvertBytePointerToByteArray(byte* ptr, int length)
	{
		byte[] array = new byte[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = ptr[i];
		}
		return array;
	}

	private void CboView_SelectedIndexChanged(object sender, EventArgs e)
	{
		Enum.TryParse<HexBoxViewMode>(CboView.SelectedItem.ToString(), out var result);
		HexBox.ViewMode = result;
	}

	private void CboEncode_SelectedIndexChanged(object sender, EventArgs e)
	{
		HexBox.CharConverter = CboEncode.SelectedItem as ICharConverter;
	}

	private void tbgoto_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			btngo_Click(sender, e);
		}
	}

	private unsafe void updtimer(object sender, EventArgs e)
	{
		if (chkupd.Checked && FrmMain.Core != null)
		{
			HexBox.Dump = ConvertBytePointerToByteArray(FrmMain.Core.PsxBus.ramPtr, 2097152);
		}
	}

	private unsafe void btnupd_Click(object sender, EventArgs e)
	{
		if (FrmMain.Core != null)
		{
			HexBox.Dump = ConvertBytePointerToByteArray(FrmMain.Core.PsxBus.ramPtr, 2097152);
		}
	}

	private unsafe void HexBox_Edited(object sender, HexBoxEditEventArgs e)
	{
		if (FrmMain.Core != null && e.NewValue != e.OldValue)
		{
			FrmMain.Core.PsxBus.ramPtr[e.Offset] = (byte)e.NewValue;
		}
	}

	private void btngo_Click(object sender, EventArgs e)
	{
		long num = 0L;
		try
		{
			num = Convert.ToInt32(tbgoto.Text, 16);
		}
		catch
		{
			return;
		}
		if (num < 2147483648u)
		{
			num += 2147483648u;
		}
		HexBox.ScrollTo(num);
	}

	private void ml_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
	}

	private void ml_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex <= SearchResults.Count)
		{
			long pos = SearchResults[e.RowIndex].Address + 2147483648u;
			HexBox.ScrollTo(pos);
		}
	}

	private unsafe void ml_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		if (ml.Columns[e.ColumnIndex].Name == "val")
		{
			SearchResults[e.RowIndex] = (SearchResults[e.RowIndex].Address, ml.Rows[e.RowIndex].Cells[1].Value);
			uint num = uint.Parse(SearchResults[e.RowIndex].Value.ToString());
			uint item = (uint)SearchResults[e.RowIndex].Address;
			item = FrmMain.Core.PsxBus.GetMask(item);
			if (num < 255)
			{
				FrmMain.Core.PsxBus.write(item & 0x1FFFFF, (byte)num, FrmMain.Core.PsxBus.ramPtr);
			}
			else if (num < 65535)
			{
				FrmMain.Core.PsxBus.write(item & 0x1FFFFF, (ushort)num, FrmMain.Core.PsxBus.ramPtr);
			}
			else
			{
				FrmMain.Core.PsxBus.write(item & 0x1FFFFF, num, FrmMain.Core.PsxBus.ramPtr);
			}
		}
	}

	private void findb_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private unsafe void btnr_Click(object sender, EventArgs e)
	{
		if (FrmMain.Core != null)
		{
			memsearch = new MemorySearch(ConvertBytePointerToByteArray(FrmMain.Core.PsxBus.ramPtr, 2097152));
			SearchResults.Clear();
			updateml();
		}
	}

	private unsafe void btns_Click(object sender, EventArgs e)
	{
		if (FrmMain.Core == null)
		{
			return;
		}
		if (memsearch == null)
		{
			memsearch = new MemorySearch(ConvertBytePointerToByteArray(FrmMain.Core.PsxBus.ramPtr, 2097152));
		}
		else
		{
			memsearch.UpdateData(ConvertBytePointerToByteArray(FrmMain.Core.PsxBus.ramPtr, 2097152));
		}
		if (rbbyte.Checked)
		{
			if (!byte.TryParse(findb.Text, out var result))
			{
				return;
			}
			memsearch.SearchByte(result);
		}
		else if (rbWord.Checked)
		{
			if (!ushort.TryParse(findb.Text, out var result2))
			{
				return;
			}
			memsearch.SearchWord(result2);
		}
		else if (rbDword.Checked)
		{
			if (!uint.TryParse(findb.Text, out var result3))
			{
				return;
			}
			memsearch.SearchDword(result3);
		}
		else if (rbfloat.Checked)
		{
			if (!float.TryParse(findb.Text, out var result4))
			{
				return;
			}
			memsearch.SearchFloat(result4);
		}
		SearchResults = memsearch.GetResults();
		updateml();
	}

	private void updateml()
	{
		labse.Text = $"{Resources.Form_Mem_updateml_搜索到} {SearchResults.Count} {Resources.Form_Mem_updateml_个地址只显示前500个}";
		ml.Rows.Clear();
		for (int i = 0; i < SearchResults.Count && i < 500; i++)
		{
			ml.Rows.Add((2147483648u + SearchResults[i].Address).ToString("X8"), SearchResults[i].Value);
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
		HexBoxControl.AnsiCharConvertor charConverter = new HexBoxControl.AnsiCharConvertor();
		this.ml = new System.Windows.Forms.DataGridView();
		this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.val = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.CboEncode = new System.Windows.Forms.ComboBox();
		this.CboView = new System.Windows.Forms.ComboBox();
		this.HexBox = new HexBoxControl.HexBox();
		this.btnupd = new System.Windows.Forms.Button();
		this.chkupd = new System.Windows.Forms.CheckBox();
		this.btngo = new System.Windows.Forms.Button();
		this.tbgoto = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.btns = new System.Windows.Forms.Button();
		this.btnr = new System.Windows.Forms.Button();
		this.findb = new System.Windows.Forms.TextBox();
		this.gbst = new System.Windows.Forms.GroupBox();
		this.rbfloat = new System.Windows.Forms.RadioButton();
		this.rbDword = new System.Windows.Forms.RadioButton();
		this.rbWord = new System.Windows.Forms.RadioButton();
		this.rbbyte = new System.Windows.Forms.RadioButton();
		this.labse = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.ml).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.gbst.SuspendLayout();
		base.SuspendLayout();
		this.ml.AllowUserToAddRows = false;
		this.ml.AllowUserToDeleteRows = false;
		this.ml.AllowUserToResizeRows = false;
		this.ml.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.ml.Columns.AddRange(this.address, this.val);
		this.ml.Location = new System.Drawing.Point(7, 214);
		this.ml.MultiSelect = false;
		this.ml.Name = "ml";
		this.ml.RowHeadersVisible = false;
		this.ml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.ml.ShowCellErrors = false;
		this.ml.ShowCellToolTips = false;
		this.ml.ShowEditingIcon = false;
		this.ml.ShowRowErrors = false;
		this.ml.Size = new System.Drawing.Size(290, 306);
		this.ml.TabIndex = 33;
		this.ml.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(ml_CellDoubleClick);
		this.ml.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(ml_CellEndEdit);
		this.address.HeaderText = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_地址;
		this.address.MinimumWidth = 160;
		this.address.Name = "address";
		this.address.ReadOnly = true;
		this.address.Width = 160;
		this.val.HeaderText = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_数值;
		this.val.MinimumWidth = 100;
		this.val.Name = "val";
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.Location = new System.Drawing.Point(0, 0);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.CboEncode);
		this.splitContainer1.Panel1.Controls.Add(this.CboView);
		this.splitContainer1.Panel1.Controls.Add(this.HexBox);
		this.splitContainer1.Panel1.Controls.Add(this.btnupd);
		this.splitContainer1.Panel1.Controls.Add(this.chkupd);
		this.splitContainer1.Panel1.Controls.Add(this.btngo);
		this.splitContainer1.Panel1.Controls.Add(this.tbgoto);
		this.splitContainer1.Panel1.Controls.Add(this.label1);
		this.splitContainer1.Panel2.Controls.Add(this.label2);
		this.splitContainer1.Panel2.Controls.Add(this.btns);
		this.splitContainer1.Panel2.Controls.Add(this.btnr);
		this.splitContainer1.Panel2.Controls.Add(this.findb);
		this.splitContainer1.Panel2.Controls.Add(this.gbst);
		this.splitContainer1.Panel2.Controls.Add(this.labse);
		this.splitContainer1.Panel2.Controls.Add(this.ml);
		this.splitContainer1.Size = new System.Drawing.Size(897, 532);
		this.splitContainer1.SplitterDistance = 590;
		this.splitContainer1.TabIndex = 27;
		this.CboEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.CboEncode.FormattingEnabled = true;
		this.CboEncode.Location = new System.Drawing.Point(341, 5);
		this.CboEncode.Name = "CboEncode";
		this.CboEncode.Size = new System.Drawing.Size(69, 25);
		this.CboEncode.TabIndex = 8;
		this.CboEncode.SelectedIndexChanged += new System.EventHandler(CboEncode_SelectedIndexChanged);
		this.CboView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.CboView.FormattingEnabled = true;
		this.CboView.Location = new System.Drawing.Point(251, 5);
		this.CboView.Name = "CboView";
		this.CboView.Size = new System.Drawing.Size(84, 25);
		this.CboView.TabIndex = 7;
		this.CboView.SelectedIndexChanged += new System.EventHandler(CboView_SelectedIndexChanged);
		this.HexBox.AddressOffset = 0L;
		this.HexBox.CharConverter = charConverter;
		this.HexBox.Columns = 16;
		this.HexBox.ColumnsAuto = false;
		this.HexBox.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.HexBox.Dump = null;
		this.HexBox.Font = new System.Drawing.Font("Tahoma", 10.5f);
		this.HexBox.Location = new System.Drawing.Point(0, 34);
		this.HexBox.Name = "HexBox";
		this.HexBox.ResetOffset = false;
		this.HexBox.Size = new System.Drawing.Size(590, 498);
		this.HexBox.TabIndex = 6;
		this.HexBox.ViewMode = HexBoxControl.HexBoxViewMode.BytesAscii;
		this.HexBox.Edited += new HexBoxControl.HexBoxEditEventHandler(HexBox_Edited);
		this.btnupd.Location = new System.Drawing.Point(497, 5);
		this.btnupd.Name = "btnupd";
		this.btnupd.Size = new System.Drawing.Size(70, 23);
		this.btnupd.TabIndex = 5;
		this.btnupd.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_刷新;
		this.btnupd.UseVisualStyleBackColor = true;
		this.btnupd.Click += new System.EventHandler(btnupd_Click);
		this.chkupd.AutoSize = true;
		this.chkupd.Location = new System.Drawing.Point(416, 8);
		this.chkupd.Name = "chkupd";
		this.chkupd.Size = new System.Drawing.Size(75, 21);
		this.chkupd.TabIndex = 4;
		this.chkupd.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_自动刷新;
		this.chkupd.UseVisualStyleBackColor = true;
		this.btngo.Location = new System.Drawing.Point(162, 5);
		this.btngo.Name = "btngo";
		this.btngo.Size = new System.Drawing.Size(75, 23);
		this.btngo.TabIndex = 3;
		this.btngo.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_前往地址;
		this.btngo.UseVisualStyleBackColor = true;
		this.btngo.Click += new System.EventHandler(btngo_Click);
		this.tbgoto.Location = new System.Drawing.Point(32, 5);
		this.tbgoto.Name = "tbgoto";
		this.tbgoto.Size = new System.Drawing.Size(119, 23);
		this.tbgoto.TabIndex = 2;
		this.tbgoto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbgoto_KeyPress);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(21, 17);
		this.label1.TabIndex = 1;
		this.label1.Text = "0x";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13f, System.Drawing.FontStyle.Bold);
		this.label2.Location = new System.Drawing.Point(8, 12);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(102, 25);
		this.label2.TabIndex = 43;
		this.label2.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_内存搜索;
		this.btns.Location = new System.Drawing.Point(212, 44);
		this.btns.Name = "btns";
		this.btns.Size = new System.Drawing.Size(75, 26);
		this.btns.TabIndex = 42;
		this.btns.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_搜索;
		this.btns.UseVisualStyleBackColor = true;
		this.btns.Click += new System.EventHandler(btns_Click);
		this.btnr.Location = new System.Drawing.Point(212, 12);
		this.btnr.Name = "btnr";
		this.btnr.Size = new System.Drawing.Size(75, 23);
		this.btnr.TabIndex = 41;
		this.btnr.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_重置;
		this.btnr.UseVisualStyleBackColor = true;
		this.btnr.Click += new System.EventHandler(btnr_Click);
		this.findb.Location = new System.Drawing.Point(13, 45);
		this.findb.Name = "findb";
		this.findb.Size = new System.Drawing.Size(186, 23);
		this.findb.TabIndex = 40;
		this.findb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(findb_KeyPress);
		this.gbst.Controls.Add(this.rbfloat);
		this.gbst.Controls.Add(this.rbDword);
		this.gbst.Controls.Add(this.rbWord);
		this.gbst.Controls.Add(this.rbbyte);
		this.gbst.Location = new System.Drawing.Point(8, 80);
		this.gbst.Name = "gbst";
		this.gbst.Size = new System.Drawing.Size(289, 100);
		this.gbst.TabIndex = 39;
		this.gbst.TabStop = false;
		this.gbst.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_搜索类型;
		this.rbfloat.AutoSize = true;
		this.rbfloat.Location = new System.Drawing.Point(161, 59);
		this.rbfloat.Name = "rbfloat";
		this.rbfloat.Size = new System.Drawing.Size(86, 21);
		this.rbfloat.TabIndex = 42;
		this.rbfloat.TabStop = true;
		this.rbfloat.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_浮点Float;
		this.rbfloat.UseVisualStyleBackColor = true;
		this.rbDword.AutoSize = true;
		this.rbDword.Location = new System.Drawing.Point(37, 59);
		this.rbDword.Name = "rbDword";
		this.rbDword.Size = new System.Drawing.Size(106, 21);
		this.rbDword.TabIndex = 41;
		this.rbDword.TabStop = true;
		this.rbDword.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_双字DWORD;
		this.rbDword.UseVisualStyleBackColor = true;
		this.rbWord.AutoSize = true;
		this.rbWord.Location = new System.Drawing.Point(161, 32);
		this.rbWord.Name = "rbWord";
		this.rbWord.Size = new System.Drawing.Size(85, 21);
		this.rbWord.TabIndex = 40;
		this.rbWord.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_字WORD;
		this.rbWord.UseVisualStyleBackColor = true;
		this.rbbyte.AutoSize = true;
		this.rbbyte.Checked = true;
		this.rbbyte.Location = new System.Drawing.Point(36, 32);
		this.rbbyte.Name = "rbbyte";
		this.rbbyte.Size = new System.Drawing.Size(83, 21);
		this.rbbyte.TabIndex = 39;
		this.rbbyte.TabStop = true;
		this.rbbyte.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_字节Byte;
		this.rbbyte.UseVisualStyleBackColor = true;
		this.labse.AutoSize = true;
		this.labse.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5f, System.Drawing.FontStyle.Bold);
		this.labse.Location = new System.Drawing.Point(7, 191);
		this.labse.Name = "labse";
		this.labse.Size = new System.Drawing.Size(225, 19);
		this.labse.TabIndex = 34;
		this.labse.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_搜索到0个地址只显示前500个;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(897, 532);
		base.Controls.Add(this.splitContainer1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "Form_Mem";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = ScePSX.Properties.Resources.Form_Mem_InitializeComponent_内存编辑;
		((System.ComponentModel.ISupportInitialize)this.ml).EndInit();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		this.gbst.ResumeLayout(false);
		this.gbst.PerformLayout();
		base.ResumeLayout(false);
	}
}
