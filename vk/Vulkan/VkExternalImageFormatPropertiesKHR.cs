namespace Vulkan;

public struct VkExternalImageFormatPropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryPropertiesKHR externalMemoryProperties;

	public static VkExternalImageFormatPropertiesKHR New()
	{
		VkExternalImageFormatPropertiesKHR result = default(VkExternalImageFormatPropertiesKHR);
		result.sType = VkStructureType.ExternalImageFormatPropertiesKHR;
		return result;
	}
}
