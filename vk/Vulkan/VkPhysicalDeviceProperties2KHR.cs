namespace Vulkan;

public struct VkPhysicalDeviceProperties2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkPhysicalDeviceProperties properties;

	public static VkPhysicalDeviceProperties2KHR New()
	{
		VkPhysicalDeviceProperties2KHR result = default(VkPhysicalDeviceProperties2KHR);
		result.sType = VkStructureType.PhysicalDeviceProperties2KHR;
		return result;
	}
}
