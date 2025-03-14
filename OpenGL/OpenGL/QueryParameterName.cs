using Khronos;

namespace OpenGL;

public enum QueryParameterName
{
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ARB_occlusion_query")]
	[RequiredByFeature("GL_EXT_disjoint_timer_query", Api = "gles2")]
	QueryCounterBits = 34916,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_occlusion_query")]
	[RequiredByFeature("GL_EXT_disjoint_timer_query", Api = "gles2")]
	[RequiredByFeature("GL_EXT_occlusion_query_boolean", Api = "gles2")]
	CurrentQuery
}
