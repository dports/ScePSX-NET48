namespace Vulkan;

public struct VkStencilOpState
{
	public VkStencilOp failOp;

	public VkStencilOp passOp;

	public VkStencilOp depthFailOp;

	public VkCompareOp compareOp;

	public uint compareMask;

	public uint writeMask;

	public uint reference;
}
