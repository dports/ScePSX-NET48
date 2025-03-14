namespace Vulkan;

public struct VkDeviceCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint queueCreateInfoCount;

	public unsafe VkDeviceQueueCreateInfo* pQueueCreateInfos;

	public uint enabledLayerCount;

	public unsafe byte** ppEnabledLayerNames;

	public uint enabledExtensionCount;

	public unsafe byte** ppEnabledExtensionNames;

	public unsafe VkPhysicalDeviceFeatures* pEnabledFeatures;

	public static VkDeviceCreateInfo New()
	{
		VkDeviceCreateInfo result = default(VkDeviceCreateInfo);
		result.sType = VkStructureType.DeviceCreateInfo;
		return result;
	}
}
