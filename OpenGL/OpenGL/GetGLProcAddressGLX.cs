using System;
using System.Runtime.InteropServices;
using Khronos;

namespace OpenGL;

internal class GetGLProcAddressGLX : IGetGLProcAddress
{
	private static class Delegates
	{
		[RequiredByFeature("GLX_VERSION_1_4")]
		public delegate nint glXGetProcAddress(string procName);

		public static glXGetProcAddress pglXGetProcAddress;
	}

	internal static readonly GetGLProcAddressGLX Instance;

	private const string Library = "libGL.so.1";

	static GetGLProcAddressGLX()
	{
		Instance = new GetGLProcAddressGLX();
		nint procAddress = GetProcAddressOS.GetProcAddress("libGL.so.1", "glXGetProcAddress");
		if (procAddress != IntPtr.Zero)
		{
			Delegates.pglXGetProcAddress = (Delegates.glXGetProcAddress)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Delegates.glXGetProcAddress));
		}
	}

	public nint GetProcAddress(string function)
	{
		if (Delegates.pglXGetProcAddress == null)
		{
			return IntPtr.Zero;
		}
		return Delegates.pglXGetProcAddress(function);
	}
}
