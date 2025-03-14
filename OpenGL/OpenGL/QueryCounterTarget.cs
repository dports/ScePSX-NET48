using Khronos;

namespace OpenGL;

public enum QueryCounterTarget
{
	[RequiredByFeature("GL_VERSION_3_3")]
	[RequiredByFeature("GL_ARB_timer_query", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_disjoint_timer_query", Api = "gles2")]
	Timestamp = 36392
}
