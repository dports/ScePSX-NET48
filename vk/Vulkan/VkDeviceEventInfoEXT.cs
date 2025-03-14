namespace Vulkan;

public struct VkDeviceEventInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDeviceEventTypeEXT deviceEvent;

	public static VkDeviceEventInfoEXT New()
	{
		VkDeviceEventInfoEXT result = default(VkDeviceEventInfoEXT);
		result.sType = VkStructureType.DeviceEventInfoEXT;
		return result;
	}
}
