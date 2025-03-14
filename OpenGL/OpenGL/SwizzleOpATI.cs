using Khronos;

namespace OpenGL;

public enum SwizzleOpATI
{
	[RequiredByFeature("GL_ATI_fragment_shader")]
	SwizzleStrAti = 35190,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	SwizzleStqAti,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	SwizzleStrDrAti,
	[RequiredByFeature("GL_ATI_fragment_shader")]
	SwizzleStqDqAti
}
