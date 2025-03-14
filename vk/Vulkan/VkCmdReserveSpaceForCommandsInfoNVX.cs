namespace Vulkan;

public struct VkCmdReserveSpaceForCommandsInfoNVX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkObjectTableNVX objectTable;

	public VkIndirectCommandsLayoutNVX indirectCommandsLayout;

	public uint maxSequencesCount;

	public static VkCmdReserveSpaceForCommandsInfoNVX New()
	{
		VkCmdReserveSpaceForCommandsInfoNVX result = default(VkCmdReserveSpaceForCommandsInfoNVX);
		result.sType = VkStructureType.CmdReserveSpaceForCommandsInfoNVX;
		return result;
	}
}
