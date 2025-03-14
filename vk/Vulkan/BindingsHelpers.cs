using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vulkan;

public static class BindingsHelpers
{
	public unsafe static StringHandle StringToHGlobalUtf8(string s)
	{
		int byteCount = Encoding.UTF8.GetByteCount(s);
		IntPtr handle = Marshal.AllocHGlobal(byteCount);
		fixed (char* chars = s)
		{
			Encoding.UTF8.GetBytes(chars, s.Length, (byte*)handle.ToPointer(), byteCount);
		}
		StringHandle result = default(StringHandle);
		result.Handle = handle;
		return result;
	}

	public static void FreeHGlobal(StringHandle ptr)
	{
		Marshal.FreeHGlobal(ptr.Handle);
	}
}
