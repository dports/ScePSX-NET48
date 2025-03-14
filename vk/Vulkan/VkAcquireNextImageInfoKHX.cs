namespace Vulkan;

public struct VkAcquireNextImageInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSwapchainKHR swapchain;

	public ulong timeout;

	public VkSemaphore semaphore;

	public VkFence fence;

	public uint deviceMask;

	public static VkAcquireNextImageInfoKHX New()
	{
		VkAcquireNextImageInfoKHX result = default(VkAcquireNextImageInfoKHX);
		result.sType = VkStructureType.AcquireNextImageInfoKHX;
		return result;
	}
}
