namespace Vulkan;

public struct VkImageSwapchainCreateInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSwapchainKHR swapchain;

	public static VkImageSwapchainCreateInfoKHX New()
	{
		VkImageSwapchainCreateInfoKHX result = default(VkImageSwapchainCreateInfoKHX);
		result.sType = VkStructureType.ImageSwapchainCreateInfoKHX;
		return result;
	}
}
