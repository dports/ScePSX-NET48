namespace Vulkan;

public struct VkPipelineCoverageToColorStateCreateInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkBool32 coverageToColorEnable;

	public uint coverageToColorLocation;

	public static VkPipelineCoverageToColorStateCreateInfoNV New()
	{
		VkPipelineCoverageToColorStateCreateInfoNV result = default(VkPipelineCoverageToColorStateCreateInfoNV);
		result.sType = VkStructureType.PipelineCoverageToColorStateCreateInfoNV;
		return result;
	}
}
