using Khronos;

namespace OpenGL;

public enum ProgramStagePName
{
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	ActiveSubroutines = 36325,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	ActiveSubroutineUniforms = 36326,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	ActiveSubroutineUniformLocations = 36423,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	ActiveSubroutineMaxLength = 36424,
	[RequiredByFeature("GL_VERSION_4_0")]
	[RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
	ActiveSubroutineUniformMaxLength = 36425
}
