namespace Vulkan;

public struct VkSparseImageMemoryRequirements2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSparseImageMemoryRequirements memoryRequirements;

	public static VkSparseImageMemoryRequirements2KHR New()
	{
		VkSparseImageMemoryRequirements2KHR result = default(VkSparseImageMemoryRequirements2KHR);
		result.sType = VkStructureType.SparseImageMemoryRequirements2KHR;
		return result;
	}
}
