namespace Vulkan;

public struct VkBufferMemoryBarrier
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkAccessFlags srcAccessMask;

	public VkAccessFlags dstAccessMask;

	public uint srcQueueFamilyIndex;

	public uint dstQueueFamilyIndex;

	public VkBuffer buffer;

	public ulong offset;

	public ulong size;

	public static VkBufferMemoryBarrier New()
	{
		VkBufferMemoryBarrier result = default(VkBufferMemoryBarrier);
		result.sType = VkStructureType.BufferMemoryBarrier;
		return result;
	}
}
