using Khronos;

namespace OpenGL;

public enum ProgramStringProperty
{
	[RequiredByFeature("GL_ARB_fragment_program")]
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_NV_vertex_program")]
	ProgramStringArb = 34344
}
