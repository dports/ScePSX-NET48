namespace Vulkan;

public struct VkPhysicalDeviceSparseImageFormatInfo2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkFormat format;

	public VkImageType type;

	public VkSampleCountFlags samples;

	public VkImageUsageFlags usage;

	public VkImageTiling tiling;

	public static VkPhysicalDeviceSparseImageFormatInfo2KHR New()
	{
		VkPhysicalDeviceSparseImageFormatInfo2KHR result = default(VkPhysicalDeviceSparseImageFormatInfo2KHR);
		result.sType = VkStructureType.PhysicalDeviceSparseImageFormatInfo2KHR;
		return result;
	}
}
