using Khronos;

namespace OpenGL;

public enum SemaphoreParameterName
{
	[RequiredByFeature("GL_EXT_semaphore_win32", Api = "gl|gles2")]
	D3d12FenceValueExt = 38293,
	[RequiredByFeature("GL_NV_timeline_semaphore", Api = "gl|gles2")]
	TimelineSemaphoreValueNv = 38293,
	[RequiredByFeature("GL_NV_timeline_semaphore", Api = "gl|gles2")]
	SemaphoreTypeNv = 38323,
	[RequiredByFeature("GL_NV_timeline_semaphore", Api = "gl|gles2")]
	SemaphoreTypeBinaryNv = 38324,
	[RequiredByFeature("GL_NV_timeline_semaphore", Api = "gl|gles2")]
	SemaphoreTypeTimelineNv = 38325
}
