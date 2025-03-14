namespace Vulkan;

public struct VkPhysicalDeviceSamplerYcbcrConversionFeaturesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 samplerYcbcrConversion;

	public static VkPhysicalDeviceSamplerYcbcrConversionFeaturesKHR New()
	{
		VkPhysicalDeviceSamplerYcbcrConversionFeaturesKHR result = default(VkPhysicalDeviceSamplerYcbcrConversionFeaturesKHR);
		result.sType = VkStructureType.PhysicalDeviceSamplerYcbcrConversionFeaturesKHR;
		return result;
	}
}
