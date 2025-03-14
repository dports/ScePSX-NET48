namespace Vulkan;

public struct VkPhysicalDeviceImageFormatInfo2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkFormat format;

	public VkImageType type;

	public VkImageTiling tiling;

	public VkImageUsageFlags usage;

	public VkImageCreateFlags flags;

	public static VkPhysicalDeviceImageFormatInfo2KHR New()
	{
		VkPhysicalDeviceImageFormatInfo2KHR result = default(VkPhysicalDeviceImageFormatInfo2KHR);
		result.sType = VkStructureType.PhysicalDeviceImageFormatInfo2KHR;
		return result;
	}
}
