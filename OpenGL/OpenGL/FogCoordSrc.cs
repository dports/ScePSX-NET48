using Khronos;

namespace OpenGL;

public enum FogCoordSrc
{
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_EXT_fog_coord")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FogCoordinate = 33873,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_EXT_fog_coord")]
	[RequiredByFeature("GL_EXT_light_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FragmentDepth
}
