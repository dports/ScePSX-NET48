namespace Vulkan;

public struct VkMemoryDedicatedRequirementsKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 prefersDedicatedAllocation;

	public VkBool32 requiresDedicatedAllocation;

	public static VkMemoryDedicatedRequirementsKHR New()
	{
		VkMemoryDedicatedRequirementsKHR result = default(VkMemoryDedicatedRequirementsKHR);
		result.sType = VkStructureType.MemoryDedicatedRequirementsKHR;
		return result;
	}
}
