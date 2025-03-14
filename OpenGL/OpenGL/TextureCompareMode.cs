using Khronos;

namespace OpenGL;

public enum TextureCompareMode
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
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_ARB_shadow")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CompareRToTexture = 34894
}
