namespace Vulkan;

public struct VkImageFormatListCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint viewFormatCount;

	public unsafe VkFormat* pViewFormats;

	public static VkImageFormatListCreateInfoKHR New()
	{
		VkImageFormatListCreateInfoKHR result = default(VkImageFormatListCreateInfoKHR);
		result.sType = VkStructureType.ImageFormatListCreateInfoKHR;
		return result;
	}
}
