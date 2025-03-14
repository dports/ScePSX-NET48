using Khronos;

namespace OpenGL;

public enum CombinerVariableNV
{
	[RequiredByFeature("GL_NV_register_combiners")]
	VariableANv = 34083,
	[RequiredByFeature("GL_NV_register_combiners")]
	VariableBNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	VariableCNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	VariableDNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	VariableENv,
	[RequiredByFeature("GL_NV_register_combiners")]
	VariableFNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	VariableGNv
}
