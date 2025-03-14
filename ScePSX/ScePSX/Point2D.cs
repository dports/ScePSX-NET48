using System;
using System.Runtime.InteropServices;

namespace ScePSX;

[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct Point2D
{
	[FieldOffset(0)]
	public short X;

	[FieldOffset(2)]
	public short Y;
}
