namespace Vulkan;

public struct VkPipelineSampleLocationsStateCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 sampleLocationsEnable;

	public VkSampleLocationsInfoEXT sampleLocationsInfo;

	public static VkPipelineSampleLocationsStateCreateInfoEXT New()
	{
		VkPipelineSampleLocationsStateCreateInfoEXT result = default(VkPipelineSampleLocationsStateCreateInfoEXT);
		result.sType = VkStructureType.PipelineSampleLocationsStateCreateInfoEXT;
		return result;
	}
}
