using Khronos;

namespace OpenGL;

public enum ImageTransformPNameHP
{
	[RequiredByFeature("GL_HP_image_transform")]
	ImageScaleXHp = 33109,
	[RequiredByFeature("GL_HP_image_transform")]
	ImageScaleYHp,
	[RequiredByFeature("GL_HP_image_transform")]
	ImageTranslateXHp,
	[RequiredByFeature("GL_HP_image_transform")]
	ImageTranslateYHp,
	[RequiredByFeature("GL_HP_image_transform")]
	ImageRotateAngleHp,
	[RequiredByFeature("GL_HP_image_transform")]
	ImageRotateOriginXHp,
	[RequiredByFeature("GL_HP_image_transform")]
	ImageRotateOriginYHp,
	[RequiredByFeature("GL_HP_image_transform")]
	ImageMagFilterHp,
	[RequiredByFeature("GL_HP_image_transform")]
	ImageMinFilterHp,
	[RequiredByFeature("GL_HP_image_transform")]
	ImageCubicWeightHp
}
