namespace Vulkan;

public struct VkSparseImageOpaqueMemoryBindInfo
{
	public VkImage image;

	public uint bindCount;

	public unsafe VkSparseMemoryBind* pBinds;
}
