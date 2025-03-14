namespace Vulkan;

public struct VkExportFenceCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalFenceHandleTypeFlagsKHR handleTypes;

	public static VkExportFenceCreateInfoKHR New()
	{
		VkExportFenceCreateInfoKHR result = default(VkExportFenceCreateInfoKHR);
		result.sType = VkStructureType.ExportFenceCreateInfoKHR;
		return result;
	}
}
