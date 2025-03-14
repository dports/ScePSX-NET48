namespace Vulkan;

public struct VkImageMemoryRequirementsInfo2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImage image;

	public static VkImageMemoryRequirementsInfo2KHR New()
	{
		VkImageMemoryRequirementsInfo2KHR result = default(VkImageMemoryRequirementsInfo2KHR);
		result.sType = VkStructureType.ImageMemoryRequirementsInfo2KHR;
		return result;
	}
}
