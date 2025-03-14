namespace Vulkan;

public struct VkPipelineRasterizationStateRasterizationOrderAMD
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkRasterizationOrderAMD rasterizationOrder;

	public static VkPipelineRasterizationStateRasterizationOrderAMD New()
	{
		VkPipelineRasterizationStateRasterizationOrderAMD result = default(VkPipelineRasterizationStateRasterizationOrderAMD);
		result.sType = VkStructureType.PipelineRasterizationStateRasterizationOrderAMD;
		return result;
	}
}
