namespace Vulkan;

public struct VkCommandBufferBeginInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkCommandBufferUsageFlags flags;

	public unsafe VkCommandBufferInheritanceInfo* pInheritanceInfo;

	public static VkCommandBufferBeginInfo New()
	{
		VkCommandBufferBeginInfo result = default(VkCommandBufferBeginInfo);
		result.sType = VkStructureType.CommandBufferBeginInfo;
		return result;
	}
}
