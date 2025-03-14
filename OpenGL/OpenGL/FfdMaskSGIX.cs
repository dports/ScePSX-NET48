using System;
using Khronos;

namespace OpenGL;

[Flags]
public enum FfdMaskSGIX : uint
{
	[RequiredByFeature("GL_SGIX_polynomial_ffd")]
	TextureDeformationBitSgix = 1u,
	[RequiredByFeature("GL_SGIX_polynomial_ffd")]
	GeometryDeformationBitSgix = 2u
}
