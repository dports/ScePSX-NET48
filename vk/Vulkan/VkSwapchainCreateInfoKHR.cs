namespace Vulkan;

public struct VkSwapchainCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSwapchainCreateFlagsKHR flags;

	public VkSurfaceKHR surface;

	public uint minImageCount;

	public VkFormat imageFormat;

	public VkColorSpaceKHR imageColorSpace;

	public VkExtent2D imageExtent;

	public uint imageArrayLayers;

	public VkImageUsageFlags imageUsage;

	public VkSharingMode imageSharingMode;

	public uint queueFamilyIndexCount;

	public unsafe uint* pQueueFamilyIndices;

	public VkSurfaceTransformFlagsKHR preTransform;

	public VkCompositeAlphaFlagsKHR compositeAlpha;

	public VkPresentModeKHR presentMode;

	public VkBool32 clipped;

	public VkSwapchainKHR oldSwapchain;

	public static VkSwapchainCreateInfoKHR New()
	{
		VkSwapchainCreateInfoKHR result = default(VkSwapchainCreateInfoKHR);
		result.sType = VkStructureType.SwapchainCreateInfoKHR;
		return result;
	}
}
