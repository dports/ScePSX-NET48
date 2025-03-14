using System;

namespace DirectX.D2D1;

[Flags]
public enum D2D1PresentOptions
{
	None = 0,
	RetainContents = 1,
	Immediately = 2
}
