namespace Vulkan;

public struct VkQueueFamilyProperties2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkQueueFamilyProperties queueFamilyProperties;

	public static VkQueueFamilyProperties2KHR New()
	{
		VkQueueFamilyProperties2KHR result = default(VkQueueFamilyProperties2KHR);
		result.sType = VkStructureType.QueueFamilyProperties2KHR;
		return result;
	}
}
