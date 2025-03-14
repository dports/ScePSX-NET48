using Khronos;

namespace OpenGL;

public enum FragmentLightModelParameterSGIX
{
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightModelLocalViewerSgix = 33800,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightModelTwoSideSgix,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightModelAmbientSgix,
	[RequiredByFeature("GL_SGIX_fragment_lighting")]
	FragmentLightModelNormalInterpolationSgix
}
