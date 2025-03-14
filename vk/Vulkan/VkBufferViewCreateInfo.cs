namespace Vulkan;

public struct VkBufferViewCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkBuffer buffer;

	public VkFormat format;

	public ulong offset;

	public ulong range;

	public static VkBufferViewCreateInfo New()
	{
		VkBufferViewCreateInfo result = default(VkBufferViewCreateInfo);
		result.sType = VkStructureType.BufferViewCreateInfo;
		return result;
	}
}
