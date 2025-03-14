namespace Vulkan;

public struct VkFramebufferCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkRenderPass renderPass;

	public uint attachmentCount;

	public unsafe VkImageView* pAttachments;

	public uint width;

	public uint height;

	public uint layers;

	public static VkFramebufferCreateInfo New()
	{
		VkFramebufferCreateInfo result = default(VkFramebufferCreateInfo);
		result.sType = VkStructureType.FramebufferCreateInfo;
		return result;
	}
}
