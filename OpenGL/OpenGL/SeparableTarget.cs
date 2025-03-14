using Khronos;

namespace OpenGL;

public enum SeparableTarget
{
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_convolution")]
	Separable2d = 32786
}
