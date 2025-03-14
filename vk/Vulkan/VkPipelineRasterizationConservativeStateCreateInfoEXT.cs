namespace Vulkan;

public struct VkPipelineRasterizationConservativeStateCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkConservativeRasterizationModeEXT conservativeRasterizationMode;

	public float extraPrimitiveOverestimationSize;

	public static VkPipelineRasterizationConservativeStateCreateInfoEXT New()
	{
		VkPipelineRasterizationConservativeStateCreateInfoEXT result = default(VkPipelineRasterizationConservativeStateCreateInfoEXT);
		result.sType = VkStructureType.PipelineRasterizationConservativeStateCreateInfoEXT;
		return result;
	}
}
