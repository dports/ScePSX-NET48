namespace Vulkan;

public struct VkSurfaceCapabilities2EXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint minImageCount;

	public uint maxImageCount;

	public VkExtent2D currentExtent;

	public VkExtent2D minImageExtent;

	public VkExtent2D maxImageExtent;

	public uint maxImageArrayLayers;

	public VkSurfaceTransformFlagsKHR supportedTransforms;

	public VkSurfaceTransformFlagsKHR currentTransform;

	public VkCompositeAlphaFlagsKHR supportedCompositeAlpha;

	public VkImageUsageFlags supportedUsageFlags;

	public VkSurfaceCounterFlagsEXT supportedSurfaceCounters;

	public static VkSurfaceCapabilities2EXT New()
	{
		VkSurfaceCapabilities2EXT result = default(VkSurfaceCapabilities2EXT);
		result.sType = VkStructureType.SurfaceCapabilities2EXT;
		return result;
	}
}
