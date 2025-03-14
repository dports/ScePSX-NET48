namespace Vulkan;

public struct VkImageFormatProperties
{
	public VkExtent3D maxExtent;

	public uint maxMipLevels;

	public uint maxArrayLayers;

	public VkSampleCountFlags sampleCounts;

	public ulong maxResourceSize;
}
