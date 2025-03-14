namespace Vulkan;

public struct VkPipelineDepthStencilStateCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkBool32 depthTestEnable;

	public VkBool32 depthWriteEnable;

	public VkCompareOp depthCompareOp;

	public VkBool32 depthBoundsTestEnable;

	public VkBool32 stencilTestEnable;

	public VkStencilOpState front;

	public VkStencilOpState back;

	public float minDepthBounds;

	public float maxDepthBounds;

	public static VkPipelineDepthStencilStateCreateInfo New()
	{
		VkPipelineDepthStencilStateCreateInfo result = default(VkPipelineDepthStencilStateCreateInfo);
		result.sType = VkStructureType.PipelineDepthStencilStateCreateInfo;
		return result;
	}
}
