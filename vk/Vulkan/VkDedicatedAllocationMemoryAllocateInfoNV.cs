namespace Vulkan;

public struct VkDedicatedAllocationMemoryAllocateInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImage image;

	public VkBuffer buffer;

	public static VkDedicatedAllocationMemoryAllocateInfoNV New()
	{
		VkDedicatedAllocationMemoryAllocateInfoNV result = default(VkDedicatedAllocationMemoryAllocateInfoNV);
		result.sType = VkStructureType.DedicatedAllocationMemoryAllocateInfoNV;
		return result;
	}
}
