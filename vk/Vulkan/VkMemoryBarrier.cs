namespace Vulkan;

public struct VkMemoryBarrier
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkAccessFlags srcAccessMask;

	public VkAccessFlags dstAccessMask;

	public static VkMemoryBarrier New()
	{
		VkMemoryBarrier result = default(VkMemoryBarrier);
		result.sType = VkStructureType.MemoryBarrier;
		return result;
	}
}
