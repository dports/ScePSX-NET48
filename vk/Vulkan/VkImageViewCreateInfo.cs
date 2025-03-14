namespace Vulkan;

public struct VkImageViewCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkImage image;

	public VkImageViewType viewType;

	public VkFormat format;

	public VkComponentMapping components;

	public VkImageSubresourceRange subresourceRange;

	public static VkImageViewCreateInfo New()
	{
		VkImageViewCreateInfo result = default(VkImageViewCreateInfo);
		result.sType = VkStructureType.ImageViewCreateInfo;
		return result;
	}
}
