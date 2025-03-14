using Khronos;

namespace OpenGL;

public enum ConvolutionParameter
{
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	ConvolutionBorderMode = 32787,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	ConvolutionFilterScale = 32788,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	ConvolutionFilterBias = 32789,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	ConvolutionFormat = 32791,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	ConvolutionWidth = 32792,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	ConvolutionHeight = 32793,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	MaxConvolutionWidth = 32794,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	MaxConvolutionHeight = 32795,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_HP_convolution_border_modes")]
	ConvolutionBorderColor = 33108
}
