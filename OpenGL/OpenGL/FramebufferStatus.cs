using Khronos;

namespace OpenGL;

public enum FramebufferStatus
{
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_surfaceless_context", Api = "gles1|gles2")]
	FramebufferUndefined = 33305,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	FramebufferComplete = 36053,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	FramebufferIncompleteAttachment = 36054,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	FramebufferIncompleteMissingAttachment = 36055,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	FramebufferIncompleteDrawBuffer = 36059,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	FramebufferIncompleteReadBuffer = 36060,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	FramebufferUnsupported = 36061,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_ANGLE_framebuffer_multisample", Api = "gles2")]
	[RequiredByFeature("GL_APPLE_framebuffer_multisample", Api = "gles1|gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_multisample")]
	[RequiredByFeature("GL_EXT_multisampled_render_to_texture", Api = "gles1|gles2")]
	[RequiredByFeature("GL_NV_framebuffer_multisample", Api = "gles2")]
	FramebufferIncompleteMultisample = 36182,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_geometry_shader4", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader4")]
	[RequiredByFeature("GL_NV_geometry_program4")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	FramebufferIncompleteLayerTargets = 36264
}
