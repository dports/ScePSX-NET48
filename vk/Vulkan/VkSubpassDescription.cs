namespace Vulkan;

public struct VkSubpassDescription
{
	public VkSubpassDescriptionFlags flags;

	public VkPipelineBindPoint pipelineBindPoint;

	public uint inputAttachmentCount;

	public unsafe VkAttachmentReference* pInputAttachments;

	public uint colorAttachmentCount;

	public unsafe VkAttachmentReference* pColorAttachments;

	public unsafe VkAttachmentReference* pResolveAttachments;

	public unsafe VkAttachmentReference* pDepthStencilAttachment;

	public uint preserveAttachmentCount;

	public unsafe uint* pPreserveAttachments;
}
