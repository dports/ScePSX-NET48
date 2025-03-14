namespace Vulkan;

public struct VkSparseBufferMemoryBindInfo
{
	public VkBuffer buffer;

	public uint bindCount;

	public unsafe VkSparseMemoryBind* pBinds;
}
