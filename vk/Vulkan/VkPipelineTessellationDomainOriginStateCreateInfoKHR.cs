namespace Vulkan;

public struct VkPipelineTessellationDomainOriginStateCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkTessellationDomainOriginKHR domainOrigin;

	public static VkPipelineTessellationDomainOriginStateCreateInfoKHR New()
	{
		VkPipelineTessellationDomainOriginStateCreateInfoKHR result = default(VkPipelineTessellationDomainOriginStateCreateInfoKHR);
		result.sType = VkStructureType.PipelineTessellationDomainOriginStateCreateInfoKHR;
		return result;
	}
}
