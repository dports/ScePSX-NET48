namespace Vulkan;

public struct VkPhysicalDeviceBlendOperationAdvancedFeaturesEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 advancedBlendCoherentOperations;

	public static VkPhysicalDeviceBlendOperationAdvancedFeaturesEXT New()
	{
		VkPhysicalDeviceBlendOperationAdvancedFeaturesEXT result = default(VkPhysicalDeviceBlendOperationAdvancedFeaturesEXT);
		result.sType = VkStructureType.PhysicalDeviceBlendOperationAdvancedFeaturesEXT;
		return result;
	}
}
