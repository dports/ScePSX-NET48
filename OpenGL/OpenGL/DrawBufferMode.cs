using Khronos;

namespace OpenGL;

public enum DrawBufferMode
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_VERSION_4_6")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_KHR_context_flush_control", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	None = 0,
	[RequiredByFeature("GL_VERSION_1_0")]
	FrontLeft = 1024,
	[RequiredByFeature("GL_VERSION_1_0")]
	FrontRight = 1025,
	[RequiredByFeature("GL_VERSION_1_0")]
	BackLeft = 1026,
	[RequiredByFeature("GL_VERSION_1_0")]
	BackRight = 1027,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Front = 1028,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_ES3_1_compatibility", Api = "gl|glcore")]
	Back = 1029,
	[RequiredByFeature("GL_VERSION_1_0")]
	Left = 1030,
	[RequiredByFeature("GL_VERSION_1_0")]
	Right = 1031,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	FrontAndBack = 1032,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Aux0 = 1033,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Aux1 = 1034,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Aux2 = 1035,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Aux3 = 1036,
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
	ColorAttachment31 = 36095
}
