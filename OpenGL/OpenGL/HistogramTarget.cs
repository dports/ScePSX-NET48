using Khronos;

namespace OpenGL;

public enum HistogramTarget
{
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_histogram")]
	Histogram = 32804,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_histogram")]
	ProxyHistogram
}
