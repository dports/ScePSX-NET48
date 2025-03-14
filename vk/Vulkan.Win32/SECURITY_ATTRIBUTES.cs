using System;

namespace Vulkan.Win32;

public struct SECURITY_ATTRIBUTES
{
	public uint nLength;

	public IntPtr lpSecurityDescriptor;

	public uint bInheritHandle;
}
