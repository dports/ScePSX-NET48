using Khronos;

namespace OpenGL;

public enum PathHandleMissingGlyphs
{
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	SkipMissingGlyphNv = 37033,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	UseMissingGlyphNv
}
