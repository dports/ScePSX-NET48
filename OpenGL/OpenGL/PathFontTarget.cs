using Khronos;

namespace OpenGL;

public enum PathFontTarget
{
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	StandardFontNameNv = 36978,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	SystemFontNameNv,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	FileNameNv
}
