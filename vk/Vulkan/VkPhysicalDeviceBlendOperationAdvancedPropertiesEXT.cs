namespace Vulkan;

public struct VkPhysicalDeviceBlendOperationAdvancedPropertiesEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint advancedBlendMaxColorAttachments;

	public VkBool32 advancedBlendIndependentBlend;

	public VkBool32 advancedBlendNonPremultipliedSrcColor;

	public VkBool32 advancedBlendNonPremultipliedDstColor;

	public VkBool32 advancedBlendCorrelatedOverlap;

	public VkBool32 advancedBlendAllOperations;

	public static VkPhysicalDeviceBlendOperationAdvancedPropertiesEXT New()
	{
		VkPhysicalDeviceBlendOperationAdvancedPropertiesEXT result = default(VkPhysicalDeviceBlendOperationAdvancedPropertiesEXT);
		result.sType = VkStructureType.PhysicalDeviceBlendOperationAdvancedPropertiesEXT;
		return result;
	}
}
