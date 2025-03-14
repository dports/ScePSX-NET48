using System;
using System.Drawing;
using System.Windows.Forms;

namespace HexBoxControl;

public class HexBox : Control
{
	private int _HeaderLeft = 4;

	private int _HeaderTop = 2;

	private int _ColumnsDelim = 10;

	private int _CharWidth;

	private int _CharHeight;

	private int _AddressWidth;

	private int _DataCellWidth;

	private int _DataColums = 8;

	private byte[] _Dump;

	private int _Lines;

	private int _DataRows;

	private long _Offset;

	private bool _ColumnsAuto;

	private int _LineLength;

	private int _EditIndex = -1;

	private bool ResetViewByLoad = true;

	private long _AddressOffset;

	private HexBoxViewMode _ViewMode;

	private ICharConverter _CharConverter;

	private StringFormat _StringFormat;

	private VScrollBar _ScrollBar;

	private TextBox _Edit;

	public HexBoxViewMode ViewMode
	{
		get
		{
			return _ViewMode;
		}
		set
		{
			if (value != _ViewMode)
			{
				EndEditing();
				_ViewMode = value;
				_Edit.Width = 18 * GetCellBytes();
				_Edit.MaxLength = 2 * GetCellBytes();
				_Offset = 0L;
				Resume();
				ResumeScroll();
				Invalidate();
			}
		}
	}

	public int Columns
	{
		get
		{
			return _DataColums;
		}
		set
		{
			if (value > 0 && value != _DataColums)
			{
				_DataColums = value;
				EndEditing();
				Resume();
				ResumeScroll();
				Invalidate();
			}
		}
	}

	public long AddressOffset
	{
		get
		{
			return _AddressOffset;
		}
		set
		{
			_AddressOffset = value;
		}
	}

	public bool ResetOffset
	{
		get
		{
			return ResetViewByLoad;
		}
		set
		{
			ResetViewByLoad = value;
		}
	}

	public int Rows => _Lines;

	public int DisplayedRows => _DataRows;

	public byte[] Dump
	{
		get
		{
			return _Dump;
		}
		set
		{
			_Dump = value;
			if (ResetViewByLoad)
			{
				_Offset = 0L;
			}
			_EditIndex = -1;
			_Edit.Hide();
			Resume();
			ResumeScroll();
			Invalidate();
		}
	}

	public ICharConverter CharConverter
	{
		get
		{
			return _CharConverter;
		}
		set
		{
			if (value != null && value != _CharConverter)
			{
				_CharConverter = value;
				if (_ViewMode == HexBoxViewMode.BytesAscii)
				{
					Invalidate();
				}
			}
		}
	}

	public bool ColumnsAuto
	{
		get
		{
			return _ColumnsAuto;
		}
		set
		{
			if (value != _ColumnsAuto)
			{
				_ColumnsAuto = value;
				EndEditing();
				Resume();
				ResumeScroll();
				Invalidate();
			}
		}
	}

	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			if (value != base.Font)
			{
				EndEditing();
				base.Font = value;
				_Edit.Font = value;
				Resume();
				ResumeScroll();
				Invalidate();
			}
		}
	}

	public new bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			if (value != base.Enabled)
			{
				base.Enabled = value;
				EndEditing();
			}
		}
	}

	public event HexBoxEditEventHandler Edited;

	public HexBox()
	{
		_ViewMode = HexBoxViewMode.BytesAscii;
		_CharConverter = new AnsiCharConvertor();
		_StringFormat = new StringFormat(StringFormat.GenericTypographic);
		_StringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
		base.ClientSize = new Size(380, 198);
		_ScrollBar = new VScrollBar();
		_ScrollBar.Size = new Size(16, base.Height - 2);
		_ScrollBar.Location = new Point(base.Width - 17, 1);
		_ScrollBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		_ScrollBar.Scroll += OnScrolling;
		_ScrollBar.Enabled = false;
		base.Controls.Add(_ScrollBar);
		_Edit = new TextBox();
		_Edit.BorderStyle = BorderStyle.None;
		_Edit.Size = new Size(18, 18);
		_Edit.MaxLength = 2;
		_Edit.Font = Font;
		_Edit.ForeColor = Color.Green;
		_Edit.ContextMenuStrip = new ContextMenuStrip();
		_Edit.KeyPress += EditKeyPress;
		base.Controls.Add(_Edit);
		_Edit.Hide();
		SetStyle(ControlStyles.UserPaint, value: true);
		SetStyle(ControlStyles.DoubleBuffer, value: true);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		Resume();
	}

	public void Fill(int size, int value)
	{
		byte[] array = new byte[size * GetCellBytes()];
		if (_ViewMode == HexBoxViewMode.Words)
		{
			byte b = (byte)(value & 0xFF);
			byte b2 = (byte)(value >> 8);
			for (int i = 0; i < size; i++)
			{
				array[2 * i] = b;
				array[2 * i + 1] = b2;
			}
		}
		else
		{
			for (int j = 0; j < size; j++)
			{
				array[j] = (byte)value;
			}
		}
		Dump = array;
	}

	public void ScrollTo(long pos)
	{
		if (pos - _AddressOffset > Dump.Length || pos < 0)
		{
			return;
		}
		_Offset = pos - _AddressOffset;
		Resume();
		ResumeScroll();
		if (_Offset > 0)
		{
			int num = _Lines - _DataRows;
			if (num < _Offset / _LineLength)
			{
				EndEditing();
				_Offset = num * _LineLength;
				_ScrollBar.Value = num;
			}
		}
		Invalidate();
	}

	private void OnScrolling(object sender, ScrollEventArgs e)
	{
		Scroll();
	}

	private void EditKeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			EndEditing(apply: true);
			return;
		}
		switch (e.KeyChar)
		{
		case 'a':
		case 'Ф':
		case 'ф':
			e.KeyChar = 'A';
			break;
		case 'b':
		case 'И':
		case 'и':
			e.KeyChar = 'B';
			break;
		case 'c':
		case 'С':
		case 'с':
			e.KeyChar = 'C';
			break;
		case 'd':
		case 'В':
		case 'в':
			e.KeyChar = 'D';
			break;
		case 'e':
		case 'У':
		case 'у':
			e.KeyChar = 'E';
			break;
		case 'f':
		case 'А':
		case 'а':
			e.KeyChar = 'F';
			break;
		}
		e.Handled = "0123456789ABCDEF\b".IndexOf(e.KeyChar) == -1;
	}

	private Brush GetBrush(Color color)
	{
		return new SolidBrush(Enabled ? color : Color.LightGray);
	}

	private Pen GetPen(Color color)
	{
		return new Pen(Enabled ? color : Color.LightGray);
	}

	private int GetCellBytes()
	{
		if (_ViewMode != HexBoxViewMode.Words)
		{
			return 1;
		}
		return 2;
	}

	private int GetCellValue(int index)
	{
		int num = _Dump[index++];
		if (_ViewMode == HexBoxViewMode.Words && index < _Dump.Length)
		{
			num |= _Dump[index] << 8;
		}
		return num;
	}

	private void SetCellValue(int index, int value)
	{
		_Dump[index++] = (byte)(value & 0xFF);
		if (_ViewMode == HexBoxViewMode.Words && index < _Dump.Length)
		{
			_Dump[index] = (byte)(value >> 8);
		}
	}

	private Point GetCellPos(Point p)
	{
		int num = (p.X - (_HeaderLeft + _AddressWidth + _ColumnsDelim)) / _DataCellWidth;
		int num2 = (p.Y - (_HeaderTop + 4 + _CharHeight)) / _CharHeight;
		if (0 <= num && num < _DataColums && 0 <= num2 && num2 < _DataRows)
		{
			return new Point(num, num2);
		}
		return new Point(-1, -1);
	}

	private int GetCellIndex(Point p)
	{
		int num = (int)(_Offset + (p.Y * _DataColums + p.X) * GetCellBytes());
		if (num >= _Dump.Length)
		{
			return -1;
		}
		return num;
	}

	private void Resume()
	{
		SizeF sizeF = CreateGraphics().MeasureString("0", Font, 100, _StringFormat);
		_CharWidth = (int)sizeF.Width;
		_CharHeight = (int)sizeF.Height;
		_AddressWidth = 9 * _CharWidth;
		_DataCellWidth = (2 * GetCellBytes() + 1) * _CharWidth;
		_DataRows = (base.Height - (_HeaderTop + 4 + _CharHeight)) / _CharHeight;
		if (ColumnsAuto)
		{
			int num = 2 * _HeaderLeft + _AddressWidth + _ColumnsDelim + _ScrollBar.Width - _CharWidth;
			int num2 = _DataCellWidth;
			if (_ViewMode == HexBoxViewMode.BytesAscii)
			{
				num += _ColumnsDelim - _CharWidth;
				num2 += 2 * _CharWidth;
			}
			_DataColums = (base.Width - num) / num2;
		}
	}

	private void ResumeScroll()
	{
		if (_Dump != null)
		{
			_LineLength = GetCellBytes() * _DataColums;
			_Lines = _Dump.Length / _LineLength;
			if (_Lines * _LineLength < _Dump.Length)
			{
				_Lines++;
			}
			_ScrollBar.Enabled = _DataRows < _Lines;
			if (_ScrollBar.Enabled)
			{
				_ScrollBar.Minimum = 0;
				_ScrollBar.Maximum = _Lines - _DataRows + 9;
			}
		}
	}

	private void Scroll()
	{
		uint num = (uint)(_ScrollBar.Value * _LineLength);
		if (num != _Offset)
		{
			EndEditing();
			_Offset = num;
			Invalidate();
		}
	}

	private void EndEditing(bool apply = false)
	{
		if (_EditIndex != -1)
		{
			if (apply)
			{
				int cellValue = GetCellValue(_EditIndex);
				int num = Convert.ToUInt16("0" + _Edit.Text, 16);
				SetCellValue(_EditIndex, num);
				this.Edited?.Invoke(this, new HexBoxEditEventArgs(_EditIndex, cellValue, num));
				Invalidate();
			}
			_Edit.Hide();
			_EditIndex = -1;
		}
	}

	private int DrawHex(Graphics g, Color color, int x, int y, int value, int width)
	{
		string text = "X" + width;
		string text2 = value.ToString(text);
		int num = 0;
		while (num < text2.Length)
		{
			g.DrawString(text2.Substring(num, 1), Font, GetBrush(color), x, y, _StringFormat);
			num++;
			x += _CharWidth;
		}
		return x;
	}

	private void DrawBackground(Graphics g)
	{
		g.Clear(BackColor);
		g.DrawRectangle(Pens.Gray, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
		g.DrawString("-Address-", Font, GetBrush(Color.Gray), _HeaderLeft, _HeaderTop, _StringFormat);
		int num = _HeaderLeft + _AddressWidth + _ColumnsDelim;
		int width = 2 * GetCellBytes();
		int num2 = 0;
		while (num2 < _DataColums)
		{
			num = DrawHex(g, Color.Gray, num, _HeaderTop, num2, width);
			num2++;
			num += _CharWidth;
		}
		if (_ViewMode == HexBoxViewMode.BytesAscii)
		{
			int num3 = _CharWidth * _DataColums - _CharWidth;
			num = num - _CharWidth + _ColumnsDelim + (num3 - 5 * _CharWidth) / 2;
			g.DrawString("ASCII", Font, GetBrush(Color.Gray), num, _HeaderTop, _StringFormat);
		}
		int num4 = _HeaderTop + _CharHeight + 2;
		width = _HeaderLeft + _AddressWidth + _ColumnsDelim + _DataCellWidth * _DataColums - _CharWidth;
		if (_ViewMode == HexBoxViewMode.BytesAscii)
		{
			width += _ColumnsDelim + 2 * _CharWidth * _DataColums - _CharWidth;
		}
		g.DrawLine(GetPen(Color.Gray), _HeaderLeft, num4, width, num4);
	}

	private void DrawLines(Graphics g)
	{
		int num = (int)_Offset;
		int num2 = _HeaderTop + 4;
		int cellBytes = GetCellBytes();
		for (int i = 0; i < _DataRows; i++)
		{
			num2 += _CharHeight;
			int num3 = DrawHex(g, Color.Blue, _HeaderLeft, num2, (int)((_ViewMode == HexBoxViewMode.Words) ? ((int)(num + _AddressOffset) / 2) : (num + _AddressOffset)), 8);
			g.DrawString(":", Font, GetBrush(Color.Blue), num3, num2, _StringFormat);
			int num4 = _HeaderLeft + _AddressWidth + _ColumnsDelim;
			int num5 = num4 + _DataColums * _DataCellWidth - _CharWidth + _ColumnsDelim;
			int num6 = 0;
			while (num6 < _DataColums)
			{
				int cellValue = GetCellValue(num);
				num4 = DrawHex(g, Color.Black, num4, num2, cellValue, 2 * cellBytes);
				if (_ViewMode == HexBoxViewMode.BytesAscii)
				{
					char c = _CharConverter.ToChar(_Dump, num);
					if (c == '\0')
					{
						g.DrawString(".", Font, GetBrush(Color.DarkMagenta), num5, num2, _StringFormat);
					}
					else
					{
						g.DrawString(c.ToString(), Font, GetBrush(Color.DarkMagenta), num5, num2, _StringFormat);
					}
					num5 += _CharWidth;
				}
				num += cellBytes;
				if (num >= _Dump.Length)
				{
					i = _DataRows;
					break;
				}
				num6++;
				num4 += _CharWidth;
			}
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		DrawBackground(e.Graphics);
		if (_Dump != null && _Dump.Length != 0)
		{
			DrawLines(e.Graphics);
		}
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		Resume();
		ResumeScroll();
		if (_Offset > 0)
		{
			int num = _Lines - _DataRows;
			if (num < _Offset / _LineLength)
			{
				EndEditing();
				_Offset = num * _LineLength;
				_ScrollBar.Value = num;
			}
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		base.OnMouseWheel(e);
		if (!_ScrollBar.Enabled)
		{
			return;
		}
		if (e.Delta < 0)
		{
			if (_ScrollBar.Maximum - _ScrollBar.Value > 9)
			{
				_ScrollBar.Value++;
				Scroll();
			}
		}
		else if (_ScrollBar.Value > 0)
		{
			_ScrollBar.Value--;
			Scroll();
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		EndEditing(apply: true);
		if (!Focused)
		{
			Focus();
		}
		Point cellPos = GetCellPos(e.Location);
		if (cellPos.X != -1)
		{
			_EditIndex = GetCellIndex(cellPos);
			if (_EditIndex != -1)
			{
				cellPos.X = _HeaderLeft + _AddressWidth + _ColumnsDelim + cellPos.X * _DataCellWidth;
				cellPos.Y = _HeaderTop + 4 + _CharHeight + cellPos.Y * _CharHeight;
				_Edit.Text = GetCellValue(_EditIndex).ToString("X" + 2 * GetCellBytes());
				_Edit.Location = cellPos;
				_Edit.Show();
				_Edit.Select();
				_Edit.SelectAll();
			}
		}
	}
}
