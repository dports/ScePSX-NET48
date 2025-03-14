using Khronos;

namespace OpenGL;

public enum BlendEquationMode
{
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_minmax", Api = "gl|gles1|gles2")]
	[RequiredByFeature("GL_OES_blend_subtract", Api = "gles1")]
	FuncAdd = 32774,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_minmax", Api = "gl|gles1|gles2")]
	Min = 32775,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_minmax", Api = "gl|gles1|gles2")]
	Max = 32776,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_subtract")]
	[RequiredByFeature("GL_OES_blend_subtract", Api = "gles1")]
	FuncSubtract = 32778,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_EXT_blend_subtract")]
	[RequiredByFeature("GL_OES_blend_subtract", Api = "gles1")]
	FuncReverseSubtract = 32779,
	[RequiredByFeature("GL_SGIX_blend_alpha_minmax")]
	AlphaMinSgix = 33568,
	[RequiredByFeature("GL_SGIX_blend_alpha_minmax")]
	AlphaMaxSgix = 33569
}
