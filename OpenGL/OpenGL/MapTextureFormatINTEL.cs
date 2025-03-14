using Khronos;

namespace OpenGL;

public enum MapTextureFormatINTEL
{
	[RequiredByFeature("GL_INTEL_map_texture")]
	LayoutDefaultIntel,
	[RequiredByFeature("GL_INTEL_map_texture")]
	LayoutLinearIntel,
	[RequiredByFeature("GL_INTEL_map_texture")]
	LayoutLinearCpuCachedIntel
}
