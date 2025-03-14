namespace Vulkan;

public struct VkBindImageMemoryInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImage image;

	public VkDeviceMemory memory;

	public ulong memoryOffset;

	public static VkBindImageMemoryInfoKHR New()
	{
		VkBindImageMemoryInfoKHR result = default(VkBindImageMemoryInfoKHR);
		result.sType = VkStructureType.BindImageMemoryInfoKHR;
		return result;
	}
}
