namespace Vulkan;

public struct VkImageViewUsageCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImageUsageFlags usage;

	public static VkImageViewUsageCreateInfoKHR New()
	{
		VkImageViewUsageCreateInfoKHR result = default(VkImageViewUsageCreateInfoKHR);
		result.sType = VkStructureType.ImageViewUsageCreateInfoKHR;
		return result;
	}
}
