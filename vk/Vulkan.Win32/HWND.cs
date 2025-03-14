using System;

namespace Vulkan.Win32;

public struct HWND
{
	public IntPtr Handle;

	public static implicit operator IntPtr(HWND hwnd)
	{
		return hwnd.Handle;
	}

	public static implicit operator HWND(IntPtr handle)
	{
		HWND result = default(HWND);
		result.Handle = handle;
		return result;
	}
}
