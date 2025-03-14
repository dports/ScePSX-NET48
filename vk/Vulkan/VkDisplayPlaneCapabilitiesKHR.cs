namespace Vulkan;

public struct VkDisplayPlaneCapabilitiesKHR
{
	public VkDisplayPlaneAlphaFlagsKHR supportedAlpha;

	public VkOffset2D minSrcPosition;

	public VkOffset2D maxSrcPosition;

	public VkExtent2D minSrcExtent;

	public VkExtent2D maxSrcExtent;

	public VkOffset2D minDstPosition;

	public VkOffset2D maxDstPosition;

	public VkExtent2D minDstExtent;

	public VkExtent2D maxDstExtent;
}
