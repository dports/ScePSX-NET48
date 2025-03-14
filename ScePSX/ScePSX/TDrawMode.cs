using System;

namespace ScePSX;

[Serializable]
public struct TDrawMode
{
	public byte TexturePageXBase;

	public byte TexturePageYBase;

	public byte SemiTransparency;

	public byte TexturePageColors;

	public bool Dither24BitTo15Bit;

	public bool DrawingToDisplayArea;

	public bool TextureDisable;

	public bool TexturedRectangleXFlip;

	public bool TexturedRectangleYFlip;
}
