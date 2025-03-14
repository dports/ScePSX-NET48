namespace Vulkan;

public struct VkPipelineDynamicStateCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint dynamicStateCount;

	public unsafe VkDynamicState* pDynamicStates;

	public static VkPipelineDynamicStateCreateInfo New()
	{
		VkPipelineDynamicStateCreateInfo result = default(VkPipelineDynamicStateCreateInfo);
		result.sType = VkStructureType.PipelineDynamicStateCreateInfo;
		return result;
	}
}
