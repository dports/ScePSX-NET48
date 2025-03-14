namespace Vulkan;

public struct VkPipelineShaderStageCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkShaderStageFlags stage;

	public VkShaderModule module;

	public unsafe byte* pName;

	public unsafe VkSpecializationInfo* pSpecializationInfo;

	public static VkPipelineShaderStageCreateInfo New()
	{
		VkPipelineShaderStageCreateInfo result = default(VkPipelineShaderStageCreateInfo);
		result.sType = VkStructureType.PipelineShaderStageCreateInfo;
		return result;
	}
}
