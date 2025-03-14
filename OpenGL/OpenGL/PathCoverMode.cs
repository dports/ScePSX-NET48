using Khronos;

namespace OpenGL;

public enum PathCoverMode
{
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	PathFillCoverModeNv = 36994,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	ConvexHullNv = 37003,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	BoundingBoxNv = 37005,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	BoundingBoxOfBoundingBoxesNv = 37020
}
