namespace Vulkan;

public struct VkImageCopy
{
	public VkImageSubresourceLayers srcSubresource;

	public VkOffset3D srcOffset;

	public VkImageSubresourceLayers dstSubresource;

	public VkOffset3D dstOffset;

	public VkExtent3D extent;
}
