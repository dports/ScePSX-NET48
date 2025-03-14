namespace Vulkan;

public struct VkDedicatedAllocationBufferCreateInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 dedicatedAllocation;

	public static VkDedicatedAllocationBufferCreateInfoNV New()
	{
		VkDedicatedAllocationBufferCreateInfoNV result = default(VkDedicatedAllocationBufferCreateInfoNV);
		result.sType = VkStructureType.DedicatedAllocationBufferCreateInfoNV;
		return result;
	}
}
