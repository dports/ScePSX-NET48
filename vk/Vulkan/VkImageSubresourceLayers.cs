namespace Vulkan;

public struct VkImageSubresourceLayers
{
	public VkImageAspectFlags aspectMask;

	public uint mipLevel;

	public uint baseArrayLayer;

	public uint layerCount;
}
