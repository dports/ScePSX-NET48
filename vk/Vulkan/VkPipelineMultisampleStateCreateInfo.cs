namespace Vulkan;

public struct VkPipelineMultisampleStateCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkSampleCountFlags rasterizationSamples;

	public VkBool32 sampleShadingEnable;

	public float minSampleShading;

	public unsafe uint* pSampleMask;

	public VkBool32 alphaToCoverageEnable;

	public VkBool32 alphaToOneEnable;

	public static VkPipelineMultisampleStateCreateInfo New()
	{
		VkPipelineMultisampleStateCreateInfo result = default(VkPipelineMultisampleStateCreateInfo);
		result.sType = VkStructureType.PipelineMultisampleStateCreateInfo;
		return result;
	}
}
