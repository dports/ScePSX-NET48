using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Vulkan;

public abstract class NativeLibrary : IDisposable
{
	private class WindowsNativeLibrary : NativeLibrary
	{
		public WindowsNativeLibrary(string libraryName)
			: base(libraryName)
		{
		}

		protected override IntPtr LoadLibrary(string libraryName)
		{
			return Kernel32.LoadLibrary(libraryName);
		}

		protected override void FreeLibrary(IntPtr libraryHandle)
		{
			Kernel32.FreeLibrary(libraryHandle);
		}

		protected override IntPtr LoadFunction(string functionName)
		{
			return Kernel32.GetProcAddress(base.NativeHandle, functionName);
		}
	}

	private class UnixNativeLibrary : NativeLibrary
	{
		public UnixNativeLibrary(string libraryName)
			: base(libraryName)
		{
		}

		protected override IntPtr LoadLibrary(string libraryName)
		{
			Libdl.dlerror();
			IntPtr intPtr = Libdl.dlopen(libraryName, 2);
			if (intPtr == IntPtr.Zero && !Path.IsPathRooted(libraryName))
			{
				string baseDirectory = AppContext.BaseDirectory;
				if (!string.IsNullOrWhiteSpace(baseDirectory))
				{
					intPtr = Libdl.dlopen(Path.Combine(baseDirectory, libraryName), 2);
				}
			}
			return intPtr;
		}

		protected override void FreeLibrary(IntPtr libraryHandle)
		{
			Libdl.dlclose(libraryHandle);
		}

		protected override IntPtr LoadFunction(string functionName)
		{
			return Libdl.dlsym(base.NativeHandle, functionName);
		}
	}

	private readonly string _libraryName;

	private readonly IntPtr _libraryHandle;

	public IntPtr NativeHandle => _libraryHandle;

	public NativeLibrary(string libraryName)
	{
		_libraryName = libraryName;
		_libraryHandle = LoadLibrary(_libraryName);
		if (_libraryHandle == IntPtr.Zero)
		{
			throw new InvalidOperationException("Could not load " + libraryName);
		}
	}

	protected abstract IntPtr LoadLibrary(string libraryName);

	protected abstract void FreeLibrary(IntPtr libraryHandle);

	protected abstract IntPtr LoadFunction(string functionName);

	public IntPtr LoadFunctionPointer(string functionName)
	{
		if (functionName == null)
		{
			throw new ArgumentNullException("functionName");
		}
		return LoadFunction(functionName);
	}

	public void Dispose()
	{
		FreeLibrary(_libraryHandle);
	}

	public static NativeLibrary Load(string libraryName)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			return new WindowsNativeLibrary(libraryName);
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX) /*|| OperatingSystem.IsAndroid()*/)
		{
			return new UnixNativeLibrary(libraryName);
		}
		throw new PlatformNotSupportedException("Cannot load native libraries on this platform: " + RuntimeInformation.OSDescription);
	}
}
