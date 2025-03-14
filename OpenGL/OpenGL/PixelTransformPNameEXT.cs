using Khronos;

namespace OpenGL;

public enum PixelTransformPNameEXT
{
	[RequiredByFeature("GL_EXT_pixel_transform")]
	PixelMagFilterExt = 33585,
	[RequiredByFeature("GL_EXT_pixel_transform")]
	PixelMinFilterExt,
	[RequiredByFeature("GL_EXT_pixel_transform")]
	PixelCubicWeightExt
}
