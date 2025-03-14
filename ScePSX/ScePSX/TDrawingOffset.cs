using System;

namespace ScePSX;

[Serializable]
public struct TDrawingOffset
{
	public short X;

	public short Y;

	public TDrawingOffset(uint value)
	{
		X = GPU.Read11BitShort(value & 0x7FF);
		Y = GPU.Read11BitShort((value >> 11) & 0x7FF);
	}
}
