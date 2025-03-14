namespace Vulkan;

public struct VkDeviceGroupSubmitInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint waitSemaphoreCount;

	public unsafe uint* pWaitSemaphoreDeviceIndices;

	public uint commandBufferCount;

	public unsafe uint* pCommandBufferDeviceMasks;

	public uint signalSemaphoreCount;

	public unsafe uint* pSignalSemaphoreDeviceIndices;

	public static VkDeviceGroupSubmitInfoKHX New()
	{
		VkDeviceGroupSubmitInfoKHX result = default(VkDeviceGroupSubmitInfoKHX);
		result.sType = VkStructureType.DeviceGroupSubmitInfoKHX;
		return result;
	}
}
