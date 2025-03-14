namespace Vulkan;

public struct VkPhysicalDeviceSamplerFilterMinmaxPropertiesEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 filterMinmaxSingleComponentFormats;

	public VkBool32 filterMinmaxImageComponentMapping;

	public static VkPhysicalDeviceSamplerFilterMinmaxPropertiesEXT New()
	{
		VkPhysicalDeviceSamplerFilterMinmaxPropertiesEXT result = default(VkPhysicalDeviceSamplerFilterMinmaxPropertiesEXT);
		result.sType = VkStructureType.PhysicalDeviceSamplerFilterMinmaxPropertiesEXT;
		return result;
	}
}
