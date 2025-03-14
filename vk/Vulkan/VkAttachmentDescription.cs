namespace Vulkan;

public struct VkAttachmentDescription
{
	public VkAttachmentDescriptionFlags flags;

	public VkFormat format;

	public VkSampleCountFlags samples;

	public VkAttachmentLoadOp loadOp;

	public VkAttachmentStoreOp storeOp;

	public VkAttachmentLoadOp stencilLoadOp;

	public VkAttachmentStoreOp stencilStoreOp;

	public VkImageLayout initialLayout;

	public VkImageLayout finalLayout;
}
