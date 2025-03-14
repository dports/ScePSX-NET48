using System;

namespace DirectX.D2D1;

[Flags]
public enum D2D1RenderTargetUsages
{
	None = 0,
	ForceBitmapRemoting = 1,
	GdiCompatible = 2
}
