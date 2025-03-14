namespace Vulkan;

public struct VkDeviceGroupDeviceCreateInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint physicalDeviceCount;

	public unsafe VkPhysicalDevice* pPhysicalDevices;

	public static VkDeviceGroupDeviceCreateInfoKHX New()
	{
		VkDeviceGroupDeviceCreateInfoKHX result = default(VkDeviceGroupDeviceCreateInfoKHX);
		result.sType = VkStructureType.DeviceGroupDeviceCreateInfoKHX;
		return result;
	}
}
