namespace Vulkan;

public struct VkGraphicsPipelineCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkPipelineCreateFlags flags;

	public uint stageCount;

	public unsafe VkPipelineShaderStageCreateInfo* pStages;

	public unsafe VkPipelineVertexInputStateCreateInfo* pVertexInputState;

	public unsafe VkPipelineInputAssemblyStateCreateInfo* pInputAssemblyState;

	public unsafe VkPipelineTessellationStateCreateInfo* pTessellationState;

	public unsafe VkPipelineViewportStateCreateInfo* pViewportState;

	public unsafe VkPipelineRasterizationStateCreateInfo* pRasterizationState;

	public unsafe VkPipelineMultisampleStateCreateInfo* pMultisampleState;

	public unsafe VkPipelineDepthStencilStateCreateInfo* pDepthStencilState;

	public unsafe VkPipelineColorBlendStateCreateInfo* pColorBlendState;

	public unsafe VkPipelineDynamicStateCreateInfo* pDynamicState;

	public VkPipelineLayout layout;

	public VkRenderPass renderPass;

	public uint subpass;

	public VkPipeline basePipelineHandle;

	public int basePipelineIndex;

	public static VkGraphicsPipelineCreateInfo New()
	{
		VkGraphicsPipelineCreateInfo result = default(VkGraphicsPipelineCreateInfo);
		result.sType = VkStructureType.GraphicsPipelineCreateInfo;
		return result;
	}
}
