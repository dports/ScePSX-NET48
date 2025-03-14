namespace Vulkan;

public struct VkPipelineLayoutCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint setLayoutCount;

	public unsafe VkDescriptorSetLayout* pSetLayouts;

	public uint pushConstantRangeCount;

	public unsafe VkPushConstantRange* pPushConstantRanges;

	public static VkPipelineLayoutCreateInfo New()
	{
		VkPipelineLayoutCreateInfo result = default(VkPipelineLayoutCreateInfo);
		result.sType = VkStructureType.PipelineLayoutCreateInfo;
		return result;
	}
}
