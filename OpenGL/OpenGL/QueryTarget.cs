using Khronos;

namespace OpenGL;

public enum QueryTarget
{
	[RequiredByFeature("GL_VERSION_4_6")]
	TransformFeedbackOverflow = 33516,
	[RequiredByFeature("GL_VERSION_4_6")]
	VerticesSubmitted = 33518,
	[RequiredByFeature("GL_VERSION_4_6")]
	PrimitivesSubmitted = 33519,
	[RequiredByFeature("GL_VERSION_4_6")]
	VertexShaderInvocations = 33520,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ARB_timer_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_disjoint_timer_query", Api = "gles2")]
	[RequiredByFeature("GL_EXT_timer_query")]
	TimeElapsed = 35007,
	[RequiredByFeature("GL_VERSION_1_5")]
	[RequiredByFeature("GL_ARB_occlusion_query")]
	SamplesPassed = 35092,
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_occlusion_query2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_occlusion_query_boolean", Api = "gles2")]
	AnySamplesPassed = 35887,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	[RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
	PrimitivesGenerated = 35975,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackPrimitivesWritten = 35976,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_ES3_compatibility", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_occlusion_query_boolean", Api = "gles2")]
	AnySamplesPassedConservative = 36202
}
