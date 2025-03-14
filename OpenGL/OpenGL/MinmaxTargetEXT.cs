using Khronos;

namespace OpenGL;

public enum MinmaxTargetEXT
{
	[RequiredByFeature("GL_VERSION_4_5")]
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_histogram")]
	Minmax = 32814
}
