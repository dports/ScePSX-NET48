using Khronos;

namespace OpenGL;

public enum ShadingRateCombinerOp
{
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	FragmentShadingRateCombinerOpKeepExt = 38610,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	FragmentShadingRateCombinerOpReplaceExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	FragmentShadingRateCombinerOpMinExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	FragmentShadingRateCombinerOpMaxExt,
	[RequiredByFeature("GL_EXT_fragment_shading_rate", Api = "gles2")]
	FragmentShadingRateCombinerOpMulExt
}
