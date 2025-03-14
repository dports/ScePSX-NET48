using Khronos;

namespace OpenGL;

public sealed class GlException : KhronosException
{
	public GlException(ErrorCode errorCode)
		: base((int)errorCode, GetErrorMessage(errorCode))
	{
	}

	private static string GetErrorMessage(ErrorCode errorCode)
	{
		return errorCode switch
		{
			OpenGL.ErrorCode.NoError => "no error", 
			OpenGL.ErrorCode.InvalidEnum => "invalid enumeration", 
			OpenGL.ErrorCode.InvalidFramebufferOperation => "invalid framebuffer operation", 
			OpenGL.ErrorCode.InvalidOperation => "invalid operation", 
			OpenGL.ErrorCode.InvalidValue => "invalid value", 
			OpenGL.ErrorCode.OutOfMemory => "out of memory", 
			OpenGL.ErrorCode.StackOverflow => "stack overflow", 
			OpenGL.ErrorCode.StackUnderflow => "stack underflow", 
			OpenGL.ErrorCode.TableTooLarge => "table too large", 
			OpenGL.ErrorCode.TextureTooLargeExt => "texture too large", 
			_ => $"unknown error code {errorCode}", 
		};
	}
}
