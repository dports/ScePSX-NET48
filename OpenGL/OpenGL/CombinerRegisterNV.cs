using Khronos;

namespace OpenGL;

public enum CombinerRegisterNV
{
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_multitexture")]
	[RequiredByFeature("GL_NV_register_combiners")]
	Texture0 = 33984,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
	[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
	[RequiredByFeature("GL_ARB_multitexture")]
	[RequiredByFeature("GL_NV_register_combiners")]
	Texture1 = 33985,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	PrimaryColorNv = 34092,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	SecondaryColorNv = 34093,
	[RequiredByFeature("GL_NV_register_combiners")]
	Spare0Nv = 34094,
	[RequiredByFeature("GL_NV_register_combiners")]
	Spare1Nv = 34095,
	[RequiredByFeature("GL_NV_register_combiners")]
	DiscardNv = 34096
}
