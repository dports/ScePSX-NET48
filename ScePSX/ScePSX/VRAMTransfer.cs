using System;

namespace ScePSX;

[Serializable]
public struct VRAMTransfer
{
	public int X;

	public int Y;

	public ushort W;

	public ushort H;

	public int OriginX;

	public int OriginY;

	public int HalfWords;
}
