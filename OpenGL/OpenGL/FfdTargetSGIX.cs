using Khronos;

namespace OpenGL;

public enum FfdTargetSGIX
{
	[RequiredByFeature("GL_SGIX_polynomial_ffd")]
	GeometryDeformationSgix = 33172,
	[RequiredByFeature("GL_SGIX_polynomial_ffd")]
	TextureDeformationSgix
}
