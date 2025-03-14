using System;
using Vulkan.Win32;

namespace Vulkan;

public struct VkExportFenceWin32HandleInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public unsafe SECURITY_ATTRIBUTES* pAttributes;

	public uint dwAccess;

	public IntPtr name;

	public static VkExportFenceWin32HandleInfoKHR New()
	{
		VkExportFenceWin32HandleInfoKHR result = default(VkExportFenceWin32HandleInfoKHR);
		result.sType = VkStructureType.ExportFenceWin32HandleInfoKHR;
		return result;
	}
}
