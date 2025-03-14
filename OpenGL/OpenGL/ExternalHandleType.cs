using Khronos;

namespace OpenGL;

public enum ExternalHandleType
{
	[RequiredByFeature("GL_EXT_memory_object_fd", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore_fd", Api = "gl|gles2")]
	HandleTypeOpaqueFdExt = 38278,
	[RequiredByFeature("GL_EXT_memory_object_win32", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore_win32", Api = "gl|gles2")]
	HandleTypeOpaqueWin32Ext = 38279,
	[RequiredByFeature("GL_EXT_memory_object_win32", Api = "gl|gles2")]
	[RequiredByFeature("GL_EXT_semaphore_win32", Api = "gl|gles2")]
	HandleTypeOpaqueWin32KmtExt = 38280,
	[RequiredByFeature("GL_EXT_memory_object_win32", Api = "gl|gles2")]
	HandleTypeD3d12TilepoolExt = 38281,
	[RequiredByFeature("GL_EXT_memory_object_win32", Api = "gl|gles2")]
	HandleTypeD3d12ResourceExt = 38282,
	[RequiredByFeature("GL_EXT_memory_object_win32", Api = "gl|gles2")]
	HandleTypeD3d11ImageExt = 38283,
	[RequiredByFeature("GL_EXT_memory_object_win32", Api = "gl|gles2")]
	HandleTypeD3d11ImageKmtExt = 38284,
	[RequiredByFeature("GL_EXT_semaphore_win32", Api = "gl|gles2")]
	HandleTypeD3d12FenceExt = 38292
}
