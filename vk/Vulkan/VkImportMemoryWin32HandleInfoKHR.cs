using System;
using Vulkan.Win32;

namespace Vulkan;

public struct VkImportMemoryWin32HandleInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsKHR handleType;

	public HANDLE handle;

	public IntPtr name;

	public static VkImportMemoryWin32HandleInfoKHR New()
	{
		VkImportMemoryWin32HandleInfoKHR result = default(VkImportMemoryWin32HandleInfoKHR);
		result.sType = VkStructureType.ImportMemoryWin32HandleInfoKHR;
		return result;
	}
}
