namespace Vulkan;

public struct VkPipelineRasterizationStateCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkBool32 depthClampEnable;

	public VkBool32 rasterizerDiscardEnable;

	public VkPolygonMode polygonMode;

	public VkCullModeFlags cullMode;

	public VkFrontFace frontFace;

	public VkBool32 depthBiasEnable;

	public float depthBiasConstantFactor;

	public float depthBiasClamp;

	public float depthBiasSlopeFactor;

	public float lineWidth;

	public static VkPipelineRasterizationStateCreateInfo New()
	{
		VkPipelineRasterizationStateCreateInfo result = default(VkPipelineRasterizationStateCreateInfo);
		result.sType = VkStructureType.PipelineRasterizationStateCreateInfo;
		return result;
	}
}
