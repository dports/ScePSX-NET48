using System;

namespace Vulkan.Win32;

public struct HINSTANCE
{
	public IntPtr Handle;

	public static implicit operator IntPtr(HINSTANCE hinst)
	{
		return hinst.Handle;
	}

	public static implicit operator HINSTANCE(IntPtr handle)
	{
		HINSTANCE result = default(HINSTANCE);
		result.Handle = handle;
		return result;
	}
}
