namespace Vulkan;

public struct VkClearAttachment
{
	public VkImageAspectFlags aspectMask;

	public uint colorAttachment;

	public VkClearValue clearValue;
}
