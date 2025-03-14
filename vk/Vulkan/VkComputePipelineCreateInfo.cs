namespace Vulkan;

public struct VkComputePipelineCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkPipelineCreateFlags flags;

	public VkPipelineShaderStageCreateInfo stage;

	public VkPipelineLayout layout;

	public VkPipeline basePipelineHandle;

	public int basePipelineIndex;

	public static VkComputePipelineCreateInfo New()
	{
		VkComputePipelineCreateInfo result = default(VkComputePipelineCreateInfo);
		result.sType = VkStructureType.ComputePipelineCreateInfo;
		return result;
	}
}
