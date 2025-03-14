namespace Vulkan;

public struct VkDeviceGeneratedCommandsLimitsNVX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint maxIndirectCommandsLayoutTokenCount;

	public uint maxObjectEntryCounts;

	public uint minSequenceCountBufferOffsetAlignment;

	public uint minSequenceIndexBufferOffsetAlignment;

	public uint minCommandsTokenBufferOffsetAlignment;

	public static VkDeviceGeneratedCommandsLimitsNVX New()
	{
		VkDeviceGeneratedCommandsLimitsNVX result = default(VkDeviceGeneratedCommandsLimitsNVX);
		result.sType = VkStructureType.DeviceGeneratedCommandsLimitsNVX;
		return result;
	}
}
