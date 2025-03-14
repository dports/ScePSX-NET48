using Khronos;

namespace OpenGL;

public enum PixelStoreResampleMode
{
	[RequiredByFeature("GL_SGIX_resample")]
	ResampleDecimateSgix = 33840,
	[RequiredByFeature("GL_SGIX_resample")]
	ResampleReplicateSgix = 33843,
	[RequiredByFeature("GL_SGIX_resample")]
	ResampleZeroFillSgix = 33844
}
