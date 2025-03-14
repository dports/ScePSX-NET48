namespace Vulkan;

public struct VkDeviceGroupCommandBufferBeginInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint deviceMask;

	public static VkDeviceGroupCommandBufferBeginInfoKHX New()
	{
		VkDeviceGroupCommandBufferBeginInfoKHX result = default(VkDeviceGroupCommandBufferBeginInfoKHX);
		result.sType = VkStructureType.DeviceGroupCommandBufferBeginInfoKHX;
		return result;
	}
}
