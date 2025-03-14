namespace Vulkan;

public struct VkSemaphoreGetWin32HandleInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSemaphore semaphore;

	public VkExternalSemaphoreHandleTypeFlagsKHR handleType;

	public static VkSemaphoreGetWin32HandleInfoKHR New()
	{
		VkSemaphoreGetWin32HandleInfoKHR result = default(VkSemaphoreGetWin32HandleInfoKHR);
		result.sType = VkStructureType.SemaphoreGetWin32HandleInfoKHR;
		return result;
	}
}
