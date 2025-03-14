using Khronos;

namespace OpenGL;

public enum ClipControlDepth
{
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_clip_control", Api = "gl|glcore")]
	NegativeOneToOne = 37726,
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_clip_control", Api = "gl|glcore")]
	ZeroToOne
}
