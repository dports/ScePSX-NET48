namespace Vulkan;

public struct VkBindBufferMemoryInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBuffer buffer;

	public VkDeviceMemory memory;

	public ulong memoryOffset;

	public static VkBindBufferMemoryInfoKHR New()
	{
		VkBindBufferMemoryInfoKHR result = default(VkBindBufferMemoryInfoKHR);
		result.sType = VkStructureType.BindBufferMemoryInfoKHR;
		return result;
	}
}
