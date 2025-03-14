using Khronos;

namespace OpenGL;

public enum ProgramTarget
{
	[RequiredByFeature("GL_ATI_text_fragment_shader")]
	TextFragmentShaderAti = 33280,
	[RequiredByFeature("GL_ARB_vertex_program")]
	[RequiredByFeature("GL_NV_vertex_program")]
	VertexProgramArb = 34336,
	[RequiredByFeature("GL_ARB_fragment_program")]
	FragmentProgramArb = 34820,
	[RequiredByFeature("GL_NV_tessellation_program5")]
	TessControlProgramNv = 35102,
	[RequiredByFeature("GL_NV_tessellation_program5")]
	TessEvaluationProgramNv = 35103,
	[RequiredByFeature("GL_NV_geometry_program4")]
	GeometryProgramNv = 35878,
	[RequiredByFeature("GL_NV_compute_program5")]
	ComputeProgramNv = 37115
}
