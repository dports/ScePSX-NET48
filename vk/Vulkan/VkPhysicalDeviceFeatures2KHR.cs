namespace Vulkan;

public struct VkPhysicalDeviceFeatures2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkPhysicalDeviceFeatures features;

	public static VkPhysicalDeviceFeatures2KHR New()
	{
		VkPhysicalDeviceFeatures2KHR result = default(VkPhysicalDeviceFeatures2KHR);
		result.sType = VkStructureType.PhysicalDeviceFeatures2KHR;
		return result;
	}
}
