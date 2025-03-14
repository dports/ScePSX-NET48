using Khronos;

namespace OpenGL;

public enum ShaderParameterName
{
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	ShaderType = 35663,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	DeleteStatus = 35712,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	CompileStatus = 35713,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	InfoLogLength = 35716,
	[RequiredByFeature("GL_VERSION_2_0")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	ShaderSourceLength = 35720
}
