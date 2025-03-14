namespace Vulkan;

public struct VkSamplerYcbcrConversionInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSamplerYcbcrConversionKHR conversion;

	public static VkSamplerYcbcrConversionInfoKHR New()
	{
		VkSamplerYcbcrConversionInfoKHR result = default(VkSamplerYcbcrConversionInfoKHR);
		result.sType = VkStructureType.SamplerYcbcrConversionInfoKHR;
		return result;
	}
}
