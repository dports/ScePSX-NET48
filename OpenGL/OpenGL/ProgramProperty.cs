using Khronos;

namespace OpenGL;

public enum ProgramProperty
{
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_compute_shader", Api = "gl|glcore")]
	ComputeWorkGroupSize = 33383,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_get_program_binary", Api = "gl|glcore")]
	[RequiredByFeature("GL_OES_get_program_binary", Api = "gles2")]
	ProgramBinaryLength = 34625,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	GeometryVerticesOut = 35094,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	GeometryInputType = 35095,
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
	GeometryOutputType = 35096,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	ActiveUniformBlockMaxNameLength = 35381,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	ActiveUniformBlocks = 35382,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	DeleteStatus = 35712,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	LinkStatus = 35714,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	ValidateStatus = 35715,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	InfoLogLength = 35716,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	AttachedShaders = 35717,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	ActiveUniforms = 35718,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	ActiveUniformMaxLength = 35719,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	ActiveAttributes = 35721,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	ActiveAttributeMaxLength = 35722,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	TransformFeedbackVaryingMaxLength = 35958,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackBufferMode = 35967,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackVaryings = 35971,
	[RequiredByFeature("GL_VERSION_4_2")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_atomic_counters", Api = "gl|glcore")]
	ActiveAtomicCounterBuffers = 37593
}
