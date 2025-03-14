namespace Vulkan;

public struct VkPipelineColorBlendAttachmentState
{
	public VkBool32 blendEnable;

	public VkBlendFactor srcColorBlendFactor;

	public VkBlendFactor dstColorBlendFactor;

	public VkBlendOp colorBlendOp;

	public VkBlendFactor srcAlphaBlendFactor;

	public VkBlendFactor dstAlphaBlendFactor;

	public VkBlendOp alphaBlendOp;

	public VkColorComponentFlags colorWriteMask;
}
