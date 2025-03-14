using Khronos;

namespace OpenGL;

public enum VertexArrayPNameAPPLE
{
	[RequiredByFeature("GL_APPLE_vertex_array_range")]
	StorageClientApple = 34228,
	[RequiredByFeature("GL_APPLE_texture_range")]
	[RequiredByFeature("GL_APPLE_vertex_array_range")]
	StorageCachedApple = 34238,
	[RequiredByFeature("GL_APPLE_texture_range")]
	[RequiredByFeature("GL_APPLE_vertex_array_range")]
	StorageSharedApple = 34239
}
