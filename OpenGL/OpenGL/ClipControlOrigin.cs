using Khronos;

namespace OpenGL;

public enum ClipControlOrigin
{
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_clip_control", Api = "gl|glcore")]
	LowerLeft = 36001,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_clip_control", Api = "gl|glcore")]
	UpperLeft
}
