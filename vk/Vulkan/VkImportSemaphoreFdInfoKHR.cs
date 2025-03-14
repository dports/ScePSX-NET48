namespace Vulkan;

public struct VkImportSemaphoreFdInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSemaphore semaphore;

	public VkSemaphoreImportFlagsKHR flags;

	public VkExternalSemaphoreHandleTypeFlagsKHR handleType;

	public int fd;

	public static VkImportSemaphoreFdInfoKHR New()
	{
		VkImportSemaphoreFdInfoKHR result = default(VkImportSemaphoreFdInfoKHR);
		result.sType = VkStructureType.ImportSemaphoreFdInfoKHR;
		return result;
	}
}
