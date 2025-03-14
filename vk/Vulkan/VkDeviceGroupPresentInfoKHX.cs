namespace Vulkan;

public struct VkDeviceGroupPresentInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint swapchainCount;

	public unsafe uint* pDeviceMasks;

	public VkDeviceGroupPresentModeFlagsKHX mode;

	public static VkDeviceGroupPresentInfoKHX New()
	{
		VkDeviceGroupPresentInfoKHX result = default(VkDeviceGroupPresentInfoKHX);
		result.sType = VkStructureType.DeviceGroupPresentInfoKHX;
		return result;
	}
}
