using Khronos;

namespace OpenGL;

public enum FramebufferAttachmentParameterName
{
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_sRGB", Api = "gles1|gles2")]
	FramebufferAttachmentColorEncoding = 33296,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_color_buffer_half_float", Api = "gles2")]
	FramebufferAttachmentComponentType = 33297,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	FramebufferAttachmentRedSize = 33298,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	FramebufferAttachmentGreenSize = 33299,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	FramebufferAttachmentBlueSize = 33300,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	FramebufferAttachmentAlphaSize = 33301,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	FramebufferAttachmentDepthSize = 33302,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	FramebufferAttachmentStencilSize = 33303,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	FramebufferAttachmentObjectType = 36048,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	FramebufferAttachmentObjectName = 36049,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	FramebufferAttachmentTextureLevel = 36050,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	FramebufferAttachmentTextureCubeMapFace = 36051,
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_texture_3D", Api = "gles2")]
	FramebufferAttachmentTexture3dZoffsetExt = 36052,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_geometry_shader4", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader4")]
	[RequiredByFeature("GL_EXT_texture_array")]
	[RequiredByFeature("GL_NV_geometry_program4")]
	FramebufferAttachmentTextureLayer = 36052,
	[RequiredByFeature("GL_EXT_multisampled_render_to_texture", Api = "gles1|gles2")]
	FramebufferAttachmentTextureSamplesExt = 36204,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_geometry_shader4", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader4")]
	[RequiredByFeature("GL_NV_geometry_program4")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	FramebufferAttachmentLayered = 36263,
	[RequiredByFeature("GL_IMG_framebuffer_downsample", Api = "gles2")]
	FramebufferAttachmentTextureScaleImg = 37183,
	[RequiredByFeature("GL_OVR_multiview", Api = "gl|glcore|gles2")]
	FramebufferAttachmentTextureNumViewsOvr = 38448,
	[RequiredByFeature("GL_OVR_multiview", Api = "gl|glcore|gles2")]
	FramebufferAttachmentTextureBaseViewIndexOvr = 38450
}
