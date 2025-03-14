namespace Vulkan;

public struct VkPipelineViewportWScalingStateCreateInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 viewportWScalingEnable;

	public uint viewportCount;

	public unsafe VkViewportWScalingNV* pViewportWScalings;

	public static VkPipelineViewportWScalingStateCreateInfoNV New()
	{
		VkPipelineViewportWScalingStateCreateInfoNV result = default(VkPipelineViewportWScalingStateCreateInfoNV);
		result.sType = VkStructureType.PipelineViewportWScalingStateCreateInfoNV;
		return result;
	}
}
