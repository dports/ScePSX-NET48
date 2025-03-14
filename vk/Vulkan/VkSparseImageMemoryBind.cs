namespace Vulkan;

public struct VkSparseImageMemoryBind
{
	public VkImageSubresource subresource;

	public VkOffset3D offset;

	public VkExtent3D extent;

	public VkDeviceMemory memory;

	public ulong memoryOffset;

	public VkSparseMemoryBindFlags flags;
}
