using Khronos;

namespace OpenGL;

public enum CombinerMappingNV
{
	[RequiredByFeature("GL_NV_register_combiners")]
	UnsignedIdentityNv = 34102,
	[RequiredByFeature("GL_NV_register_combiners")]
	UnsignedInvertNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	ExpandNormalNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	ExpandNegateNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	HalfBiasNormalNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	HalfBiasNegateNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	SignedIdentityNv,
	[RequiredByFeature("GL_NV_register_combiners")]
	SignedNegateNv
}
