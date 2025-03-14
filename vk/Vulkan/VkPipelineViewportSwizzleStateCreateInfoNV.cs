namespace Vulkan;

public struct VkPipelineViewportSwizzleStateCreateInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint viewportCount;

	public unsafe VkViewportSwizzleNV* pViewportSwizzles;

	public static VkPipelineViewportSwizzleStateCreateInfoNV New()
	{
		VkPipelineViewportSwizzleStateCreateInfoNV result = default(VkPipelineViewportSwizzleStateCreateInfoNV);
		result.sType = VkStructureType.PipelineViewportSwizzleStateCreateInfoNV;
		return result;
	}
}
