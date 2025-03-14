namespace Vulkan;

public struct VkMemoryAllocateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public ulong allocationSize;

	public uint memoryTypeIndex;

	public static VkMemoryAllocateInfo New()
	{
		VkMemoryAllocateInfo result = default(VkMemoryAllocateInfo);
		result.sType = VkStructureType.MemoryAllocateInfo;
		return result;
	}
}
