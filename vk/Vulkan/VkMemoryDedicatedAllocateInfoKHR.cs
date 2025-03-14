namespace Vulkan;

public struct VkMemoryDedicatedAllocateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImage image;

	public VkBuffer buffer;

	public static VkMemoryDedicatedAllocateInfoKHR New()
	{
		VkMemoryDedicatedAllocateInfoKHR result = default(VkMemoryDedicatedAllocateInfoKHR);
		result.sType = VkStructureType.MemoryDedicatedAllocateInfoKHR;
		return result;
	}
}
