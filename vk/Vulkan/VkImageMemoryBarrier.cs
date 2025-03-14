namespace Vulkan;

public struct VkImageMemoryBarrier
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkAccessFlags srcAccessMask;

	public VkAccessFlags dstAccessMask;

	public VkImageLayout oldLayout;

	public VkImageLayout newLayout;

	public uint srcQueueFamilyIndex;

	public uint dstQueueFamilyIndex;

	public VkImage image;

	public VkImageSubresourceRange subresourceRange;

	public static VkImageMemoryBarrier New()
	{
		VkImageMemoryBarrier result = default(VkImageMemoryBarrier);
		result.sType = VkStructureType.ImageMemoryBarrier;
		return result;
	}

	public unsafe VkImageMemoryBarrier(VkImage image, VkImageSubresourceRange subresourceRange, VkAccessFlags srcAccessMask, VkAccessFlags dstAccessMask, VkImageLayout oldLayout, VkImageLayout newLayout, uint srcQueueFamilyIndex = uint.MaxValue, uint dstQueueFamilyIndex = uint.MaxValue)
	{
		sType = VkStructureType.ImageMemoryBarrier;
		pNext = null;
		this.srcAccessMask = srcAccessMask;
		this.dstAccessMask = dstAccessMask;
		this.oldLayout = oldLayout;
		this.newLayout = newLayout;
		this.srcQueueFamilyIndex = srcQueueFamilyIndex;
		this.dstQueueFamilyIndex = dstQueueFamilyIndex;
		this.image = image;
		this.subresourceRange = subresourceRange;
	}
}
