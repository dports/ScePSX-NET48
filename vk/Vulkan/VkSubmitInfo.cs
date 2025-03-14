namespace Vulkan;

public struct VkSubmitInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint waitSemaphoreCount;

	public unsafe VkSemaphore* pWaitSemaphores;

	public unsafe VkPipelineStageFlags* pWaitDstStageMask;

	public uint commandBufferCount;

	public unsafe VkCommandBuffer* pCommandBuffers;

	public uint signalSemaphoreCount;

	public unsafe VkSemaphore* pSignalSemaphores;

	public static VkSubmitInfo New()
	{
		VkSubmitInfo result = default(VkSubmitInfo);
		result.sType = VkStructureType.SubmitInfo;
		return result;
	}
}
