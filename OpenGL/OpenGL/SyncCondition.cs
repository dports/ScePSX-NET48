using Khronos;

namespace OpenGL;

public enum SyncCondition
{
	[RequiredByFeature("GL_VERSION_3_2")]
	[RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
	[RequiredByFeature("GL_ARB_sync", Api = "gl|glcore")]
	[RequiredByFeature("GL_APPLE_sync", Api = "gles1|gles2")]
	SyncGpuCommandsComplete = 37143
}
