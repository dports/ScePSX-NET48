using Khronos;

namespace OpenGL;

public enum GetMinmaxParameterPNameEXT
{
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_histogram")]
	MinmaxFormat = 32815,
	[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
	[RequiredByFeature("GL_EXT_histogram")]
	MinmaxSink
}
