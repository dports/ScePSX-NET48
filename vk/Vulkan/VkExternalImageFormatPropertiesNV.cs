namespace Vulkan;

public struct VkExternalImageFormatPropertiesNV
{
	public VkImageFormatProperties imageFormatProperties;

	public VkExternalMemoryFeatureFlagsNV externalMemoryFeatures;

	public VkExternalMemoryHandleTypeFlagsNV exportFromImportedHandleTypes;

	public VkExternalMemoryHandleTypeFlagsNV compatibleHandleTypes;
}
