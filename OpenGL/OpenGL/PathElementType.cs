using Khronos;

namespace OpenGL;

public enum PathElementType
{
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	Utf8Nv = 37018,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	Utf16Nv
}
