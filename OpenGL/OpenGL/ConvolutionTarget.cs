using Khronos;

namespace OpenGL;

public enum ConvolutionTarget
{
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	Convolution1d = 32784,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	Convolution2d
}
