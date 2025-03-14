namespace Vulkan;

public struct VkImageResolve
{
	public VkImageSubresourceLayers srcSubresource;

	public VkOffset3D srcOffset;

	public VkImageSubresourceLayers dstSubresource;

	public VkOffset3D dstOffset;

	public VkExtent3D extent;
}
