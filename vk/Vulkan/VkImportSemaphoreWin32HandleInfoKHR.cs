using System;
using Vulkan.Win32;

namespace Vulkan;

public struct VkImportSemaphoreWin32HandleInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSemaphore semaphore;

	public VkSemaphoreImportFlagsKHR flags;

	public VkExternalSemaphoreHandleTypeFlagsKHR handleType;

	public HANDLE handle;

	public IntPtr name;

	public static VkImportSemaphoreWin32HandleInfoKHR New()
	{
		VkImportSemaphoreWin32HandleInfoKHR result = default(VkImportSemaphoreWin32HandleInfoKHR);
		result.sType = VkStructureType.ImportSemaphoreWin32HandleInfoKHR;
		return result;
	}
}
