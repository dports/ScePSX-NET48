namespace Vulkan;

public struct VkCmdProcessCommandsInfoNVX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkObjectTableNVX objectTable;

	public VkIndirectCommandsLayoutNVX indirectCommandsLayout;

	public uint indirectCommandsTokenCount;

	public unsafe VkIndirectCommandsTokenNVX* pIndirectCommandsTokens;

	public uint maxSequencesCount;

	public VkCommandBuffer targetCommandBuffer;

	public VkBuffer sequencesCountBuffer;

	public ulong sequencesCountOffset;

	public VkBuffer sequencesIndexBuffer;

	public ulong sequencesIndexOffset;

	public static VkCmdProcessCommandsInfoNVX New()
	{
		VkCmdProcessCommandsInfoNVX result = default(VkCmdProcessCommandsInfoNVX);
		result.sType = VkStructureType.CmdProcessCommandsInfoNVX;
		return result;
	}
}
