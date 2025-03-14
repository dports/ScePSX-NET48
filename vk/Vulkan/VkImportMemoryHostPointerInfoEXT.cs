namespace Vulkan;

public struct VkImportMemoryHostPointerInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsKHR handleType;

	public unsafe void* pHostPointer;

	public static VkImportMemoryHostPointerInfoEXT New()
	{
		VkImportMemoryHostPointerInfoEXT result = default(VkImportMemoryHostPointerInfoEXT);
		result.sType = VkStructureType.ImportMemoryHostPointerInfoEXT;
		return result;
	}
}
