namespace Vulkan;

public struct VkPipelineColorBlendAdvancedStateCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 srcPremultiplied;

	public VkBool32 dstPremultiplied;

	public VkBlendOverlapEXT blendOverlap;

	public static VkPipelineColorBlendAdvancedStateCreateInfoEXT New()
	{
		VkPipelineColorBlendAdvancedStateCreateInfoEXT result = default(VkPipelineColorBlendAdvancedStateCreateInfoEXT);
		result.sType = VkStructureType.PipelineColorBlendAdvancedStateCreateInfoEXT;
		return result;
	}
}
