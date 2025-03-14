namespace Vulkan;

public struct VkBufferCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBufferCreateFlags flags;

	public ulong size;

	public VkBufferUsageFlags usage;

	public VkSharingMode sharingMode;

	public uint queueFamilyIndexCount;

	public unsafe uint* pQueueFamilyIndices;

	public static VkBufferCreateInfo New()
	{
		VkBufferCreateInfo result = default(VkBufferCreateInfo);
		result.sType = VkStructureType.BufferCreateInfo;
		return result;
	}
}
