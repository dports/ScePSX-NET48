namespace Vulkan;

public struct VkDeviceGroupSwapchainCreateInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDeviceGroupPresentModeFlagsKHX modes;

	public static VkDeviceGroupSwapchainCreateInfoKHX New()
	{
		VkDeviceGroupSwapchainCreateInfoKHX result = default(VkDeviceGroupSwapchainCreateInfoKHX);
		result.sType = VkStructureType.DeviceGroupSwapchainCreateInfoKHX;
		return result;
	}
}
