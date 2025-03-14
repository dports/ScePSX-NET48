namespace Vulkan;

public struct VkMappedMemoryRange
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDeviceMemory memory;

	public ulong offset;

	public ulong size;

	public static VkMappedMemoryRange New()
	{
		VkMappedMemoryRange result = default(VkMappedMemoryRange);
		result.sType = VkStructureType.MappedMemoryRange;
		return result;
	}
}
