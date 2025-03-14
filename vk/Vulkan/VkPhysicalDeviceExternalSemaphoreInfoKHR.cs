namespace Vulkan;

public struct VkPhysicalDeviceExternalSemaphoreInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalSemaphoreHandleTypeFlagsKHR handleType;

	public static VkPhysicalDeviceExternalSemaphoreInfoKHR New()
	{
		VkPhysicalDeviceExternalSemaphoreInfoKHR result = default(VkPhysicalDeviceExternalSemaphoreInfoKHR);
		result.sType = VkStructureType.PhysicalDeviceExternalSemaphoreInfoKHR;
		return result;
	}
}
