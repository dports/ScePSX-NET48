using Vulkan.Win32;

namespace Vulkan;

public struct VkExportMemoryWin32HandleInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public unsafe SECURITY_ATTRIBUTES* pAttributes;

	public uint dwAccess;

	public static VkExportMemoryWin32HandleInfoNV New()
	{
		VkExportMemoryWin32HandleInfoNV result = default(VkExportMemoryWin32HandleInfoNV);
		result.sType = VkStructureType.ExportMemoryWin32HandleInfoNV;
		return result;
	}
}
