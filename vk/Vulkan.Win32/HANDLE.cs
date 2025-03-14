using System;

namespace Vulkan.Win32;

public struct HANDLE
{
	public IntPtr Handle;

	public static implicit operator IntPtr(HANDLE handle)
	{
		return handle.Handle;
	}

	public static implicit operator HANDLE(IntPtr handle)
	{
		HANDLE result = default(HANDLE);
		result.Handle = handle;
		return result;
	}
}
