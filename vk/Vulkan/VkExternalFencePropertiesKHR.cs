namespace Vulkan;

public struct VkExternalFencePropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalFenceHandleTypeFlagsKHR exportFromImportedHandleTypes;

	public VkExternalFenceHandleTypeFlagsKHR compatibleHandleTypes;

	public VkExternalFenceFeatureFlagsKHR externalFenceFeatures;

	public static VkExternalFencePropertiesKHR New()
	{
		VkExternalFencePropertiesKHR result = default(VkExternalFencePropertiesKHR);
		result.sType = VkStructureType.ExternalFencePropertiesKHR;
		return result;
	}
}
