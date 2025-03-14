using System;

namespace Khronos;

internal static class GetProcAddressOS
{
	private static readonly IGetProcAddressOS _GetProcAddressOS;

	static GetProcAddressOS()
	{
		if (Environment.GetEnvironmentVariable("OPENGL_NET_OSLOADER") == "EGL")
		{
			_GetProcAddressOS = GetProcAddressEGL.Instance;
		}
		else
		{
			_GetProcAddressOS = CreateOS();
		}
	}

	private static IGetProcAddressOS CreateOS()
	{
		return Platform.CurrentPlatformId switch
		{
			Platform.Id.WindowsNT => new GetProcAddressWindows(), 
			Platform.Id.Linux => new GetProcAddressLinux(), 
			Platform.Id.MacOS => new GetProcAddressOSX(), 
			Platform.Id.Android => new GetProcAddressEGL(), 
			_ => throw new NotSupportedException($"platform {Platform.CurrentPlatformId} not supported"), 
		};
	}

	public static void AddLibraryDirectory(string libraryDirPath)
	{
		_GetProcAddressOS.AddLibraryDirectory(libraryDirPath);
	}

	public static nint GetProcAddress(string library, string function)
	{
		return _GetProcAddressOS.GetProcAddress(library, function);
	}
}
