using System;
using Vulkan.Win32;

namespace Vulkan;

public struct VkImportFenceWin32HandleInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkFence fence;

	public VkFenceImportFlagsKHR flags;

	public VkExternalFenceHandleTypeFlagsKHR handleType;

	public HANDLE handle;

	public IntPtr name;

	public static VkImportFenceWin32HandleInfoKHR New()
	{
		VkImportFenceWin32HandleInfoKHR result = default(VkImportFenceWin32HandleInfoKHR);
		result.sType = VkStructureType.ImportFenceWin32HandleInfoKHR;
		return result;
	}
}
