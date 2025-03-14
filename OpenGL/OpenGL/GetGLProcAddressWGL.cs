using System.Runtime.InteropServices;

namespace OpenGL;

internal class GetGLProcAddressWGL : IGetGLProcAddress
{
	private static class UnsafeNativeMethods
	{
		[DllImport("opengl32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern nint wglGetProcAddress(string lpszProc);
	}

	public static readonly GetGLProcAddressWGL Instance = new GetGLProcAddressWGL();

	private const string Library = "opengl32.dll";

	public nint GetProcAddress(string function)
	{
		return UnsafeNativeMethods.wglGetProcAddress(function);
	}
}
