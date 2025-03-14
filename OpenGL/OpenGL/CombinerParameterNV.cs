using Khronos;

namespace OpenGL;

public enum CombinerParameterNV
{
	[RequiredByFeature("GL_NV_register_combiners")]
	CombinerInputNv = 34114,
	[RequiredByFeature("GL_NV_register_combiners")]
	CombinerMappingNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	CombinerComponentUsageNv
}
