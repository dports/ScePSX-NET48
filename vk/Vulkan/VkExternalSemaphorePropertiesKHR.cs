namespace Vulkan;

public struct VkExternalSemaphorePropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalSemaphoreHandleTypeFlagsKHR exportFromImportedHandleTypes;

	public VkExternalSemaphoreHandleTypeFlagsKHR compatibleHandleTypes;

	public VkExternalSemaphoreFeatureFlagsKHR externalSemaphoreFeatures;

	public static VkExternalSemaphorePropertiesKHR New()
	{
		VkExternalSemaphorePropertiesKHR result = default(VkExternalSemaphorePropertiesKHR);
		result.sType = VkStructureType.ExternalSemaphorePropertiesKHR;
		return result;
	}
}
