using Khronos;

namespace OpenGL;

public enum LightModelColorControl
{
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_separate_specular_color")]
	[RemovedByFeature("GL_VERSION_3_2")]
	SingleColor = 33273,
	[RequiredByFeature("GL_VERSION_1_2")]
	[RequiredByFeature("GL_EXT_separate_specular_color")]
	[RemovedByFeature("GL_VERSION_3_2")]
	SeparateSpecularColor
}
