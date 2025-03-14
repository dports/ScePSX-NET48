namespace Vulkan;

public struct VkExternalMemoryPropertiesKHR
{
	public VkExternalMemoryFeatureFlagsKHR externalMemoryFeatures;

	public VkExternalMemoryHandleTypeFlagsKHR exportFromImportedHandleTypes;

	public VkExternalMemoryHandleTypeFlagsKHR compatibleHandleTypes;
}
