namespace Vulkan;

public struct VkImageSubresource
{
	public VkImageAspectFlags aspectMask;

	public uint mipLevel;

	public uint arrayLayer;
}
