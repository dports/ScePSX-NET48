using Khronos;

namespace OpenGL;

public enum ProgramParameterPName
{
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_get_program_binary", Api = "gl|glcore")]
	ProgramBinaryRetrievableHint = 33367,
	[RequiredByFeature("GL_VERSION_4_1")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_separate_shader_objects", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_separate_shader_objects", Api = "gl|glcore|gles2")]
	ProgramSeparable
}
