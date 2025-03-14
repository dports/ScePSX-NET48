namespace Vulkan;

public struct VkObjectTableCreateInfoNVX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint objectCount;

	public unsafe VkObjectEntryTypeNVX* pObjectEntryTypes;

	public unsafe uint* pObjectEntryCounts;

	public unsafe VkObjectEntryUsageFlagsNVX* pObjectEntryUsageFlags;

	public uint maxUniformBuffersPerDescriptor;

	public uint maxStorageBuffersPerDescriptor;

	public uint maxStorageImagesPerDescriptor;

	public uint maxSampledImagesPerDescriptor;

	public uint maxPipelineLayouts;

	public static VkObjectTableCreateInfoNVX New()
	{
		VkObjectTableCreateInfoNVX result = default(VkObjectTableCreateInfoNVX);
		result.sType = VkStructureType.ObjectTableCreateInfoNVX;
		return result;
	}
}
