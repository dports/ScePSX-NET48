using Khronos;

namespace OpenGL;

public enum FragmentOp3ATI
{
	[RequiredByFeature("GL_ATI_fragment_shader")]
	MadAti = 35176,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	LerpAti,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	CndAti,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Cnd0Ati,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Dot2AddAti
}
