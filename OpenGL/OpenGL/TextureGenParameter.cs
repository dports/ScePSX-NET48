using Khronos;

namespace OpenGL;

public enum TextureGenParameter
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_OES_texture_cube_map", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureGenMode = 9472,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ObjectPlane = 9473,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_NV_fog_distance")]
	[RemovedByFeature("GL_VERSION_3_2")]
	EyePlane = 9474,
	[RequiredByFeature("GL_SGIS_point_line_texgen")]
	EyePointSgis = 33268,
	[RequiredByFeature("GL_SGIS_point_line_texgen")]
	ObjectPointSgis = 33269,
	[RequiredByFeature("GL_SGIS_point_line_texgen")]
	EyeLineSgis = 33270,
	[RequiredByFeature("GL_SGIS_point_line_texgen")]
	ObjectLineSgis = 33271
}
