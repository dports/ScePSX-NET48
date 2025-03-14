using Khronos;

namespace OpenGL;

public enum PatchParameterName
{
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
	[RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
	PatchVertices = 36466,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	PatchDefaultInnerLevel,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
	PatchDefaultOuterLevel
}
