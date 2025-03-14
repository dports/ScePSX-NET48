using Khronos;

namespace OpenGL;

public enum TransformFeedbackTokenNV
{
	[RequiredByFeature("GL_NV_transform_feedback")]
	NextBufferNv = -2,
	[RequiredByFeature("GL_NV_transform_feedback")]
	SkipComponents4Nv = -3,
	[RequiredByFeature("GL_NV_transform_feedback")]
	SkipComponents3Nv = -4,
	[RequiredByFeature("GL_NV_transform_feedback")]
	SkipComponents2Nv = -5,
	[RequiredByFeature("GL_NV_transform_feedback")]
	SkipComponents1Nv = -6
}
