using Khronos;

namespace OpenGL;

public enum TransformFeedbackPName
{
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackBufferStart = 35972,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackBufferSize = 35973,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackBufferBinding = 35983,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_transform_feedback2")]
	TransformFeedbackBufferPaused = 36387,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
	[RequiredByFeature("GL_NV_transform_feedback2")]
	TransformFeedbackBufferActive = 36388
}
