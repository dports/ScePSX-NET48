using Khronos;

namespace OpenGL;

public enum GraphicsResetStatus
{
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
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_KHR_robustness", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_ARB_robustness", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_robustness", Api = "gles1|gles2")]
	[RequiredByFeature("GL_KHR_robustness", Api = "gl|glcore|gles2")]
	GuiltyContextReset = 33363,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_KHR_robustness", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_ARB_robustness", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_robustness", Api = "gles1|gles2")]
	[RequiredByFeature("GL_KHR_robustness", Api = "gl|glcore|gles2")]
	InnocentContextReset = 33364,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_KHR_robustness", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_ARB_robustness", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_robustness", Api = "gles1|gles2")]
	[RequiredByFeature("GL_KHR_robustness", Api = "gl|glcore|gles2")]
	UnknownContextReset = 33365
}
