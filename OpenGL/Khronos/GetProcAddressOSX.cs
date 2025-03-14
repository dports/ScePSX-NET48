using System;
using System.Runtime.InteropServices;

namespace Khronos;

internal class GetProcAddressOSX : IGetProcAddressOS
{
	private static class UnsafeNativeMethods
	{
		[DllImport("libdl.dylib")]
		public static extern bool NSIsSymbolNameDefined(string s);

		[DllImport("libdl.dylib")]
		public static extern nint NSLookupAndBindSymbol(string s);

		[DllImport("libdl.dylib")]
		public static extern nint NSAddressOfSymbol(nint symbol);
	}

	public static readonly GetProcAddressOSX Instance = new GetProcAddressOSX();

	private const string Library = "libdl.dylib";

	public void AddLibraryDirectory(string libraryDirPath)
	{
	}

	public nint GetProcAddress(string library, string function)
	{
		return GetProcAddressCore(function);
	}

	public nint GetProcAddressCore(string function)
	{
		string s = "_" + function;
		if (!UnsafeNativeMethods.NSIsSymbolNameDefined(s))
		{
			return IntPtr.Zero;
		}
		nint num = UnsafeNativeMethods.NSLookupAndBindSymbol(s);
		if (num != IntPtr.Zero)
		{
			num = UnsafeNativeMethods.NSAddressOfSymbol(num);
		}
		return num;
	}

	public nint GetProcAddress(string function)
	{
		return GetProcAddressCore(function);
	}
}
