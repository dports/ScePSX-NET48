using Khronos;

namespace OpenGL;

public enum ClampColorTargetARB
{
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_color_buffer_float")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClampVertexColor = 35098,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_color_buffer_float")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClampFragmentColor,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_ARB_color_buffer_float")]
	ClampReadColor
}
