namespace Vulkan;

public struct VkPhysicalDeviceMemoryProperties2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkPhysicalDeviceMemoryProperties memoryProperties;

	public static VkPhysicalDeviceMemoryProperties2KHR New()
	{
		VkPhysicalDeviceMemoryProperties2KHR result = default(VkPhysicalDeviceMemoryProperties2KHR);
		result.sType = VkStructureType.PhysicalDeviceMemoryProperties2KHR;
		return result;
	}
}
