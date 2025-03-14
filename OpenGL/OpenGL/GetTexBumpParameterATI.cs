using Khronos;

namespace OpenGL;

public enum GetTexBumpParameterATI
{
	[RequiredByFeature("GL_ATI_envmap_bumpmap")]
	BumpRotMatrixAti = 34677,
	[RequiredByFeature("GL_ATI_envmap_bumpmap")]
	BumpRotMatrixSizeAti,
	[RequiredByFeature("GL_ATI_envmap_bumpmap")]
	BumpNumTexUnitsAti,
	[RequiredByFeature("GL_ATI_envmap_bumpmap")]
	BumpTexUnitsAti
}
