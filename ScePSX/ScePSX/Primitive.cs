using System;

namespace ScePSX;

[Serializable]
public struct Primitive
{
	public bool IsShaded;

	public bool IsTextured;

	public bool IsSemiTransparent;

	public bool IsRawTextured;

	public int Depth;

	public int SemiTransparencyMode;

	public Point2D Clut;

	public Point2D TextureBase;
}
