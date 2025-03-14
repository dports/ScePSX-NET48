using Khronos;

namespace OpenGL;

public enum TextureEnvTarget
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	TextureEnv = 8960
}
