namespace Vulkan;

public struct VkDeviceQueueGlobalPriorityCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkQueueGlobalPriorityEXT globalPriority;

	public static VkDeviceQueueGlobalPriorityCreateInfoEXT New()
	{
		VkDeviceQueueGlobalPriorityCreateInfoEXT result = default(VkDeviceQueueGlobalPriorityCreateInfoEXT);
		result.sType = VkStructureType.DeviceQueueGlobalPriorityCreateInfoEXT;
		return result;
	}
}
