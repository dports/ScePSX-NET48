using Khronos;

namespace OpenGL;

public enum FramebufferAttachment
{
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	DepthStencilAttachment = 33306,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	ColorAttachment0 = 36064,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment1 = 36065,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment2 = 36066,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment3 = 36067,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment4 = 36068,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment5 = 36069,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment6 = 36070,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment7 = 36071,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment8 = 36072,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment9 = 36073,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment10 = 36074,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment11 = 36075,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment12 = 36076,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment13 = 36077,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment14 = 36078,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_NV_draw_buffers", Api = "gles2")]
	[RequiredByFeature("GL_NV_fbo_color_attachments", Api = "gles2")]
	ColorAttachment15 = 36079,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment16 = 36080,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment17 = 36081,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment18 = 36082,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment19 = 36083,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment20 = 36084,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment21 = 36085,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment22 = 36086,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment23 = 36087,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment24 = 36088,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment25 = 36089,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment26 = 36090,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment27 = 36091,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment28 = 36092,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment29 = 36093,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment30 = 36094,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	ColorAttachment31 = 36095,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	DepthAttachment = 36096,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	StencilAttachment = 36128,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	ShadingRateAttachmentExt = 38609
}
