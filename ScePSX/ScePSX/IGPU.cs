using System;

namespace ScePSX;

public interface IGPU : IDisposable
{
	GPUType type { get; }

	void Initialize();

	void SetParams(int[] Params);

	void SetRam(byte[] Ram);

	byte[] GetRam();

	void SetFrameBuff(byte[] FrameBuffer);

	byte[] GetFrameBuff();

	(int w, int h) GetPixels(bool is24bit, int dy1, int dy2, int rx, int ry, int w, int h, int[] Pixels);

	uint ReadFromVRAM();

	void SetMaskBit(uint val);

	void SetVRAMTransfer(VRAMTransfer val);

	void SetDrawingAreaTopLeft(TDrawingArea value);

	void SetDrawingAreaBottomRight(TDrawingArea value);

	void SetDrawingOffset(TDrawingOffset value);

	void SetTextureWindow(uint value);

	void FillRectVRAM(ushort x, ushort y, ushort w, ushort h, uint colorval);

	void CopyRectVRAMtoVRAM(ushort sx, ushort sy, ushort dx, ushort dy, ushort w, ushort h);

	void DrawPixel(ushort value);

	void DrawLine(uint v1, uint v2, uint color1, uint color2, bool isTransparent, int SemiTransparenc);

	void DrawRect(Point2D origin, Point2D size, TextureData texture, uint bgrColor, Primitive primitive);

	void DrawTriangle(Point2D v0, Point2D v1, Point2D v2, TextureData t0, TextureData t1, TextureData t2, uint c0, uint c1, uint c2, Primitive primitive);
}
