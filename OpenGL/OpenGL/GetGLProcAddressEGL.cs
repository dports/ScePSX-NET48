using System.Runtime.InteropServices;

namespace OpenGL;

internal class GetGLProcAddressEGL : IGetGLProcAddress
{
	public static readonly GetGLProcAddressEGL Instance = new GetGLProcAddressEGL();

	public nint GetProcAddress(string function)
	{
		return GetProcAddressCore(function);
	}

	[DllImport("libEGL.dll", EntryPoint = "eglGetProcAddress")]
	public static extern nint GetProcAddressCore(string funcname);
}
