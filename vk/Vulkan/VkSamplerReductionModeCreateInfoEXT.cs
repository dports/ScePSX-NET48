namespace Vulkan;

public struct VkSamplerReductionModeCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSamplerReductionModeEXT reductionMode;

	public static VkSamplerReductionModeCreateInfoEXT New()
	{
		VkSamplerReductionModeCreateInfoEXT result = default(VkSamplerReductionModeCreateInfoEXT);
		result.sType = VkStructureType.SamplerReductionModeCreateInfoEXT;
		return result;
	}
}
