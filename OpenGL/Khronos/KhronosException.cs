using System;

namespace Khronos;

public abstract class KhronosException : InvalidOperationException
{
	public readonly int ErrorCode;

	protected KhronosException(int errorCode)
	{
		ErrorCode = errorCode;
	}

	protected KhronosException(int errorCode, string message)
		: base(message)
	{
		ErrorCode = errorCode;
	}

	protected KhronosException(int errorCode, string message, Exception innerException)
		: base(message, innerException)
	{
		ErrorCode = errorCode;
	}
}
