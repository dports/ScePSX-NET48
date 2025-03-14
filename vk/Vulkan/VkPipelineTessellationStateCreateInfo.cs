namespace Vulkan;

public struct VkPipelineTessellationStateCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint patchControlPoints;

	public static VkPipelineTessellationStateCreateInfo New()
	{
		VkPipelineTessellationStateCreateInfo result = default(VkPipelineTessellationStateCreateInfo);
		result.sType = VkStructureType.PipelineTessellationStateCreateInfo;
		return result;
	}
}
