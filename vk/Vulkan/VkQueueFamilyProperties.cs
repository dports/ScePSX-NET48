namespace Vulkan;

public struct VkQueueFamilyProperties
{
	public VkQueueFlags queueFlags;

	public uint queueCount;

	public uint timestampValidBits;

	public VkExtent3D minImageTransferGranularity;
}
