using System.Runtime.InteropServices;

namespace Khronos;

internal class GetProcAddressEGL : IGetProcAddressOS
{
	public static readonly GetProcAddressEGL Instance = new GetProcAddressEGL();

	public void AddLibraryDirectory(string libraryDirPath)
	{
	}

	public nint GetProcAddress(string library, string function)
	{
		return GetProcAddressCore(function);
	}

	[DllImport("libEGL.dll", EntryPoint = "eglGetProcAddress")]
	public static extern nint GetProcAddressCore(string funcname);
}
