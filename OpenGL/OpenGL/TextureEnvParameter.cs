using Khronos;

namespace OpenGL;

public enum TextureEnvParameter
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureEnvMode = 8704,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureEnvColor = 8705,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Combine = 34160,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CombineRgb = 34161,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	CombineAlpha = 34162,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	RgbScale = 34163,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	AddSigned = 34164,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Interpolate = 34165,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Constant = 34166,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_NV_path_rendering", Api = "gl|glcore|gles2")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	PrimaryColor = 34167,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Previous = 34168,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Source0Rgb = 34176,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Source1Rgb = 34177,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Source2Rgb = 34178,
	[RequiredByFeature("GL_NV_texture_env_combine4")]
	Source3RgbNv = 34179,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Source0Alpha = 34184,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Source1Alpha = 34185,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Source2Alpha = 34186,
	[RequiredByFeature("GL_NV_texture_env_combine4")]
	Source3AlphaNv = 34187,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Operand0Rgb = 34192,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Operand1Rgb = 34193,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Operand2Rgb = 34194,
	[RequiredByFeature("GL_NV_texture_env_combine4")]
	Operand3RgbNv = 34195,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Operand0Alpha = 34200,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Operand1Alpha = 34201,
	[RequiredByFeature("GL_VERSION_1_3")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_ARB_texture_env_combine")]
	[RequiredByFeature("GL_EXT_texture_env_combine")]
	[RemovedByFeature("GL_VERSION_3_2")]
	Operand2Alpha = 34202,
	[RequiredByFeature("GL_NV_texture_env_combine4")]
	Operand3AlphaNv = 34203
}
