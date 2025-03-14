namespace Vulkan;

public struct VkImageSparseMemoryRequirementsInfo2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImage image;

	public static VkImageSparseMemoryRequirementsInfo2KHR New()
	{
		VkImageSparseMemoryRequirementsInfo2KHR result = default(VkImageSparseMemoryRequirementsInfo2KHR);
		result.sType = VkStructureType.ImageSparseMemoryRequirementsInfo2KHR;
		return result;
	}
}
