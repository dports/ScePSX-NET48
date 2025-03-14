namespace Vulkan;

public struct VkIndirectCommandsLayoutCreateInfoNVX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkPipelineBindPoint pipelineBindPoint;

	public VkIndirectCommandsLayoutUsageFlagsNVX flags;

	public uint tokenCount;

	public unsafe VkIndirectCommandsLayoutTokenNVX* pTokens;

	public static VkIndirectCommandsLayoutCreateInfoNVX New()
	{
		VkIndirectCommandsLayoutCreateInfoNVX result = default(VkIndirectCommandsLayoutCreateInfoNVX);
		result.sType = VkStructureType.IndirectCommandsLayoutCreateInfoNVX;
		return result;
	}
}
