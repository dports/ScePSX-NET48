using Khronos;

namespace OpenGL;

public enum PixelCopyType
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_discard_framebuffer", Api = "gles1|gles2")]
	Color = 6144,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_discard_framebuffer", Api = "gles1|gles2")]
	Depth,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_discard_framebuffer", Api = "gles1|gles2")]
	Stencil
}
