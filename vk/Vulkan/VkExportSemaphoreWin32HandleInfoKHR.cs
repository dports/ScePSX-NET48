using System;
using Vulkan.Win32;

namespace Vulkan;

public struct VkExportSemaphoreWin32HandleInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public unsafe SECURITY_ATTRIBUTES* pAttributes;

	public uint dwAccess;

	public IntPtr name;

	public static VkExportSemaphoreWin32HandleInfoKHR New()
	{
		VkExportSemaphoreWin32HandleInfoKHR result = default(VkExportSemaphoreWin32HandleInfoKHR);
		result.sType = VkStructureType.ExportSemaphoreWin32HandleInfoKHR;
		return result;
	}
}
