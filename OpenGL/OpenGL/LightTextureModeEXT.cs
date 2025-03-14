using Khronos;

namespace OpenGL;

public enum LightTextureModeEXT
{
	[RequiredByFeature("GL_EXT_light_texture")]
	FragmentMaterialExt = 33609,
	[RequiredByFeature("GL_EXT_light_texture")]
	FragmentNormalExt = 33610,
	[RequiredByFeature("GL_EXT_light_texture")]
	FragmentColorExt = 33612,
	[RequiredByFeature("GL_VERSION_1_4")]
	[RequiredByFeature("GL_EXT_fog_coord")]
	[RequiredByFeature("GL_EXT_light_texture")]
	[RemovedByFeature("GL_VERSION_3_2")]
	FragmentDepth = 33874
}
