using Khronos;

namespace OpenGL;

public enum MeshMode2
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_NV_polygon_mode", Api = "gles2")]
	Point = 6912,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_NV_polygon_mode", Api = "gles2")]
	Line,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_NV_polygon_mode", Api = "gles2")]
	Fill
}
