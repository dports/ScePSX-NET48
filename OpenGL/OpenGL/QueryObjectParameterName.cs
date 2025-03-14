using Khronos;

namespace OpenGL;

public enum QueryObjectParameterName
{
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
	QueryTarget = 33514,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_occlusion_query")]
	[RequiredByFeature("GL_EXT_disjoint_timer_query", Api = "gles2")]
	[RequiredByFeature("GL_EXT_occlusion_query_boolean", Api = "gles2")]
	QueryResult = 34918,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_occlusion_query")]
	[RequiredByFeature("GL_EXT_disjoint_timer_query", Api = "gles2")]
	[RequiredByFeature("GL_EXT_occlusion_query_boolean", Api = "gles2")]
	QueryResultAvailable = 34919,
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ARB_query_buffer_object", Api = "gl|glcore")]
	[RequiredByFeature("GL_AMD_query_buffer_object")]
	QueryResultNoWait = 37268
}
