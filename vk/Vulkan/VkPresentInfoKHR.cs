namespace Vulkan;

public struct VkPresentInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint waitSemaphoreCount;

	public unsafe VkSemaphore* pWaitSemaphores;

	public uint swapchainCount;

	public unsafe VkSwapchainKHR* pSwapchains;

	public unsafe uint* pImageIndices;

	public unsafe VkResult* pResults;

	public static VkPresentInfoKHR New()
	{
		VkPresentInfoKHR result = default(VkPresentInfoKHR);
		result.sType = VkStructureType.PresentInfoKHR;
		return result;
	}
}
