using Khronos;

namespace OpenGL;

public enum TextureGenMode
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	EyeLinear = 9216,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ObjectLinear = 9217,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	SphereMap = 9218,
	[RequiredByFeature("GL_SGIS_point_line_texgen")]
	EyeDistanceToPointSgis = 33264,
	[RequiredByFeature("GL_SGIS_point_line_texgen")]
	ObjectDistanceToPointSgis = 33265,
	[RequiredByFeature("GL_SGIS_point_line_texgen")]
	EyeDistanceToLineSgis = 33266,
	[RequiredByFeature("GL_SGIS_point_line_texgen")]
	ObjectDistanceToLineSgis = 33267
}
