using Khronos;

namespace OpenGL;

public enum ObjectIdentifier
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	Texture = 5890,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	VertexArray = 32884,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	Buffer = 33504,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	Shader = 33505,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	Program = 33506,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	Query = 33507,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	ProgramPipeline = 33508,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_EXT_debug_label", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	Sampler = 33510,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	Framebuffer = 36160,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_internalformat_sample_query", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_EXT_framebuffer_object")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	Renderbuffer = 36161,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_debug_label", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_transform_feedback2")]
	TransformFeedback = 36386
}
