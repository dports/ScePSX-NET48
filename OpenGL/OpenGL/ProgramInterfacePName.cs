using Khronos;

namespace OpenGL;

public enum ProgramInterfacePName
{
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	ActiveResources = 37621,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	MaxNameLength,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	MaxNumActiveVariables,
	[RequiredByFeature("GL_VERSION_4_3")]
	[RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")]
	MaxNumCompatibleSubroutines
}
