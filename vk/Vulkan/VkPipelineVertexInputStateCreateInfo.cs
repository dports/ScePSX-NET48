namespace Vulkan;

public struct VkPipelineVertexInputStateCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint vertexBindingDescriptionCount;

	public unsafe VkVertexInputBindingDescription* pVertexBindingDescriptions;

	public uint vertexAttributeDescriptionCount;

	public unsafe VkVertexInputAttributeDescription* pVertexAttributeDescriptions;

	public static VkPipelineVertexInputStateCreateInfo New()
	{
		VkPipelineVertexInputStateCreateInfo result = default(VkPipelineVertexInputStateCreateInfo);
		result.sType = VkStructureType.PipelineVertexInputStateCreateInfo;
		return result;
	}
}
