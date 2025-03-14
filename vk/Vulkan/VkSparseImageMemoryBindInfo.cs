namespace Vulkan;

public struct VkSparseImageMemoryBindInfo
{
	public VkImage image;

	public uint bindCount;

	public unsafe VkSparseImageMemoryBind* pBinds;
}
