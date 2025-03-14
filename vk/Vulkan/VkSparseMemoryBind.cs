namespace Vulkan;

public struct VkSparseMemoryBind
{
	public ulong resourceOffset;

	public ulong size;

	public VkDeviceMemory memory;

	public ulong memoryOffset;

	public VkSparseMemoryBindFlags flags;
}
