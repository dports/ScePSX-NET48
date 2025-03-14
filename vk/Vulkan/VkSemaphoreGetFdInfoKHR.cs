namespace Vulkan;

public struct VkSemaphoreGetFdInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSemaphore semaphore;

	public VkExternalSemaphoreHandleTypeFlagsKHR handleType;

	public static VkSemaphoreGetFdInfoKHR New()
	{
		VkSemaphoreGetFdInfoKHR result = default(VkSemaphoreGetFdInfoKHR);
		result.sType = VkStructureType.SemaphoreGetFdInfoKHR;
		return result;
	}
}
