namespace Vulkan;

public struct VkSparseImageFormatProperties
{
	public VkImageAspectFlags aspectMask;

	public VkExtent3D imageGranularity;

	public VkSparseImageFormatFlags flags;
}
