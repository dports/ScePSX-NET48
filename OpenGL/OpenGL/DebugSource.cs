using Khronos;

namespace OpenGL;

public enum DebugSource
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	DontCare = 4352,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_ARB_debug_output", Api = "gl|glcore")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugSourceApi = 33350,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_ARB_debug_output", Api = "gl|glcore")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugSourceWindowSystem = 33351,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_ARB_debug_output", Api = "gl|glcore")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugSourceShaderCompiler = 33352,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_ARB_debug_output", Api = "gl|glcore")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugSourceThirdParty = 33353,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_ARB_debug_output", Api = "gl|glcore")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugSourceApplication = 33354,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_ARB_debug_output", Api = "gl|glcore")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugSourceOther = 33355
}
