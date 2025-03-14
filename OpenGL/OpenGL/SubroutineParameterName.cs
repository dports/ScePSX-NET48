using Khronos;

namespace OpenGL;

public enum SubroutineParameterName
{
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformSize = 35384,
	[RequiredByFeature("GL_VERSION_3_1")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
	UniformNameLength = 35385,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	NumCompatibleSubroutines = 36426,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	CompatibleSubroutines = 36427
}
