namespace Vulkan;

public struct VkSamplerYcbcrConversionCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkFormat format;

	public VkSamplerYcbcrModelConversionKHR ycbcrModel;

	public VkSamplerYcbcrRangeKHR ycbcrRange;

	public VkComponentMapping components;

	public VkChromaLocationKHR xChromaOffset;

	public VkChromaLocationKHR yChromaOffset;

	public VkFilter chromaFilter;

	public VkBool32 forceExplicitReconstruction;

	public static VkSamplerYcbcrConversionCreateInfoKHR New()
	{
		VkSamplerYcbcrConversionCreateInfoKHR result = default(VkSamplerYcbcrConversionCreateInfoKHR);
		result.sType = VkStructureType.SamplerYcbcrConversionCreateInfoKHR;
		return result;
	}
}
