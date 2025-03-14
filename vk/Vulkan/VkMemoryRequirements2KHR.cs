namespace Vulkan;

public struct VkMemoryRequirements2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkMemoryRequirements memoryRequirements;

	public static VkMemoryRequirements2KHR New()
	{
		VkMemoryRequirements2KHR result = default(VkMemoryRequirements2KHR);
		result.sType = VkStructureType.MemoryRequirements2KHR;
		return result;
	}
}
