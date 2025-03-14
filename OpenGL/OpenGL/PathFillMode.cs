using Khronos;

namespace OpenGL;

public enum PathFillMode
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
	Invert = 5386,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathFillModeNv = 36992,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	CountUpNv = 37000,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	CountDownNv = 37001
}
