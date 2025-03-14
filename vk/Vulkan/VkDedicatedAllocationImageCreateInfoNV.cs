namespace Vulkan;

public struct VkDedicatedAllocationImageCreateInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 dedicatedAllocation;

	public static VkDedicatedAllocationImageCreateInfoNV New()
	{
		VkDedicatedAllocationImageCreateInfoNV result = default(VkDedicatedAllocationImageCreateInfoNV);
		result.sType = VkStructureType.DedicatedAllocationImageCreateInfoNV;
		return result;
	}
}
