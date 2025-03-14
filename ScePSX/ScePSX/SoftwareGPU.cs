using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ScePSX;

public class SoftwareGPU : IGPU, IDisposable
{
	public class RamBuff : IDisposable
	{
		public int Width;

		public int Height;

		public int length;

		public int size;

		public unsafe ushort* Pixels;

		public unsafe RamBuff(int width, int height)
		{
			Width = width;
			Height = height;
			length = width * height;
			size = length * 2;
			Pixels = (ushort*)Marshal.AllocHGlobal(size);
		}

		public unsafe Span<ushort> AsSpan()
		{
			return new Span<ushort>(Pixels, length);
		}

		public unsafe ushort GetPixel(int x, int y)
		{
			return (Pixels + y * Width)[x];
		}

		public unsafe void SetPixel(int x, int y, ushort color)
		{
			(Pixels + y * Width)[x] = color;
		}

		public unsafe void Dispose()
		{
			Marshal.FreeHGlobal((nint)Pixels);
		}
	}

	public class FrameBuff : IDisposable
	{
		public int Width;

		public int Height;

		public int length;

		public int size;

		public unsafe int* Pixels;

		public unsafe FrameBuff(int width, int height)
		{
			Width = width;
			Height = height;
			length = width * height;
			size = length * 4;
			Pixels = (int*)Marshal.AllocHGlobal(size);
		}

		public unsafe Span<int> AsSpan()
		{
			return new Span<int>(Pixels, length);
		}

		public unsafe int GetPixel(int x, int y)
		{
			return (Pixels + y * Width)[x];
		}

		public unsafe void SetPixel(int x, int y, int color)
		{
			(Pixels + y * Width)[x] = color;
		}

		public unsafe void Dispose()
		{
			Marshal.FreeHGlobal((nint)Pixels);
		}
	}

	private GPUColor Color0;

	private GPUColor Color1;

	private GPUColor Color2;

	private TDrawingArea DrawingAreaTopLeft;

	private TDrawingArea DrawingAreaBottomRight;

	private TDrawingOffset DrawingOffset;

	private VRAMTransfer _VRAMTransfer;

	private int MaskWhileDrawing;

	private bool CheckMaskBeforeDraw;

	private int TextureWindowPostMaskX;

	private int TextureWindowPostMaskY;

	private int TextureWindowPreMaskX;

	private int TextureWindowPreMaskY;

	private readonly RamBuff RamData = new RamBuff(1024, 512);

	private readonly FrameBuff FrameData = new FrameBuff(1024, 512);

	private static readonly byte[] LookupTable888to555 = new byte[256];

	private static readonly byte[] LookupTable1555to8888 = new byte[32];

	public GPUType type => GPUType.Software;

	public SoftwareGPU()
	{
		for (int i = 0; i < 256; i++)
		{
			LookupTable888to555[i] = (byte)(i * 31 >> 8);
		}
		for (int j = 0; j < 32; j++)
		{
			LookupTable1555to8888[j] = (byte)((j * 255 + 15) / 31);
		}
	}

	public void Initialize()
	{
	}

	public void Dispose()
	{
		FrameData.Dispose();
		RamData.Dispose();
	}

	public void SetParams(int[] Params)
	{
	}

	public unsafe void SetRam(byte[] Ram)
	{
		Marshal.Copy(Ram, 0, (nint)RamData.Pixels, Ram.Length);
	}

	public unsafe byte[] GetRam()
	{
		byte[] array = new byte[RamData.size];
		Marshal.Copy((nint)RamData.Pixels, array, 0, RamData.size);
		return array;
	}

	public unsafe void SetFrameBuff(byte[] FrameBuffer)
	{
		Marshal.Copy(FrameBuffer, 0, (nint)FrameData.Pixels, FrameBuffer.Length);
	}

	public unsafe byte[] GetFrameBuff()
	{
		byte[] array = new byte[FrameData.size];
		Marshal.Copy((nint)FrameData.Pixels, array, 0, FrameData.size);
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe (int w, int h) GetPixels(bool is24bit, int dy1, int dy2, int rx, int ry, int w, int h, int[] Pixels)
	{
		int item;
		int item2;
		if (is24bit)
		{
			int lineOffset = 240 - (dy2 - dy1) >> ((h != 480) ? 1 : 0);
			int toExclusive = h - lineOffset;
			Parallel.For(lineOffset, toExclusive, delegate(int line)
			{
				int num = line - lineOffset;
				int num2 = ry + num;
				int num3 = rx + num2 * 1024;
				int num4 = num * w;
				int num5 = w;
				int num6 = 0;
				for (int i = 0; i < num5; i += 2)
				{
					int color = (FrameData.Pixels + num3)[num6];
					int color2 = (FrameData.Pixels + num3 + num6)[1];
					int color3 = (FrameData.Pixels + num3 + num6)[2];
					num6 += 3;
					ushort num7 = rgb8888to1555(color);
					ushort num8 = rgb8888to1555(color2);
					ushort num9 = rgb8888to1555(color3);
					int num10 = num7 & 0xFF;
					int num11 = (num7 >> 8) & 0xFF;
					int num12 = num8 & 0xFF;
					int num13 = (num8 >> 8) & 0xFF;
					int num14 = num9 & 0xFF;
					int num15 = (num9 >> 8) & 0xFF;
					int num16 = (num10 << 16) | (num11 << 8) | num12;
					int num17 = (num13 << 16) | (num14 << 8) | num15;
					Pixels[num4 + i] = num16;
					Pixels[num4 + i + 1] = num17;
				}
			});
			item = w;
			item2 = h - lineOffset * 2 - 1;
		}
		else
		{
			int LineOffset = 240 - (dy2 - dy1) >> ((h != 480) ? 1 : 0);
			Parallel.For(LineOffset, h - LineOffset, delegate(int line)
			{
				int num18 = rx + (line - LineOffset + ry) * 1024;
				int startIndex = (line - LineOffset) * w;
				Marshal.Copy((nint)(FrameData.Pixels + num18), Pixels, startIndex, w);
			});
			item = w;
			item2 = h - LineOffset * 2 - 1;
		}
		return (w: item, h: item2);
	}

	public void SetVRAMTransfer(VRAMTransfer val)
	{
		_VRAMTransfer = val;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public uint ReadFromVRAM()
	{
		ushort pixel = RamData.GetPixel(_VRAMTransfer.X++ & 0x3FF, _VRAMTransfer.Y & 0x1FF);
		ushort pixel2 = RamData.GetPixel(_VRAMTransfer.X++ & 0x3FF, _VRAMTransfer.Y & 0x1FF);
		if (_VRAMTransfer.X == _VRAMTransfer.OriginX + _VRAMTransfer.W)
		{
			_VRAMTransfer.X -= _VRAMTransfer.W;
			_VRAMTransfer.Y++;
		}
		_VRAMTransfer.HalfWords -= 2;
		return (uint)((pixel2 << 16) | pixel);
	}

	public void SetMaskBit(uint value)
	{
		MaskWhileDrawing = (int)(value & 1);
		CheckMaskBeforeDraw = (value & 2) != 0;
	}

	public void SetDrawingAreaTopLeft(TDrawingArea value)
	{
		DrawingAreaTopLeft = value;
	}

	public void SetDrawingAreaBottomRight(TDrawingArea value)
	{
		DrawingAreaBottomRight = value;
	}

	public void SetDrawingOffset(TDrawingOffset value)
	{
		DrawingOffset = value;
	}

	public void SetTextureWindow(uint value)
	{
		TextureWindow textureWindow = new TextureWindow(value);
		TextureWindowPreMaskX = ~(textureWindow.MaskX * 8);
		TextureWindowPreMaskY = ~(textureWindow.MaskY * 8);
		TextureWindowPostMaskX = (textureWindow.OffsetX & textureWindow.MaskX) * 8;
		TextureWindowPostMaskY = (textureWindow.OffsetY & textureWindow.MaskY) * 8;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FillRectVRAM(ushort x, ushort y, ushort w, ushort h, uint colorval)
	{
		GPUColor gPUColor = default(GPUColor);
		gPUColor.Value = colorval;
		ushort num = (ushort)((gPUColor.B * 31 / 255 << 10) | (gPUColor.G * 31 / 255 << 5) | (gPUColor.R * 31 / 255));
		int num2 = (gPUColor.R << 16) | (gPUColor.G << 8) | gPUColor.B;
		if (x + w <= 1023 && y + h <= 511)
		{
			Span<ushort> span = RamData.AsSpan();
			Span<int> span2 = FrameData.AsSpan();
			for (int i = y; i < h + y; i++)
			{
				int start = i * 1024 + x;
				span.Slice(start, w).Fill(num);
				span2.Slice(start, w).Fill(num2);
			}
			return;
		}
		for (int j = y; j < h + y; j++)
		{
			for (int k = x; k < w + x; k++)
			{
				int y2 = j & 0x1FF;
				FrameData.SetPixel(k & 0x3FF, y2, num2);
				int y3 = j & 0x1FF;
				RamData.SetPixel(k & 0x3FF, y3, num);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyRectVRAMtoVRAM(ushort sx, ushort sy, ushort dx, ushort dy, ushort w, ushort h)
	{
		for (int i = 0; i < h; i++)
		{
			for (int j = 0; j < w; j++)
			{
				int y = (sy + i) & 0x1FF;
				int pixel = FrameData.GetPixel((sx + j) & 0x3FF, y);
				ushort pixel2 = RamData.GetPixel((sx + j) & 0x3FF, (sy + i) & 0x1FF);
				if (CheckMaskBeforeDraw)
				{
					int y2 = (dy + i) & 0x1FF;
					Color0.Value = (uint)FrameData.GetPixel((dx + j) & 0x3FF, y2);
					if (Color0.M != 0)
					{
						continue;
					}
				}
				pixel |= MaskWhileDrawing << 24;
				int y3 = (dy + i) & 0x1FF;
				FrameData.SetPixel((dx + j) & 0x3FF, y3, pixel);
				int y4 = (dy + i) & 0x1FF;
				RamData.SetPixel((dx + j) & 0x3FF, y4, pixel2);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DrawPixel(ushort value)
	{
		if (CheckMaskBeforeDraw)
		{
			if (FrameData.GetPixel(_VRAMTransfer.X, _VRAMTransfer.Y) >> 24 == 0)
			{
				int y = _VRAMTransfer.Y & 0x1FF;
				int color = rgb1555To8888(value);
				FrameData.SetPixel(_VRAMTransfer.X & 0x3FF, y, color);
				int y2 = _VRAMTransfer.Y & 0x1FF;
				RamData.SetPixel(_VRAMTransfer.X & 0x3FF, y2, value);
			}
		}
		else
		{
			int y3 = _VRAMTransfer.Y & 0x1FF;
			int color2 = rgb1555To8888(value);
			FrameData.SetPixel(_VRAMTransfer.X & 0x3FF, y3, color2);
			int y4 = _VRAMTransfer.Y & 0x1FF;
			RamData.SetPixel(_VRAMTransfer.X & 0x3FF, y4, value);
		}
		_VRAMTransfer.X++;
		if (_VRAMTransfer.X == _VRAMTransfer.OriginX + _VRAMTransfer.W)
		{
			_VRAMTransfer.X -= _VRAMTransfer.W;
			_VRAMTransfer.Y++;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DrawLine(uint v1, uint v2, uint color1, uint color2, bool isTransparent, int SemiTransparency)
	{
		short num = Read11BitShort(v1 & 0xFFFF);
		short num2 = Read11BitShort(v1 >> 16);
		short num3 = Read11BitShort(v2 & 0xFFFF);
		short num4 = Read11BitShort(v2 >> 16);
		if (Math.Abs(num - num3) > 1023 || Math.Abs(num2 - num4) > 511)
		{
			return;
		}
		num += DrawingOffset.X;
		num2 += DrawingOffset.Y;
		num3 += DrawingOffset.X;
		num4 += DrawingOffset.Y;
		int num5 = num3 - num;
		int num6 = num4 - num2;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		if (num5 < 0)
		{
			num7 = -1;
		}
		else if (num5 > 0)
		{
			num7 = 1;
		}
		if (num6 < 0)
		{
			num8 = -1;
		}
		else if (num6 > 0)
		{
			num8 = 1;
		}
		if (num5 < 0)
		{
			num9 = -1;
		}
		else if (num5 > 0)
		{
			num9 = 1;
		}
		int num11 = Math.Abs(num5);
		int num12 = Math.Abs(num6);
		if (num11 <= num12)
		{
			num11 = Math.Abs(num6);
			num12 = Math.Abs(num5);
			if (num6 < 0)
			{
				num10 = -1;
			}
			else if (num6 > 0)
			{
				num10 = 1;
			}
			num9 = 0;
		}
		int num13 = num11 >> 1;
		for (int i = 0; i <= num11; i++)
		{
			float ratio = (float)i / (float)num11;
			int num14 = Interpolate(color1, color2, ratio);
			if (num >= DrawingAreaTopLeft.X && num < DrawingAreaBottomRight.X && num2 >= DrawingAreaTopLeft.Y && num2 < DrawingAreaBottomRight.Y)
			{
				if (isTransparent)
				{
					num14 = HandleSemiTransp(num, num2, num14, SemiTransparency);
				}
				num14 |= MaskWhileDrawing << 24;
				FrameData.SetPixel(num, num2, num14);
				ushort color3 = (ushort)rgb888To555(num14);
				RamData.SetPixel(num, num2, color3);
			}
			num13 += num12;
			if (num13 >= num11)
			{
				num13 -= num11;
				num += (short)num7;
				num2 += (short)num8;
			}
			else
			{
				num += (short)num9;
				num2 += (short)num10;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DrawRect(Point2D origin, Point2D size, TextureData texture, uint bgrColor, Primitive primitive)
	{
		int num = Math.Max(origin.X, DrawingAreaTopLeft.X);
		int num2 = Math.Max(origin.Y, DrawingAreaTopLeft.Y);
		int num3 = Math.Min(size.X, DrawingAreaBottomRight.X);
		int num4 = Math.Min(size.Y, DrawingAreaBottomRight.Y);
		int num5 = texture.X + (num - origin.X);
		int num6 = texture.Y + (num2 - origin.Y);
		int rgbColor = GetRgbColor(bgrColor);
		int num7 = num2;
		int num8 = num6;
		while (num7 < num4)
		{
			int i = num;
			for (int j = num5; i < num3; i++, j++)
			{
				if (CheckMaskBeforeDraw)
				{
					int y = num7 & 0x1FF;
					Color0.Value = (uint)FrameData.GetPixel(i & 0x3FF, y);
					if (Color0.M != 0)
					{
						continue;
					}
				}
				int num9 = rgbColor;
				if (primitive.IsTextured)
				{
					int num10 = GetTexel(MaskTexelAxis(j, TextureWindowPreMaskX, TextureWindowPostMaskX), MaskTexelAxis(num8, TextureWindowPreMaskY, TextureWindowPostMaskY), primitive.Clut, primitive.TextureBase, primitive.Depth);
					if (num10 == 0)
					{
						continue;
					}
					if (!primitive.IsRawTextured)
					{
						Color0.Value = (uint)num9;
						Color1.Value = (uint)num10;
						Color1.R = ClampToFF(Color0.R * Color1.R >> 7);
						Color1.G = ClampToFF(Color0.G * Color1.G >> 7);
						Color1.B = ClampToFF(Color0.B * Color1.B >> 7);
						num10 = (int)Color1.Value;
					}
					num9 = num10;
				}
				if (primitive.IsSemiTransparent && (!primitive.IsTextured || (num9 & 0xFF000000u) != 0L))
				{
					num9 = HandleSemiTransp(i, num7, num9, primitive.SemiTransparencyMode);
				}
				num9 |= MaskWhileDrawing << 24;
				FrameData.SetPixel(i, num7, num9);
				ushort color = (ushort)rgb888To555(num9);
				RamData.SetPixel(i, num7, color);
			}
			num7++;
			num8++;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DrawTriangle(Point2D v0, Point2D v1, Point2D v2, TextureData t0, TextureData t1, TextureData t2, uint c0, uint c1, uint c2, Primitive primitive)
	{
		int num = Orient2d(v0, v1, v2);
		if (num == 0)
		{
			return;
		}
		if (num < 0)
		{
			Point2D point2D = v2;
			v2 = v1;
			v1 = point2D;
			TextureData textureData = t2;
			t2 = t1;
			t1 = textureData;
			uint num2 = c2;
			c2 = c1;
			c1 = num2;
			num = -num;
		}
		int num3 = Math.Min(v0.X, Math.Min(v1.X, v2.X));
		int num4 = Math.Min(v0.Y, Math.Min(v1.Y, v2.Y));
		int num5 = Math.Max(v0.X, Math.Max(v1.X, v2.X));
		int num6 = Math.Max(v0.Y, Math.Max(v1.Y, v2.Y));
		if (num5 - num3 > 1024 || num6 - num4 > 512)
		{
			return;
		}
		short num7 = (short)Math.Max(num3, DrawingAreaTopLeft.X);
		short num8 = (short)Math.Max(num4, DrawingAreaTopLeft.Y);
		short num9 = (short)Math.Min(num5, DrawingAreaBottomRight.X);
		short num10 = (short)Math.Min(num6, DrawingAreaBottomRight.Y);
		int num11 = v0.Y - v1.Y;
		int num12 = v1.X - v0.X;
		int num13 = v1.Y - v2.Y;
		int num14 = v2.X - v1.X;
		int num15 = v2.Y - v0.Y;
		int num16 = v0.X - v2.X;
		int num17 = ((!IsTopLeft(v1, v2)) ? (-1) : 0);
		int num18 = ((!IsTopLeft(v2, v0)) ? (-1) : 0);
		int num19 = ((!IsTopLeft(v0, v1)) ? (-1) : 0);
		Point2D point2D2 = default(Point2D);
		point2D2.X = num7;
		point2D2.Y = num8;
		Point2D c3 = point2D2;
		int num20 = Orient2d(v1, v2, c3) + num17;
		int num21 = Orient2d(v2, v0, c3) + num18;
		int num22 = Orient2d(v0, v1, c3) + num19;
		int rgbColor = GetRgbColor(c0);
		for (int i = num8; i < num10; i++)
		{
			int num23 = num20;
			int num24 = num21;
			int num25 = num22;
			for (int j = num7; j < num9; j++)
			{
				if ((num23 | num24 | num25) >= 0)
				{
					if (CheckMaskBeforeDraw)
					{
						Color0.Value = (uint)FrameData.GetPixel(j, i);
						if (Color0.M != 0)
						{
							num23 += num13;
							num24 += num15;
							num25 += num11;
							continue;
						}
					}
					int num26 = rgbColor;
					if (primitive.IsShaded)
					{
						Color0.Value = c0;
						Color1.Value = c1;
						Color2.Value = c2;
						int num27 = Interpolate(num23 - num17, num24 - num18, num25 - num19, Color0.R, Color1.R, Color2.R, num);
						int num28 = Interpolate(num23 - num17, num24 - num18, num25 - num19, Color0.G, Color1.G, Color2.G, num);
						int num29 = Interpolate(num23 - num17, num24 - num18, num25 - num19, Color0.B, Color1.B, Color2.B, num);
						num26 = (num27 << 16) | (num28 << 8) | num29;
					}
					if (primitive.IsTextured)
					{
						int axis = Interpolate(num23 - num17, num24 - num18, num25 - num19, t0.X, t1.X, t2.X, num);
						int axis2 = Interpolate(num23 - num17, num24 - num18, num25 - num19, t0.Y, t1.Y, t2.Y, num);
						int num30 = GetTexel(MaskTexelAxis(axis, TextureWindowPreMaskX, TextureWindowPostMaskX), MaskTexelAxis(axis2, TextureWindowPreMaskY, TextureWindowPostMaskY), primitive.Clut, primitive.TextureBase, primitive.Depth);
						if (num30 == 0)
						{
							num23 += num13;
							num24 += num15;
							num25 += num11;
							continue;
						}
						if (!primitive.IsRawTextured)
						{
							Color0.Value = (uint)num26;
							Color1.Value = (uint)num30;
							Color1.R = ClampToFF(Color0.R * Color1.R >> 7);
							Color1.G = ClampToFF(Color0.G * Color1.G >> 7);
							Color1.B = ClampToFF(Color0.B * Color1.B >> 7);
							num30 = (int)Color1.Value;
						}
						num26 = num30;
					}
					if (primitive.IsSemiTransparent && (!primitive.IsTextured || (num26 & 0xFF000000u) != 0L))
					{
						num26 = HandleSemiTransp(j, i, num26, primitive.SemiTransparencyMode);
					}
					num26 |= MaskWhileDrawing << 24;
					FrameData.SetPixel(j, i, num26);
					ushort color = (ushort)rgb888To555(num26);
					RamData.SetPixel(j, i, color);
				}
				num23 += num13;
				num24 += num15;
				num25 += num11;
			}
			num20 += num14;
			num21 += num16;
			num22 += num12;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static byte ClampToFF(int v)
	{
		if (v > 255)
		{
			return byte.MaxValue;
		}
		return (byte)v;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static byte ClampToZero(int v)
	{
		if (v < 0)
		{
			return 0;
		}
		return (byte)v;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int Get4BppTexel(int x, int y, Point2D clut, Point2D textureBase)
	{
		int y2 = y + textureBase.Y;
		int num = (RamData.GetPixel(x / 4 + textureBase.X, y2) >> (x & 3) * 4) & 0xF;
		return FrameData.GetPixel(clut.X + num, clut.Y);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int Get8BppTexel(int x, int y, Point2D clut, Point2D textureBase)
	{
		int y2 = y + textureBase.Y;
		int num = (RamData.GetPixel(x / 2 + textureBase.X, y2) >> (x & 1) * 8) & 0xFF;
		return FrameData.GetPixel(clut.X + num, clut.Y);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int Get16BppTexel(int x, int y, Point2D textureBase)
	{
		int y2 = y + textureBase.Y;
		return FrameData.GetPixel(x + textureBase.X, y2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int GetTexel(int x, int y, Point2D clut, Point2D textureBase, int depth)
	{
		return depth switch
		{
			0 => Get4BppTexel(x, y, clut, textureBase), 
			1 => Get8BppTexel(x, y, clut, textureBase), 
			_ => Get16BppTexel(x, y, textureBase), 
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int GetRgbColor(uint value)
	{
		Color0.Value = value;
		return (Color0.M << 24) | (Color0.R << 16) | (Color0.G << 8) | Color0.B;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int HandleSemiTransp(int x, int y, int color, int semiTranspMode)
	{
		Color0.Value = (uint)FrameData.GetPixel(x, y);
		Color1.Value = (uint)color;
		switch (semiTranspMode)
		{
		case 0:
			Color1.R = (byte)(Color0.R + Color1.R >> 1);
			Color1.G = (byte)(Color0.G + Color1.G >> 1);
			Color1.B = (byte)(Color0.B + Color1.B >> 1);
			break;
		case 1:
			Color1.R = ClampToFF(Color0.R + Color1.R);
			Color1.G = ClampToFF(Color0.G + Color1.G);
			Color1.B = ClampToFF(Color0.B + Color1.B);
			break;
		case 2:
			Color1.R = ClampToZero(Color0.R - Color1.R);
			Color1.G = ClampToZero(Color0.G - Color1.G);
			Color1.B = ClampToZero(Color0.B - Color1.B);
			break;
		case 3:
			Color1.R = ClampToFF(Color0.R + (Color1.R >> 2));
			Color1.G = ClampToFF(Color0.G + (Color1.G >> 2));
			Color1.B = ClampToFF(Color0.B + (Color1.B >> 2));
			break;
		}
		return (int)Color1.Value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Interpolate(int w0, int w1, int w2, int t0, int t1, int t2, int area)
	{
		return (t0 * w0 + t1 * w1 + t2 * w2) / area;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int Interpolate(uint c1, uint c2, float ratio)
	{
		Color1.Value = c1;
		Color2.Value = c2;
		byte num = (byte)((float)(int)Color2.R * ratio + (float)(int)Color1.R * (1f - ratio));
		byte b = (byte)((float)(int)Color2.G * ratio + (float)(int)Color1.G * (1f - ratio));
		byte b2 = (byte)((float)(int)Color2.B * ratio + (float)(int)Color1.B * (1f - ratio));
		return (num << 16) | (b << 8) | b2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsTopLeft(Point2D a, Point2D b)
	{
		if (a.Y != b.Y || b.X <= a.X)
		{
			return b.Y < a.Y;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int MaskTexelAxis(int axis, int preMaskAxis, int postMaskAxis)
	{
		return (axis & 0xFF & preMaskAxis) | postMaskAxis;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Orient2d(Point2D a, Point2D b, Point2D c)
	{
		return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short Read11BitShort(uint value)
	{
		return (short)((int)(value << 21) >> 21);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static short rgb888To555(int color)
	{
		byte num = LookupTable888to555[color & 0xFF];
		int num2 = LookupTable888to555[(color >> 8) & 0xFF];
		int num3 = LookupTable888to555[(color >> 16) & 0xFF];
		return (short)((num << 10) | (num2 << 5) | num3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int rgb1555To8888(ushort color)
	{
		byte num = (byte)(color >> 15);
		byte b = LookupTable1555to8888[color & 0x1F];
		byte b2 = LookupTable1555to8888[(color >> 5) & 0x1F];
		byte b3 = LookupTable1555to8888[(color >> 10) & 0x1F];
		return (num << 24) | (b << 16) | (b2 << 8) | b3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ushort rgb8888to1555(int color)
	{
		byte num = (byte)((color & 0xFF000000u) >> 24);
		byte b = (byte)((color & 0xFF0000) >> 19);
		byte b2 = (byte)((color & 0xFF00) >> 11);
		byte b3 = (byte)((color & 0xFF) >> 3);
		return (ushort)((num << 15) | (b3 << 10) | (b2 << 5) | b);
	}
}
