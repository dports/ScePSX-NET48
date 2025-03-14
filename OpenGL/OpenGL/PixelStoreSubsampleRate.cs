using Khronos;

namespace OpenGL;

public enum PixelStoreSubsampleRate
{
	[RequiredByFeature("GL_SGIX_subsample")]
	PixelSubsample4444Sgix = 34210,
	[RequiredByFeature("GL_SGIX_subsample")]
	PixelSubsample2424Sgix,
	[RequiredByFeature("GL_SGIX_subsample")]
	PixelSubsample4242Sgix
}
