using Khronos;

namespace OpenGL;

public enum SpecialNumbers
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	False = 0,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_robustness", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_robustness", Api = "gles1|gles2")]
	[RequiredByFeature("GL_KHR_robustness", Api = "gl|glcore|gles2")]
	NoError = 0,
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
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_VERSION_4_6")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_KHR_context_flush_control", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	[RequiredByFeature("GL_OES_framebuffer_object", Api = "gles1")]
	None = 0,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	True = 1,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
	[RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
	One = 1,
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	VersionEsCl10 = 1,
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	VersionEsCm11 = 1,
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	VersionEsCl11 = 1,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	InvalidIndex = -1,
	[RequiredByFeature("GL_AMD_framebuffer_sample_positions")]
	AllPixelsAmd = -1,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_sync", Api = "gl|glcore")]
	[RequiredByFeature("GL_APPLE_sync", Api = "gles1|gles2")]
	TimeoutIgnored = -1,
	[RequiredByFeature("GL_EXT_memory_object", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore", Api = "gl|gles2")]
	UuidSizeExt = 16,
	[RequiredByFeature("GL_EXT_memory_object_win32", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore_win32", Api = "gl|gles2")]
	LuidSizeExt = 8
}
