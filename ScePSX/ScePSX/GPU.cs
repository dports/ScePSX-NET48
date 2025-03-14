using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ScePSX;

[Serializable]
public class GPU
{
	private enum GPMode
	{
		COMMAND,
		VRAM
	}

	[Serializable]
	public struct TDisplayMode
	{
		public byte HorizontalResolution1;

		public bool IsVerticalResolution480;

		public bool IsPAL;

		public bool Is24BitDepth;

		public bool IsVerticalInterlace;

		public byte HorizontalResolution2;

		public bool IsReverseFlag;

		public TDisplayMode(uint value)
		{
			HorizontalResolution1 = (byte)(value & 3);
			IsVerticalResolution480 = (value & 4) != 0;
			IsPAL = (value & 8) != 0;
			Is24BitDepth = (value & 0x10) != 0;
			IsVerticalInterlace = (value & 0x20) != 0;
			HorizontalResolution2 = (byte)((value & 0x40) >> 6);
			IsReverseFlag = (value & 0x80) != 0;
		}
	}

	private static readonly int[] Resolutions = new int[5] { 256, 320, 512, 640, 368 };

	private static readonly int[] DotClockDiv = new int[5] { 10, 8, 5, 4, 7 };

	private readonly uint[] CommandBuffer = new uint[16];

	private bool CheckMaskBeforeDraw;

	private uint Command;

	private int CommandSize;

	public bool Debugging;

	private ushort DisplayVRAMStartX;

	private ushort DisplayVRAMStartY;

	private ushort DisplayX1;

	private ushort DisplayX2;

	private ushort DisplayY1;

	private ushort DisplayY2;

	private int horizontalRes;

	private int verticalRes;

	private int OutWidth;

	private int OutHeight;

	private byte DmaDirection;

	private TDrawingArea DrawingAreaTopLeft;

	private TDrawingArea DrawingAreaBottomRight;

	private TDrawingOffset DrawingOffset;

	private TDrawMode DrawMode;

	private uint GPUREADData;

	private bool IsDisplayDisabled;

	private bool IsDmaRequest;

	private bool IsInterlaceField;

	private bool IsInterruptRequested;

	private bool IsOddLine;

	private bool IsTextureDisabledAllowed;

	private int MaskWhileDrawing;

	private GPMode _Mode;

	private int Pointer;

	private int ScanLine;

	private TextureData _TextureData;

	private uint TextureWindowBits = uint.MaxValue;

	private int TimingHorizontal = 3413;

	private int TimingVertical = 263;

	private int VideoCycles;

	private VRAMTransfer _VRAMTransfer;

	private TDisplayMode DisplayMode;

	private int[] _Pixels = new int[524288];

	private uint SetTextureWindow_value;

	private uint SetMaskBit_value;

	private byte[] Ram;

	private byte[] FrameBuffer;

	[NonSerialized]
	public ICoreHandler host;

	[NonSerialized]
	public GPUManager Manger = new GPUManager();

	private static IReadOnlyList<byte> CommandSizeTable = new byte[256]
	{
		1, 1, 3, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 4, 4, 4, 4, 7, 7, 7, 7,
		5, 5, 5, 5, 9, 9, 9, 9, 6, 6,
		6, 6, 9, 9, 9, 9, 8, 8, 8, 8,
		12, 12, 12, 12, 3, 3, 3, 3, 3, 3,
		3, 3, 16, 16, 16, 16, 16, 16, 16, 16,
		4, 4, 4, 4, 4, 4, 4, 4, 16, 16,
		16, 16, 16, 16, 16, 16, 3, 3, 3, 1,
		4, 4, 4, 4, 2, 1, 2, 1, 3, 3,
		3, 3, 2, 1, 2, 1, 3, 3, 3, 3,
		2, 1, 2, 2, 3, 3, 3, 3, 4, 4,
		4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
		4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
		4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
		3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
		3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
		3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
		3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
		3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
		3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
		3, 3, 3, 3, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1
	};

	public GPU(ICoreHandler Host, GPUType type = GPUType.Software)
	{
		host = Host;
		_Mode = GPMode.COMMAND;
		Manger.SelectMode(type);
		GP1_00_ResetGPU();
	}

	public void ReadySerialized()
	{
		Ram = Manger.GPU.GetRam();
		FrameBuffer = Manger.GPU.GetFrameBuff();
	}

	public void DeSerialized()
	{
		Manger.GPU.SetRam(Ram);
		Manger.GPU.SetFrameBuff(FrameBuffer);
		Ram = null;
		FrameBuffer = null;
	}

	public void SelectGPU(GPUType type = GPUType.Software)
	{
		if (Manger.GPU != null)
		{
			ReadySerialized();
			Manger.SelectMode(type);
			DeSerialized();
		}
		else
		{
			Manger.SelectMode(type);
		}
		Manger.GPU.SetTextureWindow(SetTextureWindow_value);
		Manger.GPU.SetDrawingAreaTopLeft(DrawingAreaTopLeft);
		Manger.GPU.SetDrawingAreaBottomRight(DrawingAreaBottomRight);
		Manger.GPU.SetDrawingOffset(DrawingOffset);
		Manger.GPU.SetMaskBit(SetMaskBit_value);
		Manger.GPU.SetVRAMTransfer(_VRAMTransfer);
	}

	public bool tick(int cycles)
	{
		VideoCycles += cycles * 11 / 7;
		if (VideoCycles < TimingHorizontal)
		{
			return false;
		}
		VideoCycles -= TimingHorizontal;
		ScanLine++;
		if (!DisplayMode.IsVerticalResolution480)
		{
			IsOddLine = (ScanLine & 1) != 0;
		}
		if (ScanLine < TimingVertical)
		{
			return false;
		}
		ScanLine = 0;
		if (DisplayMode.IsVerticalInterlace && DisplayMode.IsVerticalResolution480)
		{
			IsOddLine = !IsOddLine;
		}
		(OutWidth, OutHeight) = Manger.GPU.GetPixels(DisplayMode.Is24BitDepth, DisplayY1, DisplayY2, DisplayVRAMStartX, DisplayVRAMStartY, horizontalRes, verticalRes, _Pixels);
		if (OutHeight > 0)
		{
			host.FrameReady(_Pixels, OutWidth, OutHeight);
		}
		return true;
	}

	public (int dot, bool hblank, bool bBlank) GetBlanksAndDot()
	{
		int item = DotClockDiv[(DisplayMode.HorizontalResolution2 << 2) | DisplayMode.HorizontalResolution1];
		bool item2 = VideoCycles < DisplayX1 || VideoCycles > DisplayX2;
		bool item3 = ScanLine < DisplayY1 || ScanLine > DisplayY2;
		return (dot: item, hblank: item2, bBlank: item3);
	}

	private uint GetTexpageFromGpu()
	{
		return 0 | ((DrawMode.TexturedRectangleYFlip ? 1u : 0u) << 13) | ((DrawMode.TexturedRectangleXFlip ? 1u : 0u) << 12) | ((DrawMode.TextureDisable ? 1u : 0u) << 11) | ((DrawMode.DrawingToDisplayArea ? 1u : 0u) << 10) | ((DrawMode.Dither24BitTo15Bit ? 1u : 0u) << 9) | (uint)(DrawMode.TexturePageColors << 7) | (uint)(DrawMode.SemiTransparency << 5) | (uint)(DrawMode.TexturePageYBase << 4) | DrawMode.TexturePageXBase;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void DecodeGP0Command(Span<uint> buffer)
	{
		while (Pointer < buffer.Length)
		{
			if (_Mode == GPMode.COMMAND)
			{
				Command = buffer[Pointer] >> 24;
				ExecuteGP0(Command, buffer);
			}
			else
			{
				WriteToVRAM(buffer[Pointer++]);
			}
		}
		Pointer = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void DecodeGP0Command(uint value)
	{
		if (Pointer == 0)
		{
			Command = value >> 24;
			CommandSize = CommandSizeTable[(int)Command];
		}
		CommandBuffer[Pointer++] = value;
		if (Pointer == CommandSize || (CommandSize == 16 && (value & 0xF000F000u) == 1342197760))
		{
			Pointer = 0;
			ExecuteGP0(Command, CommandBuffer.AsSpan());
			Pointer = 0;
		}
	}

	private void ExecuteGP0(uint opcode, Span<uint> buffer)
	{
		switch (opcode)
		{
		case 0u:
			GP0_00_NOP();
			return;
		case 1u:
			GP0_01_MemClearCache();
			return;
		case 2u:
			GP0_02_FillRectVRAM(buffer);
			return;
		case 31u:
			GP0_1F_InterruptRequest();
			return;
		case 225u:
			GP0_E1_SetDrawMode(buffer[Pointer++]);
			return;
		case 226u:
			GP0_E2_SetTextureWindow(buffer[Pointer++]);
			return;
		case 227u:
			GP0_E3_SetDrawingAreaTopLeft(buffer[Pointer++]);
			return;
		case 228u:
			GP0_E4_SetDrawingAreaBottomRight(buffer[Pointer++]);
			return;
		case 229u:
			GP0_E5_SetDrawingOffset(buffer[Pointer++]);
			return;
		case 230u:
			GP0_E6_SetMaskBit(buffer[Pointer++]);
			return;
		}
		if (opcode >= 32 && opcode <= 63)
		{
			GP0_RenderPolygon(buffer);
			return;
		}
		if (opcode >= 64 && opcode <= 95)
		{
			GP0_RenderLine(buffer);
			return;
		}
		if (opcode >= 96 && opcode <= 127)
		{
			GP0_RenderRectangle(buffer);
			return;
		}
		if (opcode >= 128 && opcode <= 159)
		{
			GP0_MemCopyRectVRAMtoVRAM(buffer);
			return;
		}
		if (opcode >= 160 && opcode <= 191)
		{
			GP0_MemCopyRectCPUtoVRAM(buffer);
			return;
		}
		if (opcode >= 192 && opcode <= 223)
		{
			GP0_MemCopyRectVRAMtoCPU(buffer);
			return;
		}
		if (opcode < 3 || opcode > 30)
		{
			switch (opcode)
			{
			case 224u:
			case 231u:
			case 232u:
			case 233u:
			case 234u:
			case 235u:
			case 236u:
			case 237u:
			case 238u:
			case 239u:
				break;
			default:
				GP0_00_NOP();
				return;
			}
		}
		GP0_00_NOP();
	}

	public uint GPUREAD()
	{
		if (_VRAMTransfer.HalfWords > 0)
		{
			return Manger.GPU.ReadFromVRAM();
		}
		return GPUREADData;
	}

	public uint GPUSTAT()
	{
		return (uint)(0 | DrawMode.TexturePageXBase | (DrawMode.TexturePageYBase << 4) | (DrawMode.SemiTransparency << 5) | (DrawMode.TexturePageColors << 7)) | ((DrawMode.Dither24BitTo15Bit ? 1u : 0u) << 9) | ((DrawMode.DrawingToDisplayArea ? 1u : 0u) << 10) | (uint)(MaskWhileDrawing << 11) | ((CheckMaskBeforeDraw ? 1u : 0u) << 12) | ((IsInterlaceField ? 1u : 0u) << 13) | ((DisplayMode.IsReverseFlag ? 1u : 0u) << 14) | ((DrawMode.TextureDisable ? 1u : 0u) << 15) | (uint)(DisplayMode.HorizontalResolution2 << 16) | (uint)(DisplayMode.HorizontalResolution1 << 17) | (DisplayMode.IsVerticalResolution480 ? 1u : 0u) | ((DisplayMode.IsPAL ? 1u : 0u) << 20) | ((DisplayMode.Is24BitDepth ? 1u : 0u) << 21) | ((DisplayMode.IsVerticalInterlace ? 1u : 0u) << 22) | ((IsDisplayDisabled ? 1u : 0u) << 23) | ((IsInterruptRequested ? 1u : 0u) << 24) | ((IsDmaRequest ? 1u : 0u) << 25) | 0x4000000 | 0x8000000 | 0x10000000 | (uint)(DmaDirection << 29) | ((IsOddLine ? 1u : 0u) << 31);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ProcessDma(Span<uint> dma)
	{
		if (_Mode == GPMode.COMMAND)
		{
			DecodeGP0Command(dma);
			return;
		}
		Span<uint> span = dma;
		for (int i = 0; i < span.Length; i++)
		{
			uint value = span[i];
			WriteToVRAM(value);
		}
	}

	public void write(uint address, uint value)
	{
		switch (address & 0xF)
		{
		case 0u:
			WriteGP0(value);
			break;
		case 4u:
			WriteGP1(value);
			break;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void WriteGP0(uint value)
	{
		if (_Mode == GPMode.COMMAND)
		{
			DecodeGP0Command(value);
		}
		else
		{
			WriteToVRAM(value);
		}
	}

	public void WriteGP1(uint value)
	{
		uint num = value >> 24;
		switch (num)
		{
		case 0u:
			GP1_00_ResetGPU();
			return;
		case 1u:
			GP1_01_ResetCommandBuffer();
			return;
		case 2u:
			GP1_02_AckGPUInterrupt();
			return;
		case 3u:
			GP1_03_DisplayEnable(value);
			return;
		case 4u:
			GP1_04_DMADirection(value);
			return;
		case 5u:
			GP1_05_DisplayVRAMStart(value);
			return;
		case 6u:
			GP1_06_DisplayHorizontalRange(value);
			return;
		case 7u:
			GP1_07_DisplayVerticalRange(value);
			return;
		case 8u:
			GP1_08_DisplayMode(value);
			return;
		case 9u:
			GP1_09_TextureDisable(value);
			return;
		case 16u:
		case 17u:
		case 18u:
		case 19u:
		case 20u:
		case 21u:
		case 22u:
		case 23u:
		case 24u:
		case 25u:
		case 26u:
		case 27u:
		case 28u:
		case 29u:
		case 30u:
		case 31u:
			GP1_GPUInfo(value);
			return;
		}
		Console.WriteLine("Unsupported GP1 Command: {Opcode}", $"0x{num:X8}");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteToVRAM(uint value)
	{
		ushort num = (ushort)(value >> 16);
		ushort num2 = (ushort)(value & 0xFFFF);
		num2 |= (ushort)(MaskWhileDrawing << 15);
		num |= (ushort)(MaskWhileDrawing << 15);
		Manger.GPU.DrawPixel(num2);
		if (--_VRAMTransfer.HalfWords == 0)
		{
			_Mode = GPMode.COMMAND;
			return;
		}
		Manger.GPU.DrawPixel(num);
		if (--_VRAMTransfer.HalfWords == 0)
		{
			_Mode = GPMode.COMMAND;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void GP0_00_NOP()
	{
		Pointer++;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void GP0_01_MemClearCache()
	{
		Pointer++;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void GP0_02_FillRectVRAM(Span<uint> buffer)
	{
		uint colorval = buffer[Pointer++];
		uint num = buffer[Pointer++];
		uint num2 = buffer[Pointer++];
		ushort x = (ushort)(num & 0x3F0);
		ushort y = (ushort)((num >> 16) & 0x1FF);
		ushort w = (ushort)(((num2 & 0x3FF) + 15) & -16);
		ushort h = (ushort)((num2 >> 16) & 0x1FF);
		Manger.GPU.FillRectVRAM(x, y, w, h, colorval);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void GP0_1F_InterruptRequest()
	{
		Pointer++;
		IsInterruptRequested = true;
	}

	private void GP0_E1_SetDrawMode(uint val)
	{
		DrawMode.TexturePageXBase = (byte)(val & 0xF);
		DrawMode.TexturePageYBase = (byte)((val >> 4) & 1);
		DrawMode.SemiTransparency = (byte)((val >> 5) & 3);
		DrawMode.TexturePageColors = (byte)((val >> 7) & 3);
		DrawMode.Dither24BitTo15Bit = ((val >> 9) & 1) != 0;
		DrawMode.DrawingToDisplayArea = ((val >> 10) & 1) != 0;
		DrawMode.TextureDisable = IsTextureDisabledAllowed && ((val >> 11) & 1) != 0;
		DrawMode.TexturedRectangleXFlip = ((val >> 12) & 1) != 0;
		DrawMode.TexturedRectangleYFlip = ((val >> 13) & 1) != 0;
	}

	private void GP0_E2_SetTextureWindow(uint value)
	{
		SetTextureWindow_value = value;
		uint num = value & 0xFFFFFF;
		if (num != TextureWindowBits)
		{
			TextureWindowBits = num;
			Manger.GPU.SetTextureWindow(value);
		}
	}

	private void GP0_E3_SetDrawingAreaTopLeft(uint value)
	{
		DrawingAreaTopLeft = new TDrawingArea(value);
		Manger.GPU.SetDrawingAreaTopLeft(DrawingAreaTopLeft);
	}

	private void GP0_E4_SetDrawingAreaBottomRight(uint value)
	{
		DrawingAreaBottomRight = new TDrawingArea(value);
		Manger.GPU.SetDrawingAreaBottomRight(DrawingAreaBottomRight);
	}

	private void GP0_E5_SetDrawingOffset(uint value)
	{
		DrawingOffset = new TDrawingOffset(value);
		Manger.GPU.SetDrawingOffset(DrawingOffset);
	}

	private void GP0_E6_SetMaskBit(uint value)
	{
		SetMaskBit_value = value;
		MaskWhileDrawing = (int)(value & 1);
		CheckMaskBeforeDraw = (value & 2) != 0;
		Manger.GPU.SetMaskBit(value);
	}

	private void GP0_RenderLine(Span<uint> buffer)
	{
		uint num = buffer[Pointer++];
		uint num2 = num & 0xFFFFFF;
		uint num3 = num2;
		bool flag = (num & 0x8000000) != 0;
		bool flag2 = (num & 0x10000000) != 0;
		bool isTransparent = (num & 0x2000000) != 0;
		uint v = buffer[Pointer++];
		if (flag2)
		{
			num3 = buffer[Pointer++];
		}
		uint num4 = buffer[Pointer++];
		Manger.GPU.DrawLine(v, num4, num2, num3, isTransparent, DrawMode.SemiTransparency);
		if (!flag)
		{
			return;
		}
		while ((buffer[Pointer] & 0xF000F000u) != 1342197760)
		{
			num2 = num3;
			if (flag2)
			{
				num3 = buffer[Pointer++];
			}
			v = num4;
			num4 = buffer[Pointer++];
			Manger.GPU.DrawLine(v, num4, num2, num3, isTransparent, DrawMode.SemiTransparency);
		}
		Pointer++;
	}

	public void GP0_RenderPolygon(Span<uint> buffer)
	{
		uint num = buffer[Pointer];
		bool flag = (num & 0x8000000) != 0;
		bool flag2 = (num & 0x10000000) != 0;
		bool flag3 = (num & 0x4000000) != 0;
		bool isSemiTransparent = (num & 0x2000000) != 0;
		bool isRawTextured = (num & 0x1000000) != 0;
		Primitive primitive = default(Primitive);
		primitive.IsShaded = flag2;
		primitive.IsTextured = flag3;
		primitive.IsSemiTransparent = isSemiTransparent;
		primitive.IsRawTextured = isRawTextured;
		Primitive primitive2 = primitive;
		int num2 = (flag ? 4 : 3);
		Span<uint> span = stackalloc uint[num2];
		Span<Point2D> span2 = stackalloc Point2D[num2];
		Span<TextureData> span3 = stackalloc TextureData[num2];
		if (!flag2)
		{
			uint num3 = buffer[Pointer++];
			span[0] = num3;
			span[1] = num3;
		}
		primitive2.SemiTransparencyMode = DrawMode.SemiTransparency;
		for (int i = 0; i < num2; i++)
		{
			if (flag2)
			{
				span[i] = buffer[Pointer++];
			}
			uint num4 = buffer[Pointer++];
			span2[i].X = (short)(Read11BitShort(num4 & 0xFFFF) + DrawingOffset.X);
			span2[i].Y = (short)(Read11BitShort(num4 >> 16) + DrawingOffset.Y);
			if (flag3)
			{
				uint num5 = buffer[Pointer++];
				span3[i].Value = (ushort)num5;
				switch (i)
				{
				case 0:
				{
					uint num7 = num5 >> 16;
					primitive2.Clut.X = (short)((num7 & 0x3F) << 4);
					primitive2.Clut.Y = (short)((num7 >> 6) & 0x1FF);
					break;
				}
				case 1:
				{
					uint num6 = num5 >> 16;
					DrawMode.TexturePageXBase = (byte)(num6 & 0xF);
					DrawMode.TexturePageYBase = (byte)((num6 >> 4) & 1);
					DrawMode.SemiTransparency = (byte)((num6 >> 5) & 3);
					DrawMode.TexturePageColors = (byte)((num6 >> 7) & 3);
					DrawMode.TextureDisable = IsTextureDisabledAllowed && ((num6 >> 11) & 1) != 0;
					primitive2.Depth = DrawMode.TexturePageColors;
					primitive2.TextureBase.X = (short)(DrawMode.TexturePageXBase << 6);
					primitive2.TextureBase.Y = (short)(DrawMode.TexturePageYBase << 8);
					primitive2.SemiTransparencyMode = DrawMode.SemiTransparency;
					break;
				}
				}
			}
		}
		Manger.GPU.DrawTriangle(span2[0], span2[1], span2[2], span3[0], span3[1], span3[2], span[0], span[1], span[2], primitive2);
		if (flag)
		{
			Manger.GPU.DrawTriangle(span2[1], span2[2], span2[3], span3[1], span3[2], span3[3], span[1], span[2], span[3], primitive2);
		}
	}

	private void GP0_RenderRectangle(Span<uint> buffer)
	{
		uint num = buffer[Pointer++];
		uint bgrColor = num & 0xFFFFFF;
		uint num2 = num >> 24;
		bool flag = (num & 0x4000000) != 0;
		bool isSemiTransparent = (num & 0x2000000) != 0;
		bool isRawTextured = (num & 0x1000000) != 0;
		Primitive primitive = default(Primitive);
		primitive.IsTextured = flag;
		primitive.IsSemiTransparent = isSemiTransparent;
		primitive.IsRawTextured = isRawTextured;
		Primitive primitive2 = primitive;
		uint num3 = buffer[Pointer++];
		short num4 = (short)(num3 & 0xFFFF);
		short num5 = (short)(num3 >> 16);
		if (flag)
		{
			uint num6 = buffer[Pointer++];
			_TextureData.X = (byte)(num6 & 0xFF);
			_TextureData.Y = (byte)((num6 >> 8) & 0xFF);
			ushort num7 = (ushort)((num6 >> 16) & 0xFFFF);
			primitive2.Clut.X = (short)((num7 & 0x3F) << 4);
			primitive2.Clut.Y = (short)((num7 >> 6) & 0x1FF);
		}
		primitive2.Depth = DrawMode.TexturePageColors;
		primitive2.TextureBase.X = (short)(DrawMode.TexturePageXBase << 6);
		primitive2.TextureBase.Y = (short)(DrawMode.TexturePageYBase << 8);
		primitive2.SemiTransparencyMode = DrawMode.SemiTransparency;
		short num8 = 0;
		short num9 = 0;
		switch ((num2 & 0x18) >> 3)
		{
		case 0u:
		{
			uint num10 = buffer[Pointer++];
			num8 = (short)(num10 & 0xFFFF);
			num9 = (short)(num10 >> 16);
			break;
		}
		case 1u:
			num8 = 1;
			num9 = 1;
			break;
		case 2u:
			num8 = 8;
			num9 = 8;
			break;
		case 3u:
			num8 = 16;
			num9 = 16;
			break;
		}
		short num11 = Read11BitShort((uint)(num5 + DrawingOffset.Y));
		Point2D origin = default(Point2D);
		short num12 = (origin.X = Read11BitShort((uint)(num4 + DrawingOffset.X)));
		origin.Y = num11;
		Point2D size = default(Point2D);
		size.X = (short)(num12 + num8);
		size.Y = (short)(num11 + num9);
		Manger.GPU.DrawRect(origin, size, _TextureData, bgrColor, primitive2);
	}

	private void GP0_MemCopyRectVRAMtoVRAM(Span<uint> buffer)
	{
		Pointer++;
		uint num = buffer[Pointer++];
		uint num2 = buffer[Pointer++];
		uint num3 = buffer[Pointer++];
		ushort sx = (ushort)(num & 0x3FF);
		ushort sy = (ushort)((num >> 16) & 0x1FF);
		ushort dx = (ushort)(num2 & 0x3FF);
		ushort dy = (ushort)((num2 >> 16) & 0x1FF);
		ushort w = (ushort)((((num3 & 0xFFFF) - 1) & 0x3FF) + 1);
		ushort h = (ushort)((((num3 >> 16) - 1) & 0x1FF) + 1);
		Manger.GPU.CopyRectVRAMtoVRAM(sx, sy, dx, dy, w, h);
	}

	private void GP0_MemCopyRectCPUtoVRAM(Span<uint> buffer)
	{
		Pointer++;
		uint num = buffer[Pointer++];
		uint num2 = buffer[Pointer++];
		ushort num3 = (ushort)(num & 0x3FF);
		ushort num4 = (ushort)((num >> 16) & 0x1FF);
		ushort num5 = (ushort)((((num2 & 0xFFFF) - 1) & 0x3FF) + 1);
		ushort num6 = (ushort)((((num2 >> 16) - 1) & 0x1FF) + 1);
		_VRAMTransfer.X = num3;
		_VRAMTransfer.Y = num4;
		_VRAMTransfer.W = num5;
		_VRAMTransfer.H = num6;
		_VRAMTransfer.OriginX = num3;
		_VRAMTransfer.OriginY = num4;
		_VRAMTransfer.HalfWords = num5 * num6;
		Manger.GPU.SetVRAMTransfer(_VRAMTransfer);
		_Mode = GPMode.VRAM;
	}

	private void GP0_MemCopyRectVRAMtoCPU(Span<uint> buffer)
	{
		Pointer++;
		uint num = buffer[Pointer++];
		uint num2 = buffer[Pointer++];
		ushort num3 = (ushort)(num & 0x3FF);
		ushort num4 = (ushort)((num >> 16) & 0x1FF);
		ushort num5 = (ushort)((((num2 & 0xFFFF) - 1) & 0x3FF) + 1);
		ushort num6 = (ushort)((((num2 >> 16) - 1) & 0x1FF) + 1);
		_VRAMTransfer.X = num3;
		_VRAMTransfer.Y = num4;
		_VRAMTransfer.W = num5;
		_VRAMTransfer.H = num6;
		_VRAMTransfer.OriginX = num3;
		_VRAMTransfer.OriginY = num4;
		_VRAMTransfer.HalfWords = num5 * num6;
		Manger.GPU.SetVRAMTransfer(_VRAMTransfer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short Read11BitShort(uint value)
	{
		return (short)((int)(value << 21) >> 21);
	}

	private void GP1_00_ResetGPU()
	{
		GP1_01_ResetCommandBuffer();
		GP1_02_AckGPUInterrupt();
		GP1_03_DisplayEnable(1u);
		GP1_04_DMADirection(0u);
		GP1_05_DisplayVRAMStart(0u);
		GP1_06_DisplayHorizontalRange(12583424u);
		GP1_07_DisplayVerticalRange(1048592u);
		GP1_08_DisplayMode(0u);
		GP0_E1_SetDrawMode(0u);
		GP0_E2_SetTextureWindow(0u);
		GP0_E3_SetDrawingAreaTopLeft(0u);
		GP0_E4_SetDrawingAreaBottomRight(0u);
		GP0_E5_SetDrawingOffset(0u);
		GP0_E6_SetMaskBit(0u);
	}

	private void GP1_01_ResetCommandBuffer()
	{
		Pointer = 0;
	}

	private void GP1_02_AckGPUInterrupt()
	{
		IsInterruptRequested = false;
	}

	private void GP1_03_DisplayEnable(uint value)
	{
		IsDisplayDisabled = (value & 1) != 0;
	}

	private void GP1_04_DMADirection(uint value)
	{
		DmaDirection = (byte)(value & 3);
	}

	private void GP1_05_DisplayVRAMStart(uint value)
	{
		DisplayVRAMStartX = (ushort)(value & 0x3FE);
		DisplayVRAMStartY = (ushort)((value >> 10) & 0x1FE);
	}

	private void GP1_06_DisplayHorizontalRange(uint value)
	{
		DisplayX1 = (ushort)(value & 0xFFF);
		DisplayX2 = (ushort)((value >> 12) & 0xFFF);
	}

	private void GP1_07_DisplayVerticalRange(uint value)
	{
		DisplayY1 = (ushort)(value & 0x3FF);
		DisplayY2 = (ushort)((value >> 10) & 0x3FF);
	}

	private void GP1_08_DisplayMode(uint value)
	{
		DisplayMode = new TDisplayMode(value);
		IsInterlaceField = DisplayMode.IsVerticalInterlace;
		TimingHorizontal = (DisplayMode.IsPAL ? 3406 : 3413);
		TimingVertical = (DisplayMode.IsPAL ? 314 : 263);
		horizontalRes = Resolutions[(DisplayMode.HorizontalResolution2 << 2) | DisplayMode.HorizontalResolution1];
		verticalRes = (DisplayMode.IsVerticalResolution480 ? 480 : 240);
	}

	private void GP1_09_TextureDisable(uint value)
	{
		IsTextureDisabledAllowed = (value & 1) != 0;
	}

	private void GP1_GPUInfo(uint value)
	{
		switch (value & 0xF)
		{
		case 2u:
			GPUREADData = TextureWindowBits;
			break;
		case 3u:
			GPUREADData = (uint)((DrawingAreaTopLeft.Y << 10) | DrawingAreaTopLeft.X);
			break;
		case 4u:
			GPUREADData = (uint)((DrawingAreaBottomRight.Y << 10) | DrawingAreaBottomRight.X);
			break;
		case 5u:
			GPUREADData = (uint)((DrawingOffset.Y << 11) | (ushort)DrawingOffset.X);
			break;
		case 7u:
			GPUREADData = 2u;
			break;
		case 8u:
			GPUREADData = 0u;
			break;
		case 6u:
			break;
		}
	}
}
