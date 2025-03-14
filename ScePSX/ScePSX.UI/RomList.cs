using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ScePSX.CdRom2;
using ScePSX.Properties;

namespace ScePSX.UI;

public class RomList : ListBox
{
	public class Game
	{
		public string Name;

		public Image Icon;

		public long Size;

		public string ID;

		public string FileName;

		public string fullName;

		public string LastPlayed;

		public bool HasSaveState;

		public bool HasCheats;

		public Game()
		{
		}

		public Game(string name, Image icon, long size, string id, string filename, string lastplayed, bool state, bool cheats)
		{
			Name = name;
			Icon = icon;
			Size = size;
			ID = id;
			FileName = filename;
			LastPlayed = lastplayed;
			HasSaveState = state;
			HasCheats = cheats;
		}
	}

	public class CustomToolStripRenderer : ToolStripProfessionalRenderer
	{
		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			if (e.Item.Selected)
			{
				using (SolidBrush brush = new SolidBrush(MenuSelectColor))
				{
					e.Graphics.FillRectangle(brush, e.Item.ContentRectangle);
					return;
				}
			}
			using SolidBrush brush2 = new SolidBrush(MenuUnSelectColor);
			e.Graphics.FillRectangle(brush2, e.Item.ContentRectangle);
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			e.TextColor = Color.White;
			base.OnRenderItemText(e);
		}

		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
			using Pen pen = new Pen(SepColor);
			e.Graphics.DrawLine(pen, e.Item.ContentRectangle.Left, e.Item.ContentRectangle.Height / 2, e.Item.ContentRectangle.Right, e.Item.ContentRectangle.Height / 2);
		}

		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
			Rectangle rect = new Rectangle(e.AffectedBounds.Left, e.AffectedBounds.Top, e.AffectedBounds.Width, e.AffectedBounds.Height);
			using SolidBrush brush = new SolidBrush(MenuUnSelectColor);
			e.Graphics.FillRectangle(brush, rect);
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			using Pen pen = new Pen(SepColor);
			e.Graphics.DrawRectangle(pen, 0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
		}
	}

	private int _hoverIndex = -1;

	private readonly Image DefaultIcon;

	private ContextMenuStrip contextMenuStrip;

	private Rectangle scrollBarBounds;

	private Rectangle thumbBounds;

	private bool isDraggingThumb;

	private int thumbPosition;

	private int thumbSize;

	private bool _isScrollBarVisible;

	private const int ScrollBarWidth = 8;

	private const int ScrollBarMargin = 2;

	private const int ThumbMinSize = 20;

	private readonly Color TrackColor = Color.FromArgb(60, 60, 60);

	private readonly Color ThumbColor = Color.FromArgb(100, 100, 100);

	private readonly Color ThumbHoverColor = Color.FromArgb(120, 120, 120);

	private Color TextColor = Color.White;

	private Color InfoBackColor = Color.FromArgb(50, 50, 50);

	private Color MainBackColor = Color.FromArgb(45, 45, 45);

	private Color MenuBackColor = Color.FromArgb(45, 45, 45);

	private Color ItemBackColor2 = Color.FromArgb(43, 43, 43);

	private Color ItemBackColor1 = Color.FromArgb(50, 50, 50);

	private Color HoverColor = Color.FromArgb(70, 70, 70);

	private Color SelectionColor = Color.Orange;

	private Color BorderColor = Color.FromArgb(100, 100, 100);

	private Color ShadowColor = Color.FromArgb(50, 0, 0, 0);

	private Color MainBoardColor = Color.FromArgb(60, 60, 60);

	private Color InfoBorderColor = Color.FromArgb(100, 100, 100);

	private static Color MenuSelectColor = Color.FromArgb(70, 70, 70);

	private static Color MenuHoverColor = Color.FromArgb(80, 80, 80);

	private static Color MenuUnSelectColor = Color.FromArgb(45, 45, 45);

	private static Color SepColor = Color.FromArgb(100, 100, 100);

	private bool? _shouldSearchSubdirectories;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.Style &= -1048577;
			createParams.Style &= -2097153;
			return createParams;
		}
	}

	public RomList()
	{
		InitializeComponent();
		scrollBarBounds = new Rectangle(base.ClientRectangle.Width - 8 - 2, 2, 8, Math.Max(40, base.ClientRectangle.Height - 4));
		thumbSize = scrollBarBounds.Height;
		thumbPosition = 0;
		DoubleBuffered = true;
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		UpdateStyles();
		DrawMode = DrawMode.OwnerDrawVariable;
		BackColor = MainBackColor;
		ForeColor = TextColor;
		ItemHeight = 85;
		DefaultIcon = GetDefaultExeIcon();
		base.MouseMove += RomList_MouseMove;
		base.MouseLeave += RomList_MouseLeave;
		contextMenuStrip = new ContextMenuStrip();
		contextMenuStrip.RenderMode = ToolStripRenderMode.Professional;
		contextMenuStrip.Renderer = new CustomToolStripRenderer();
		contextMenuStrip.BackColor = MenuBackColor;
		ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(Resources.RomList_RomList_存档管理, null, OnMcrClick);
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(Resources.RomList_RomList_修改设置, null, OnSetClick);
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem(Resources.RomList_RomList_编辑金手指, null, OnCheatClick);
		ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem(Resources.RomList_RomList_取存档图标, null, OnUpIconClick);
		ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem(Resources.RomList_RomList_设置图标, null, OnSetIconClick);
		ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem(Resources.RomList_RomList_删除, null, OnDeleteClick);
		contextMenuStrip.Items.AddRange(new ToolStripItem[9] { toolStripMenuItem, toolStripSeparator, toolStripMenuItem2, toolStripMenuItem3, toolStripSeparator, toolStripMenuItem4, toolStripMenuItem5, toolStripSeparator, toolStripMenuItem6 });
		ContextMenuStrip = contextMenuStrip;
	}

	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.FormattingEnabled = true;
		base.TabIndex = 0;
		base.Name = "RomList";
		base.Size = new System.Drawing.Size(510, 316);
		base.ResumeLayout(false);
	}

	public void FillByini()
	{
		string[] sectionKeys = FrmMain.ini.GetSectionKeys("history");
		if (File.Exists("gamedb.yaml"))
		{
			SimpleYaml.ParseYamlFile("gamedb.yaml");
		}
		string[] array = sectionKeys;
		foreach (string text in array)
		{
			if (!(text != ""))
			{
				continue;
			}
			string[] array2 = FrmMain.ini.Read("history", text).Split('|');
			if (!File.Exists(array2[0]))
			{
				continue;
			}
			Game game = FindOrNew(text);
			game.ID = text;
			game.fullName = array2[0];
			game.Name = SimpleYaml.TryGetValue(text + ".name").Replace("\"", "");
			if (game.Name == "")
			{
				game.Name = Path.GetFileNameWithoutExtension(array2[0]);
			}
			game.FileName = Path.GetFileName(array2[0]);
			game.Size = new FileInfo(array2[0]).Length;
			game.LastPlayed = array2[1];
			game.HasSaveState = Directory.GetFiles("./SaveState/", text + "_Save?.dat").Length != 0;
			game.HasCheats = File.Exists("./Cheats/" + text + ".txt");
			if (File.Exists("./Icons/" + text + ".png"))
			{
				game.Icon = Image.FromFile("./Icons/" + text + ".png");
			}
			else if (File.Exists("./Save/" + text + ".dat"))
			{
				MemCardMange.SlotData[] slots = new MemCardMange("./Save/" + text + ".dat").Slots;
				foreach (MemCardMange.SlotData slotData in slots)
				{
					if (slotData.ProdCode == text && slotData.type == MemCardMange.SlotTypes.initial)
					{
						game.Icon = slotData.GetIconBitmap(0);
						game.Icon.Save("./Icons/" + text + ".png", ImageFormat.Png);
						break;
					}
				}
			}
			AddOrReplace(game);
		}
		SimpleYaml.Clear();
		SortByLastPlayed();
	}

	public void AddByFile(FileInfo f)
	{
		Path.GetExtension(f.FullName);
		CDData cDData = new CDData(f.FullName);
		if (!(cDData.DiskID != ""))
		{
			return;
		}
		string diskID = cDData.DiskID;
		Game game = FindOrNew(diskID);
		game.fullName = f.FullName;
		game.Name = SimpleYaml.TryGetValue(diskID + ".name").Replace("\"", "");
		if (game.Name == "")
		{
			game.Name = Path.GetFileNameWithoutExtension(f.FullName);
		}
		game.FileName = Path.GetFileName(f.FullName);
		game.ID = diskID;
		game.Size = cDData.tracks[0].FileLength;
		string text = FrmMain.ini.Read("history", diskID);
		if (text == "")
		{
			game.LastPlayed = "";
			FrmMain.ini.Write("history", diskID, f.FullName + "|");
		}
		else
		{
			string[] array = text.Split('|');
			game.LastPlayed = array[1];
		}
		game.HasSaveState = Directory.GetFiles("./SaveState/", diskID + "_Save?.dat").Length != 0;
		game.HasCheats = File.Exists("./Cheats/" + diskID + ".txt");
		if (File.Exists("./Icons/" + diskID + ".png"))
		{
			game.Icon = Image.FromFile("./Icons/" + diskID + ".png");
		}
		else if (File.Exists("./Save/" + diskID + ".dat"))
		{
			MemCardMange.SlotData[] slots = new MemCardMange("./Save/" + diskID + ".dat").Slots;
			foreach (MemCardMange.SlotData slotData in slots)
			{
				if (slotData.ProdCode == diskID && slotData.type == MemCardMange.SlotTypes.initial)
				{
					game.Icon = slotData.GetIconBitmap(0);
					game.Icon.Save("./Icons/" + diskID + ".png", ImageFormat.Png);
					break;
				}
			}
		}
		AddOrReplace(game);
	}

	public void SearchDir(string dir)
	{
		if (File.Exists("gamedb.yaml"))
		{
			SimpleYaml.ParseYamlFile("gamedb.yaml");
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(dir);
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo f in files)
		{
			AddByFile(f);
		}
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (directories.Length != 0)
		{
			if (!_shouldSearchSubdirectories.HasValue)
			{
				DialogResult dialogResult = MessageBox.Show(Resources.RomList_SearchDir_是否要搜索子目录, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				_shouldSearchSubdirectories = dialogResult == DialogResult.Yes;
			}
			if (_shouldSearchSubdirectories == true)
			{
				DirectoryInfo[] array = directories;
				foreach (DirectoryInfo directoryInfo2 in array)
				{
					SearchDir(directoryInfo2.FullName);
				}
			}
		}
		SimpleYaml.Clear();
		SortByLastPlayed();
	}

	private void AddOrReplace(Game game)
	{
		int num = base.Items.IndexOf(game);
		if (num > -1)
		{
			base.Items[num] = game;
		}
		else
		{
			base.Items.Add(game);
		}
	}

	private Game FindOrNew(string id)
	{
		foreach (Game item in base.Items)
		{
			if (item.ID == id)
			{
				return item;
			}
		}
		return new Game();
	}

	public Game SelectedGame()
	{
		if (SelectedIndex > -1)
		{
			return base.Items[SelectedIndex] as Game;
		}
		return null;
	}

	public void SortByLastPlayed()
	{
		List<Game> list = new List<Game>();
		foreach (Game item in base.Items)
		{
			list.Add(item);
		}
		list.Sort((Game x, Game y) => DateTime.Compare(string.IsNullOrEmpty(y.LastPlayed) ? DateTime.MinValue : DateTime.Parse(y.LastPlayed), string.IsNullOrEmpty(x.LastPlayed) ? DateTime.MinValue : DateTime.Parse(x.LastPlayed)));
		base.Items.Clear();
		foreach (Game item2 in list)
		{
			base.Items.Add(item2);
		}
	}

	private void ShowFrom(Form Frm)
	{
		Frm.StartPosition = FormStartPosition.Manual;
		Frm.Owner = (Form)base.Parent;
		Point p = new Point(base.ClientSize.Width / 2, base.ClientSize.Height / 2);
		Point point = PointToScreen(p);
		Frm.Location = new Point(point.X - Frm.Width / 2, point.Y - Frm.Height / 2);
		Frm.Show();
	}

	private void OnSetClick(object sender, EventArgs e)
	{
		if (SelectedGame() != null)
		{
			ShowFrom(new Form_Set(SelectedGame().ID));
		}
	}

	private void OnMcrClick(object sender, EventArgs e)
	{
		if (SelectedGame() != null)
		{
			ShowFrom(new Form_McrMange(SelectedGame().ID));
		}
	}

	private void OnUpIconClick(object sender, EventArgs e)
	{
		Game game = SelectedGame();
		if (game == null)
		{
			return;
		}
		MemCardMange.SlotData[] slots = new MemCardMange("./Save/" + game.ID + ".dat").Slots;
		foreach (MemCardMange.SlotData slotData in slots)
		{
			if (slotData.ProdCode == game.ID && slotData.type == MemCardMange.SlotTypes.initial)
			{
				if (game.Icon != null)
				{
					game.Icon.Dispose();
				}
				game.Icon = slotData.GetIconBitmap(0);
				game.Icon.Save("./Icons/" + game.ID + ".png", ImageFormat.Png);
				break;
			}
		}
	}

	private void OnCheatClick(object sender, EventArgs e)
	{
		if (SelectedGame() != null)
		{
			ShowFrom(new Form_Cheat(SelectedGame().ID));
		}
	}

	private void OnSetIconClick(object sender, EventArgs e)
	{
		Game game = SelectedGame();
		if (game == null)
		{
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Icon|*.png;*.bmp;*.jpg;*.ico";
		openFileDialog.ShowDialog();
		if (File.Exists(openFileDialog.FileName))
		{
			if (game.Icon != null)
			{
				game.Icon.Dispose();
			}
			using (Image original = Image.FromFile(openFileDialog.FileName))
			{
				game.Icon = new Bitmap(original);
			}
			game.Icon.Save("./Icons/" + game.ID + ".png", ImageFormat.Png);
			Invalidate();
		}
	}

	private void OnDeleteClick(object sender, EventArgs e)
	{
		Game game = SelectedGame();
		if (game != null)
		{
			base.Items.Remove(game);
			FrmMain.ini.DeleteKey("history", game.ID);
		}
	}

	private void RomList_MouseMove(object sender, MouseEventArgs e)
	{
		int num = myIndexFromPoint(e.Location);
		if (num != _hoverIndex)
		{
			_hoverIndex = num;
			Invalidate();
		}
		if (isDraggingThumb && scrollBarBounds.Contains(e.Location))
		{
			thumbPosition = Math.Max(0, Math.Min(e.Y - thumbSize / 2, scrollBarBounds.Height - thumbSize));
			UpdateScrollPosition();
			Invalidate();
		}
	}

	private void RomList_MouseLeave(object sender, EventArgs e)
	{
		if (_hoverIndex != -1)
		{
			_hoverIndex = -1;
			Invalidate();
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			int num = myIndexFromPoint(e.Location);
			if (num != -1 && num >= 0 && num < base.Items.Count)
			{
				SelectedIndex = num;
			}
			else
			{
				SelectedIndex = -1;
			}
			if (SelectedIndex == -1 || base.Items.Count <= 0)
			{
				return;
			}
			contextMenuStrip.Show(this, e.Location);
		}
		if (scrollBarBounds.Contains(e.Location))
		{
			if (thumbBounds.Contains(e.Location))
			{
				isDraggingThumb = true;
			}
			else
			{
				thumbPosition = Math.Max(0, Math.Min(e.Y - thumbSize / 2, scrollBarBounds.Height - thumbSize));
				UpdateScrollPosition();
			}
			Invalidate();
		}
		else
		{
			Point point = new Point(Math.Min(e.X, base.ClientSize.Width - scrollBarBounds.Width - 1), e.Y);
			base.OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta));
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		isDraggingThumb = false;
	}

	protected override void OnDrawItem(DrawItemEventArgs e)
	{
		if (e.Index < 0 || e.Index >= base.Items.Count || e.Bounds.Width <= 0 || e.Bounds.Height <= 0)
		{
			return;
		}
		using Bitmap image = new Bitmap(e.Bounds.Width, e.Bounds.Height);
		using Graphics graphics = Graphics.FromImage(image);
		DrawItemEventArgs e2 = new DrawItemEventArgs(graphics, e.Font, new Rectangle(0, 0, e.Bounds.Width, e.Bounds.Height), e.Index, e.State);
		DrawItems(e2);
		e.Graphics.DrawImage(image, e.Bounds.Location);
	}

	private void DrawItems(DrawItemEventArgs e)
	{
		if (e.Index >= 0 && e.Index < base.Items.Count)
		{
			if (_isScrollBarVisible)
			{
				int width = base.ClientSize.Width - scrollBarBounds.Width;
				e = new DrawItemEventArgs(e.Graphics, e.Font, new Rectangle(e.Bounds.X, e.Bounds.Y, width, e.Bounds.Height), e.Index, e.State);
			}
			Rectangle bounds = e.Bounds;
			bool num = e.Index == _hoverIndex;
			Color color = ((e.Index % 2 == 0) ? ItemBackColor2 : ItemBackColor1);
			if (num)
			{
				color = HoverColor;
			}
			using (SolidBrush brush = new SolidBrush(color))
			{
				e.Graphics.FillRectangle(brush, bounds);
			}
			Game game = base.Items[e.Index] as Game;
			int iconSize = 48;
			int padding = 5;
			DrawMainBox(e.Graphics, bounds);
			DrawIcon(e.Graphics, game.Icon ?? DefaultIcon, bounds, iconSize, padding);
			DrawName(e.Graphics, game.Name, bounds, iconSize, padding);
			DrawInfoBoxes(e.Graphics, game, bounds, iconSize, padding);
		}
	}

	private void DrawMainBox(Graphics g, Rectangle bounds)
	{
		using Pen pen = new Pen(BorderColor, 2f);
		using SolidBrush brush = new SolidBrush(ShadowColor);
		g.FillRectangle(brush, bounds.X + 2, bounds.Y + 2, bounds.Width - 4, bounds.Height - 4);
		g.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width - 2, bounds.Height - 2);
	}

	private void DrawIcon(Graphics g, Image icon, Rectangle bounds, int iconSize, int padding)
	{
		int y = bounds.Top + (bounds.Height - iconSize) / 2;
		if (icon != null)
		{
			g.DrawImage(icon, bounds.Left + padding, y, iconSize, iconSize);
		}
	}

	private void DrawName(Graphics g, string name, Rectangle bounds, int iconSize, int padding)
	{
		using Font font = new Font("Arial", 13f, FontStyle.Bold);
		using SolidBrush brush = new SolidBrush(Color.White);
		int num = bounds.Top + (bounds.Height - iconSize) / 2;
		g.MeasureString(name, font);
		g.DrawString(name, font, brush, bounds.Left + iconSize + padding * 2, num + 3);
	}

	private void DrawInfoBoxes(Graphics g, Game game, Rectangle bounds, int iconSize, int padding)
	{
		int x = bounds.Left + iconSize + 15;
		int num = bounds.Top + 32;
		DrawInfoBox(g, game.ID ?? "", x, num + 13, 8);
		x = bounds.Right - 340;
		num = bounds.Bottom - 32;
		if (game.LastPlayed != "" && base.Width > 550)
		{
			DrawInfoBox(g, Resources.RomList_DrawInfoBoxes_最后运行 + ": " + game.LastPlayed, x - 29, num);
		}
		DrawInfoBox(g, Resources.RomList_DrawInfoBoxes_即时存档 + ": " + (game.HasSaveState ? "✓" : "✗"), x + 166, num);
		DrawInfoBox(g, Resources.RomList_DrawInfoBoxes_金手指 + ": " + (game.HasCheats ? "✓" : "✗"), x + 260, num);
	}

	private void DrawSelectionEffect(Graphics g, Rectangle bounds)
	{
		using Pen pen = new Pen(SelectionColor, 2f);
		g.DrawRectangle(pen, bounds.X + 1, bounds.Y + 1, bounds.Width - 3, bounds.Height - 3);
	}

	private void DrawInfoBox(Graphics g, string label, int x, int y, int fontSize = 9)
	{
		using SolidBrush brush = new SolidBrush(InfoBackColor);
		using Pen pen = new Pen(InfoBorderColor);
		using SolidBrush brush2 = new SolidBrush(Color.White);
		using Font font = new Font("Arial", fontSize);
		int num = 4;
		SizeF sizeF = g.MeasureString(label, font);
		g.FillRectangle(brush, x, y, sizeF.Width + (float)(num * 2), sizeF.Height + (float)(num * 2));
		g.DrawRectangle(pen, x, y, sizeF.Width + (float)(num * 2), sizeF.Height + (float)(num * 2));
		g.DrawString(label, font, brush2, x + num, y + num);
	}

	private void DrawInfoBoxValue(Graphics g, string label, string value, int x, int y, int width, int height, int fontsize = 9)
	{
		using SolidBrush brush = new SolidBrush(Color.FromArgb(50, 50, 50));
		using Pen pen = new Pen(Color.FromArgb(100, 100, 100));
		using SolidBrush brush2 = new SolidBrush(Color.White);
		using Font font = new Font("Arial", fontsize);
		SizeF sizeF = g.MeasureString(label, font);
		SizeF sizeF2 = g.MeasureString(value, font);
		g.FillRectangle(brush, x, y, sizeF.Width + 2f, sizeF.Height + 2f);
		g.DrawRectangle(pen, x, y, sizeF.Width + 2f, sizeF.Height + 2f);
		g.DrawString(label, font, brush2, x + 2, (float)y + ((float)height - sizeF.Height) / 2f);
		g.DrawString(value, font, brush2, (float)(x + width) - sizeF2.Width - 2f, (float)y + ((float)height - sizeF2.Height) / 2f);
	}

	private Image GetDefaultExeIcon()
	{
		try
		{
			return Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();
		}
		catch
		{
			return new Bitmap(48, 48);
		}
	}

	protected override void OnMeasureItem(MeasureItemEventArgs e)
	{
		e.ItemHeight = ItemHeight;
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		scrollBarBounds = new Rectangle(base.ClientRectangle.Width - 8 - 2, 2, 8, Math.Max(40, base.ClientRectangle.Height - 4));
		UpdateScrollBar();
		Invalidate();
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		base.OnMouseWheel(e);
		int num = e.Delta * SystemInformation.MouseWheelScrollLines / 120 * ItemHeight;
		thumbPosition -= num;
		thumbPosition = Math.Max(0, Math.Min(thumbPosition, scrollBarBounds.Height - thumbSize));
		UpdateScrollPosition();
		Invalidate();
	}

	public new Rectangle GetItemRectangle(int index)
	{
		Rectangle itemRectangle = base.GetItemRectangle(index);
		int width = (_isScrollBarVisible ? (base.ClientSize.Width - 8 - 4) : base.ClientSize.Width);
		itemRectangle.Width = width;
		return itemRectangle;
	}

	public int myIndexFromPoint(Point p)
	{
		if (p.X >= base.ClientSize.Width - scrollBarBounds.Width)
		{
			return -1;
		}
		Point p2 = new Point(Math.Min(p.X, base.ClientSize.Width - scrollBarBounds.Width - 1), p.Y);
		return IndexFromPoint(p2);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.Clear(BackColor);
		int topIndex = base.TopIndex;
		int num = base.ClientSize.Height / ItemHeight;
		int num2 = Math.Min(base.Items.Count - 1, topIndex + num + 1);
		for (int i = topIndex; i <= num2; i++)
		{
			Rectangle itemRectangle = GetItemRectangle(i);
			if (itemRectangle.Bottom >= 0 && itemRectangle.Top <= base.ClientSize.Height)
			{
				DrawItemState drawItemState = DrawItemState.Default;
				if (i == SelectedIndex)
				{
					drawItemState |= DrawItemState.Selected;
				}
				DrawItemEventArgs e2 = new DrawItemEventArgs(e.Graphics, Font, itemRectangle, i, drawItemState);
				OnDrawItem(e2);
			}
		}
		DrawScrollBar(graphics);
	}

	private void DrawScrollBar(Graphics g)
	{
		if (!_isScrollBarVisible || scrollBarBounds.Width <= 0 || scrollBarBounds.Height <= 0)
		{
			return;
		}
		using (SolidBrush brush = new SolidBrush(TrackColor))
		{
			using Pen pen = new Pen(Color.FromArgb(80, 80, 80));
			g.FillRectangle(brush, scrollBarBounds);
			g.DrawRectangle(pen, scrollBarBounds);
		}
		thumbBounds = new Rectangle(scrollBarBounds.X + 2, scrollBarBounds.Y + thumbPosition, scrollBarBounds.Width - 4, Math.Max(1, thumbSize));
		bool flag = thumbBounds.Contains(PointToClient(System.Windows.Forms.Cursor.Position));
		using (LinearGradientBrush brush2 = new LinearGradientBrush(thumbBounds, flag ? ThumbHoverColor : ThumbColor, Color.FromArgb(flag ? 80 : 60, 80, 80), LinearGradientMode.Vertical))
		{
			g.FillRectangle(brush2, thumbBounds);
			using Pen pen2 = new Pen(Color.FromArgb(150, 150, 150));
			g.DrawLine(pen2, thumbBounds.Left + 1, thumbBounds.Top + 1, thumbBounds.Right - 2, thumbBounds.Top + 1);
		}
		using Pen pen3 = new Pen(Color.FromArgb(180, 180, 180));
		g.DrawRectangle(pen3, thumbBounds);
	}

	private void UpdateScrollBar()
	{
		_isScrollBarVisible = base.Items.Count * ItemHeight > base.ClientSize.Height;
		if (!_isScrollBarVisible)
		{
			thumbSize = 0;
			thumbPosition = 0;
			return;
		}
		if (scrollBarBounds.Height <= 0)
		{
			scrollBarBounds.Height = Math.Max(40, base.ClientSize.Height);
		}
		int num = base.ClientSize.Height / ItemHeight;
		int count = base.Items.Count;
		thumbSize = Math.Max(20, (int)((float)num / (float)count * (float)scrollBarBounds.Height));
		thumbSize = Math.Min(thumbSize, scrollBarBounds.Height);
		int num2 = Math.Max(0, count - num);
		if (num2 == 0)
		{
			thumbPosition = 0;
		}
		else
		{
			thumbPosition = (int)((float)base.TopIndex / (float)num2 * (float)(scrollBarBounds.Height - thumbSize));
		}
		thumbPosition = Math.Max(0, Math.Min(thumbPosition, scrollBarBounds.Height - thumbSize));
	}

	private void UpdateScrollPosition()
	{
		if (base.Items.Count != 0)
		{
			int num = base.ClientSize.Height / ItemHeight;
			int count = base.Items.Count;
			int num2 = Math.Max(0, count - num);
			if (scrollBarBounds.Height - thumbSize != 0)
			{
				float num3 = (float)thumbPosition / (float)(scrollBarBounds.Height - thumbSize);
				base.TopIndex = (int)(num3 * (float)num2);
			}
			Invalidate();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			DefaultIcon.Dispose();
			foreach (object item in base.Items)
			{
				if ((item as Game).Icon != null)
				{
					(item as Game).Icon.Dispose();
				}
			}
		}
		base.Dispose(disposing);
	}

	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
	}
}
