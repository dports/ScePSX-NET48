using System.ComponentModel;
using Khronos;

namespace OpenGL;

public sealed class WglException : KhronosException
{
	internal WglException(int errorCode)
		: base(errorCode, GetErrorMessage(errorCode), new Win32Exception(errorCode))
	{
	}

	private static string GetErrorMessage(int errorCode)
	{
		return errorCode switch
		{
			0 => "no error", 
			8341 => "invalid version", 
			8342 => "invalid profile", 
			8259 => "invalid pixel type", 
			8276 => "incompatible device contexts", 
			8400 => "incompatible affinity mask", 
			8401 => "missing affinity mask", 
			_ => $"unknown error code 0x{errorCode:X8}", 
		};
	}
}
