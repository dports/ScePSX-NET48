using Khronos;

namespace OpenGL;

public enum ConvolutionBorderModeEXT
{
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	Reduce = 32790
}
