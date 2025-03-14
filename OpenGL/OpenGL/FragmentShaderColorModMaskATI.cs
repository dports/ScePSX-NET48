using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum FragmentShaderColorModMaskATI : uint
{
	_2xBitAti = 1u,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	CompBitAti = 2u,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	NegateBitAti = 4u,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	BiasBitAti = 8u
}
