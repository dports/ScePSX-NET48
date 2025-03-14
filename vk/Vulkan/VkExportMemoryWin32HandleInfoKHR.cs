using System;
using Vulkan.Win32;

namespace Vulkan;

public struct VkExportMemoryWin32HandleInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public unsafe SECURITY_ATTRIBUTES* pAttributes;

	public uint dwAccess;

	public IntPtr name;

	public static VkExportMemoryWin32HandleInfoKHR New()
	{
		VkExportMemoryWin32HandleInfoKHR result = default(VkExportMemoryWin32HandleInfoKHR);
		result.sType = VkStructureType.ExportMemoryWin32HandleInfoKHR;
		return result;
	}
}
