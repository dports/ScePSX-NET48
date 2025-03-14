using Khronos;

namespace OpenGL;

public enum ProgramInterface
{
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_VERSION_4_4")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_enhanced_layouts", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_transform_feedback")]
	[RequiredByFeature("GL_NV_transform_feedback")]
	TransformFeedbackBuffer = 35982,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	Uniform = 37601,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	UniformBlock = 37602,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ProgramInput = 37603,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ProgramOutput = 37604,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	BufferVariable = 37605,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ShaderStorageBlock = 37606,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	VertexSubroutine = 37608,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	TessControlSubroutine = 37609,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	TessEvaluationSubroutine = 37610,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	GeometrySubroutine = 37611,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	FragmentSubroutine = 37612,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ComputeSubroutine = 37613,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	VertexSubroutineUniform = 37614,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	TessControlSubroutineUniform = 37615,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	TessEvaluationSubroutineUniform = 37616,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	GeometrySubroutineUniform = 37617,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	FragmentSubroutineUniform = 37618,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ComputeSubroutineUniform = 37619,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	TransformFeedbackVarying = 37620
}
