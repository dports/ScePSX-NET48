namespace Vulkan;

public struct VkSamplerYcbcrConversionImageFormatPropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint combinedImageSamplerDescriptorCount;

	public static VkSamplerYcbcrConversionImageFormatPropertiesKHR New()
	{
		VkSamplerYcbcrConversionImageFormatPropertiesKHR result = default(VkSamplerYcbcrConversionImageFormatPropertiesKHR);
		result.sType = VkStructureType.SamplerYcbcrConversionImageFormatPropertiesKHR;
		return result;
	}
}
