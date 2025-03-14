using System;
using System.Runtime.InteropServices;

namespace ScePSX;

[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct TextureData
{
	[FieldOffset(0)]
	public ushort Value;

	[FieldOffset(0)]
	public byte X;

	[FieldOffset(1)]
	public byte Y;
}
