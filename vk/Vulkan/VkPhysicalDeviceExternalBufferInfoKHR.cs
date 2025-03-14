namespace Vulkan;

public struct VkPhysicalDeviceExternalBufferInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBufferCreateFlags flags;

	public VkBufferUsageFlags usage;

	public VkExternalMemoryHandleTypeFlagsKHR handleType;

	public static VkPhysicalDeviceExternalBufferInfoKHR New()
	{
		VkPhysicalDeviceExternalBufferInfoKHR result = default(VkPhysicalDeviceExternalBufferInfoKHR);
		result.sType = VkStructureType.PhysicalDeviceExternalBufferInfoKHR;
		return result;
	}
}
