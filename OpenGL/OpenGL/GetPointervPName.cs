using Khronos;

namespace OpenGL;

public enum GetPointervPName
{
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FeedbackBufferPointer = 3568,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	SelectionBufferPointer = 3571,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	VertexArrayPointer = 32910,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	NormalArrayPointer = 32911,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ColorArrayPointer = 32912,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	IndexArrayPointer = 32913,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureCoordArrayPointer = 32914,
	[RequiredByFeature("GL_VERSION_1_1")]
	[RequiredByFeature("GL_EXT_vertex_array")]
	[RemovedByFeature("GL_VERSION_3_2")]
	EdgeFlagArrayPointer = 32915,
	[RequiredByFeature("GL_SGIX_instruments")]
	InstrumentBufferPointerSgix = 33152,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_ARB_debug_output", Api = "gl|glcore")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugCallbackFunction = 33348,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	[RequiredByFeature("GL_ARB_debug_output", Api = "gl|glcore")]
	[RequiredByFeature("GL_KHR_debug", Api = "gl|glcore|gles1|gles2")]
	DebugCallbackUserParam = 33349
}
