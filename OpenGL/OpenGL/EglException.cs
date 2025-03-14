using Khronos;

namespace OpenGL;

public sealed class EglException : KhronosException
{
	internal EglException(int errorCode)
		: base(errorCode, GetErrorMessage(errorCode))
	{
	}

	private static string GetErrorMessage(int errorCode)
	{
		return errorCode switch
		{
			12288 => "no error", 
			12289 => "EGL is not initialized, or could not be initialized, for the specified EGL display connection", 
			12290 => "EGL cannot access a requested resource", 
			12291 => "EGL failed to allocate resources for the requested operation", 
			12292 => "an unrecognized attribute or attribute value was passed in the attribute list", 
			12294 => "an EGLContext argument does not name a valid EGL rendering context", 
			12293 => "an EGLConfig argument does not name a valid EGL frame buffer configuration", 
			12295 => "the current surface of the calling thread is a window, pixel buffer or pixmap that is no longer valid", 
			12296 => "an EGLDisplay argument does not name a valid EGL display connection", 
			12301 => "an EGLSurface argument does not name a valid surface configured for GL rendering", 
			12297 => "arguments are inconsistent", 
			12300 => "one or more argument values are invalid", 
			12298 => "a NativePixmapType argument does not refer to a valid native pixmap", 
			12299 => "a NativeWindowType argument does not refer to a valid native window", 
			12302 => "a power management event has occurred", 
			_ => $"unknown error code 0x{errorCode:X8}", 
		};
	}
}
