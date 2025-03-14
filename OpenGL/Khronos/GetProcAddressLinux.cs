using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Khronos;

internal class GetProcAddressLinux : IGetProcAddressOS
{
	private static class UnsafeNativeMethods
	{
		public const int RTLD_LAZY = 1;

		public const int RTLD_NOW = 2;

		[DllImport("dl")]
		public static extern nint dlopen(string filename, int flags);

		[DllImport("dl")]
		public static extern nint dlsym(nint handle, string symbol);

		[DllImport("dl")]
		public static extern string dlerror();
	}

	internal static readonly GetProcAddressLinux Instance = new GetProcAddressLinux();

	private static readonly Dictionary<string, nint> _LibraryHandles = new Dictionary<string, nint>();

	public void AddLibraryDirectory(string libraryDirPath)
	{
	}

	public nint GetProcAddress(string library, string function)
	{
		nint libraryHandle = GetLibraryHandle(library);
		return GetProcAddress(libraryHandle, function);
	}

	private nint GetProcAddress(nint library, string function)
	{
		if (library == IntPtr.Zero)
		{
			throw new ArgumentNullException("library");
		}
		if (function == null)
		{
			throw new ArgumentNullException("function");
		}
		return UnsafeNativeMethods.dlsym(library, function);
	}

	internal static nint GetLibraryHandle(string libraryPath)
	{
		return GetLibraryHandle(libraryPath, throws: true);
	}

	internal static nint GetLibraryHandle(string libraryPath, bool throws)
	{
		if (!_LibraryHandles.TryGetValue(libraryPath, out var value))
		{
			if ((value = UnsafeNativeMethods.dlopen(libraryPath, 1)) == IntPtr.Zero && throws)
			{
				throw new InvalidOperationException("unable to load library at " + libraryPath, new InvalidOperationException(UnsafeNativeMethods.dlerror()));
			}
			_LibraryHandles.Add(libraryPath, value);
		}
		return value;
	}
}
