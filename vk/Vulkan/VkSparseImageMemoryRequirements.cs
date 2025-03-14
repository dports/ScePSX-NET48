namespace Vulkan;

public struct VkSparseImageMemoryRequirements
{
	public VkSparseImageFormatProperties formatProperties;

	public uint imageMipTailFirstLod;

	public ulong imageMipTailSize;

	public ulong imageMipTailOffset;

	public ulong imageMipTailStride;
}
