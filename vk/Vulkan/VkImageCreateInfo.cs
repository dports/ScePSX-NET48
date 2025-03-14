namespace Vulkan;

public struct VkImageCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImageCreateFlags flags;

	public VkImageType imageType;

	public VkFormat format;

	public VkExtent3D extent;

	public uint mipLevels;

	public uint arrayLayers;

	public VkSampleCountFlags samples;

	public VkImageTiling tiling;

	public VkImageUsageFlags usage;

	public VkSharingMode sharingMode;

	public uint queueFamilyIndexCount;

	public unsafe uint* pQueueFamilyIndices;

	public VkImageLayout initialLayout;

	public static VkImageCreateInfo New()
	{
		VkImageCreateInfo result = default(VkImageCreateInfo);
		result.sType = VkStructureType.ImageCreateInfo;
		return result;
	}
}
