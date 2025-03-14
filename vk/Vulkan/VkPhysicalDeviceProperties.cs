namespace Vulkan;

public struct VkPhysicalDeviceProperties
{
	public uint apiVersion;

	public uint driverVersion;

	public uint vendorID;

	public uint deviceID;

	public VkPhysicalDeviceType deviceType;

	public unsafe fixed byte deviceName[256];

	public unsafe fixed byte pipelineCacheUUID[16];

	public VkPhysicalDeviceLimits limits;

	public VkPhysicalDeviceSparseProperties sparseProperties;
}
