namespace Vulkan;

public struct VkMemoryGetWin32HandleInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDeviceMemory memory;

	public VkExternalMemoryHandleTypeFlagsKHR handleType;

	public static VkMemoryGetWin32HandleInfoKHR New()
	{
		VkMemoryGetWin32HandleInfoKHR result = default(VkMemoryGetWin32HandleInfoKHR);
		result.sType = VkStructureType.MemoryGetWin32HandleInfoKHR;
		return result;
	}
}
