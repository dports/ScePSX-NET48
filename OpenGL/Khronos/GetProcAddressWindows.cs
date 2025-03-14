using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Khronos;

internal class GetProcAddressWindows : IGetProcAddressOS
{
	private static class UnsafeNativeMethods
	{
		[DllImport("Kernel32.dll", SetLastError = true)]
		public static extern nint LoadLibrary(string lpFileName);

		[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true, SetLastError = true)]
		public static extern nint Win32GetProcAddress(nint hModule, string lpProcName);
	}

	public static readonly GetProcAddressWindows Instance = new GetProcAddressWindows();

	private static readonly Dictionary<string, nint> _LibraryHandles = new Dictionary<string, nint>();

	public void AddLibraryDirectory(string libraryDirPath)
	{
		string environmentVariable = Environment.GetEnvironmentVariable("PATH");
		Environment.SetEnvironmentVariable("PATH", environmentVariable + ";" + libraryDirPath, EnvironmentVariableTarget.Process);
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
		return UnsafeNativeMethods.Win32GetProcAddress(library, function);
	}

	public nint GetLibraryHandle(string libraryPath)
	{
		if (!_LibraryHandles.TryGetValue(libraryPath, out var value))
		{
			value = UnsafeNativeMethods.LoadLibrary(libraryPath);
			_LibraryHandles.Add(libraryPath, value);
		}
		if (value == IntPtr.Zero)
		{
			throw new InvalidOperationException("unable to load library at " + libraryPath, new Win32Exception(Marshal.GetLastWin32Error()));
		}
		return value;
	}
}
