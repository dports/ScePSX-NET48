using Khronos;

namespace OpenGL;

public enum TextureSwizzle
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	Zero = 0,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	One = 1,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	[RequiredByFeature("GL_EXT_texture_rg", Api = "gles2")]
	[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
	Red = 6403,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
	Green = 6404,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
	Blue = 6405,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_AMD_interleaved_elements")]
	Alpha = 6406
}
