namespace Vulkan;

public struct VkBufferImageCopy
{
	public ulong bufferOffset;

	public uint bufferRowLength;

	public uint bufferImageHeight;

	public VkImageSubresourceLayers imageSubresource;

	public VkOffset3D imageOffset;

	public VkExtent3D imageExtent;
}
