using Khronos;

namespace OpenGL;

public enum PathColor
{
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	PrimaryColorNv = 34092,
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_NV_register_combiners")]
	SecondaryColorNv = 34093,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PrimaryColor = 34167
}
