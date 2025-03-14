using Khronos;

namespace OpenGL;

public enum FragmentOp2ATI
{
	[RequiredByFeature("GL_ATI_fragment_shader")]
	AddAti = 35171,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	MulAti,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	SubAti,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Dot3Ati,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	Dot4Ati
}
