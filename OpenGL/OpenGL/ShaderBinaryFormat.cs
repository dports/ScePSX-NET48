using Khronos;

namespace OpenGL;

public enum ShaderBinaryFormat
{
	[RequiredByFeature("GL_IMG_shader_binary", Api = "gles2")]
	SgxBinaryImg = 35850,
	[RequiredByFeature("GL_ARM_mali_shader_binary", Api = "gles2")]
	MaliShaderBinaryArm = 36704,
	[RequiredByFeature("GL_VIV_shader_binary", Api = "gles2")]
	ShaderBinaryViv = 36804,
	[RequiredByFeature("GL_DMP_shader_binary", Api = "gles2")]
	ShaderBinaryDmp = 37456,
	[RequiredByFeature("GL_FJ_shader_binary_GCCSO", Api = "gles2")]
	GccsoShaderBinaryFj = 37472,
	[RequiredByFeature("GL_VERSION_4_6")]
	ShaderBinaryFormatSpirV = 38225
}
