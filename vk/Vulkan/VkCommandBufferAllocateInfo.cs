namespace Vulkan;

public struct VkCommandBufferAllocateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkCommandPool commandPool;

	public VkCommandBufferLevel level;

	public uint commandBufferCount;

	public static VkCommandBufferAllocateInfo New()
	{
		VkCommandBufferAllocateInfo result = default(VkCommandBufferAllocateInfo);
		result.sType = VkStructureType.CommandBufferAllocateInfo;
		return result;
	}
}
