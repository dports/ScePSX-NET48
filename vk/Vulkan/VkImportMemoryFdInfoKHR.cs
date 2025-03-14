namespace Vulkan;

public struct VkImportMemoryFdInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsKHR handleType;

	public int fd;

	public static VkImportMemoryFdInfoKHR New()
	{
		VkImportMemoryFdInfoKHR result = default(VkImportMemoryFdInfoKHR);
		result.sType = VkStructureType.ImportMemoryFdInfoKHR;
		return result;
	}
}
