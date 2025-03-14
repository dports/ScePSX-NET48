namespace Vulkan;

public struct VkImageSubresourceRange
{
	public VkImageAspectFlags aspectMask;

	public uint baseMipLevel;

	public uint levelCount;

	public uint baseArrayLayer;

	public uint layerCount;

	public VkImageSubresourceRange(VkImageAspectFlags aspectMask, uint baseMipLevel = 0u, uint levelCount = 1u, uint baseArrayLayer = 0u, uint layerCount = 1u)
	{
		this.aspectMask = aspectMask;
		this.baseMipLevel = baseMipLevel;
		this.levelCount = levelCount;
		this.baseArrayLayer = baseArrayLayer;
		this.layerCount = layerCount;
	}
}
