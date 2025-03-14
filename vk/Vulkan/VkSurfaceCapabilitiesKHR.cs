namespace Vulkan;

public struct VkSurfaceCapabilitiesKHR
{
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
}
