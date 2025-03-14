namespace Vulkan;

public struct VkPipelineViewportStateCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint viewportCount;

	public unsafe VkViewport* pViewports;

	public uint scissorCount;

	public unsafe VkRect2D* pScissors;

	public static VkPipelineViewportStateCreateInfo New()
	{
		VkPipelineViewportStateCreateInfo result = default(VkPipelineViewportStateCreateInfo);
		result.sType = VkStructureType.PipelineViewportStateCreateInfo;
		return result;
	}
}
