namespace Vulkan;

public struct VkBufferMemoryRequirementsInfo2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBuffer buffer;

	public static VkBufferMemoryRequirementsInfo2KHR New()
	{
		VkBufferMemoryRequirementsInfo2KHR result = default(VkBufferMemoryRequirementsInfo2KHR);
		result.sType = VkStructureType.BufferMemoryRequirementsInfo2KHR;
		return result;
	}
}
