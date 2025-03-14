using Khronos;

namespace OpenGL;

public enum ClipPlaneName
{
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane0 = 12288,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane1,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane2,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane3,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane4,
	[RequiredByFeature("GL_VERSION_1_0")]
	[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
	[RequiredByFeature("GL_IMG_user_clip_plane", Api = "gles1")]
	[RemovedByFeature("GL_VERSION_3_2")]
	ClipPlane5,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_APPLE_clip_distance", Api = "gles2")]
	ClipDistance6,
	[RequiredByFeature("GL_VERSION_3_0")]
	[RequiredByFeature("GL_APPLE_clip_distance", Api = "gles2")]
	ClipDistance7
}
