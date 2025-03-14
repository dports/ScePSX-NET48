namespace Vulkan;

public struct VkSubpassDependency
{
	public uint srcSubpass;

	public uint dstSubpass;

	public VkPipelineStageFlags srcStageMask;

	public VkPipelineStageFlags dstStageMask;

	public VkAccessFlags srcAccessMask;

	public VkAccessFlags dstAccessMask;

	public VkDependencyFlags dependencyFlags;
}
