using System;
using Khronos;

namespace OpenGL;

internal static class GetProcAddressGL
{
	public static nint GetProcAddress(string function)
	{
		if (!Egl.IsRequired)
		{
			switch (Platform.CurrentPlatformId)
			{
			case Platform.Id.WindowsNT:
				return GetGLProcAddressWGL.Instance.GetProcAddress(function);
			case Platform.Id.Linux:
				return GetGLProcAddressGLX.Instance.GetProcAddress(function);
			case Platform.Id.MacOS:
				if (Glx.IsRequired)
				{
					return GetGLProcAddressGLX.Instance.GetProcAddress(function);
				}
				return GetProcAddressOSX.Instance.GetProcAddress(function);
			default:
				throw new NotSupportedException();
			}
		}
		return GetGLProcAddressEGL.Instance.GetProcAddress(function);
	}
}
