namespace Vulkan;

public struct VkMemoryAllocateFlagsInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkMemoryAllocateFlagsKHX flags;

	public uint deviceMask;

	public static VkMemoryAllocateFlagsInfoKHX New()
	{
		VkMemoryAllocateFlagsInfoKHX result = default(VkMemoryAllocateFlagsInfoKHX);
		result.sType = VkStructureType.MemoryAllocateInfoKHX;
		return result;
	}
}
