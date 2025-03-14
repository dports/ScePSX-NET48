namespace Vulkan;

public struct VkMemoryGetFdInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDeviceMemory memory;

	public VkExternalMemoryHandleTypeFlagsKHR handleType;

	public static VkMemoryGetFdInfoKHR New()
	{
		VkMemoryGetFdInfoKHR result = default(VkMemoryGetFdInfoKHR);
		result.sType = VkStructureType.MemoryGetFdInfoKHR;
		return result;
	}
}
