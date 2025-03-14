using System;
using System.Runtime.InteropServices;

namespace ScePSX;

[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct GPUColor
{
	[FieldOffset(0)]
	public uint Value;

	[FieldOffset(0)]
	public byte R;

	[FieldOffset(1)]
	public byte G;

	[FieldOffset(2)]
	public byte B;

	[FieldOffset(3)]
	public byte M;
}
