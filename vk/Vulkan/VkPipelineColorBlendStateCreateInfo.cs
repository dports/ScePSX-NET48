namespace Vulkan;

public struct VkPipelineColorBlendStateCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkBool32 logicOpEnable;

	public VkLogicOp logicOp;

	public uint attachmentCount;

	public unsafe VkPipelineColorBlendAttachmentState* pAttachments;

	public float blendConstants_0;

	public float blendConstants_1;

	public float blendConstants_2;

	public float blendConstants_3;

	public static VkPipelineColorBlendStateCreateInfo New()
	{
		VkPipelineColorBlendStateCreateInfo result = default(VkPipelineColorBlendStateCreateInfo);
		result.sType = VkStructureType.PipelineColorBlendStateCreateInfo;
		return result;
	}
}
