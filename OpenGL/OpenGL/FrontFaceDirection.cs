using Khronos;

namespace OpenGL;

public enum FrontFaceDirection
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	Cw = 2304,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	Ccw
}
