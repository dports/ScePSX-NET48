namespace Vulkan;

public struct VkPipelineInputAssemblyStateCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkPrimitiveTopology topology;

	public VkBool32 primitiveRestartEnable;

	public static VkPipelineInputAssemblyStateCreateInfo New()
	{
		VkPipelineInputAssemblyStateCreateInfo result = default(VkPipelineInputAssemblyStateCreateInfo);
		result.sType = VkStructureType.PipelineInputAssemblyStateCreateInfo;
		return result;
	}
}
