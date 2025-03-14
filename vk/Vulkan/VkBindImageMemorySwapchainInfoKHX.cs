namespace Vulkan;

public struct VkBindImageMemorySwapchainInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSwapchainKHR swapchain;

	public uint imageIndex;

	public static VkBindImageMemorySwapchainInfoKHX New()
	{
		VkBindImageMemorySwapchainInfoKHX result = default(VkBindImageMemorySwapchainInfoKHX);
		result.sType = VkStructureType.BindImageMemorySwapchainInfoKHX;
		return result;
	}
}
