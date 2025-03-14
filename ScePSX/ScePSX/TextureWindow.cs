using System;

namespace ScePSX;

[Serializable]
public struct TextureWindow
{
	public byte MaskX;

	public byte MaskY;

	public byte OffsetX;

	public byte OffsetY;

	public TextureWindow(uint value)
	{
		MaskX = (byte)(value & 0x1F);
		MaskY = (byte)((value >> 5) & 0x1F);
		OffsetX = (byte)((value >> 10) & 0x1F);
		OffsetY = (byte)((value >> 15) & 0x1F);
	}
}
