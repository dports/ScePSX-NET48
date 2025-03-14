using Khronos;

namespace OpenGL;

public enum BindTransformFeedbackTarget
{
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_debug_label", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_transform_feedback2")]
	TransformFeedback = 36386
}
