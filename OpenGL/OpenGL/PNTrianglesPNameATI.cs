using Khronos;

namespace OpenGL;

public enum PNTrianglesPNameATI
{
	[RequiredByFeature("GL_ATI_pn_triangles")]
	PnTrianglesPointModeAti = 34802,
	[RequiredByFeature("GL_ATI_pn_triangles")]
	PnTrianglesNormalModeAti,
	[RequiredByFeature("GL_ATI_pn_triangles")]
	PnTrianglesTesselationLevelAti
}
