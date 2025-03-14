using Khronos;

namespace OpenGL;

public enum FramebufferTarget
{
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_ANGLE_framebuffer_blit", Api = "gles2")]
	[RequiredByFeature("GL_APPLE_framebuffer_multisample", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_blit")]
	[RequiredByFeature("GL_NV_framebuffer_blit", Api = "gles2")]
	ReadFramebuffer = 36008,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_ANGLE_framebuffer_blit", Api = "gles2")]
	[RequiredByFeature("GL_APPLE_framebuffer_multisample", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_blit")]
	[RequiredByFeature("GL_NV_framebuffer_blit", Api = "gles2")]
	DrawFramebuffer = 36009,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	Framebuffer = 36160
}
