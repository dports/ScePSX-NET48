namespace Vulkan;

public struct VkImportFenceFdInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkFence fence;

	public VkFenceImportFlagsKHR flags;

	public VkExternalFenceHandleTypeFlagsKHR handleType;

	public int fd;

	public static VkImportFenceFdInfoKHR New()
	{
		VkImportFenceFdInfoKHR result = default(VkImportFenceFdInfoKHR);
		result.sType = VkStructureType.ImportFenceFdInfoKHR;
		return result;
	}
}
