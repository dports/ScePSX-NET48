namespace Vulkan;

public struct VkExportMemoryAllocateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsKHR handleTypes;

	public static VkExportMemoryAllocateInfoKHR New()
	{
		VkExportMemoryAllocateInfoKHR result = default(VkExportMemoryAllocateInfoKHR);
		result.sType = VkStructureType.ExportMemoryAllocateInfoKHR;
		return result;
	}
}
