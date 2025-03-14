namespace Vulkan;

public struct VkExportSemaphoreCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalSemaphoreHandleTypeFlagsKHR handleTypes;

	public static VkExportSemaphoreCreateInfoKHR New()
	{
		VkExportSemaphoreCreateInfoKHR result = default(VkExportSemaphoreCreateInfoKHR);
		result.sType = VkStructureType.ExportSemaphoreCreateInfoKHR;
		return result;
	}
}
