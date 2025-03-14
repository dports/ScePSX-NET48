namespace Vulkan;

public struct VkPhysicalDeviceExternalFenceInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalFenceHandleTypeFlagsKHR handleType;

	public static VkPhysicalDeviceExternalFenceInfoKHR New()
	{
		VkPhysicalDeviceExternalFenceInfoKHR result = default(VkPhysicalDeviceExternalFenceInfoKHR);
		result.sType = VkStructureType.PhysicalDeviceExternalFenceInfoKHR;
		return result;
	}
}
