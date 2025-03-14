using Khronos;

namespace OpenGL;

public enum PathStringFormat
{
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathFormatSvgNv = 36976,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathFormatPsNv
}
