namespace Vulkan;

public struct VkDeviceGroupPresentCapabilitiesKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public unsafe fixed uint presentMask[32];

	public VkDeviceGroupPresentModeFlagsKHX modes;

	public static VkDeviceGroupPresentCapabilitiesKHX New()
	{
		VkDeviceGroupPresentCapabilitiesKHX result = default(VkDeviceGroupPresentCapabilitiesKHX);
		result.sType = VkStructureType.DeviceGroupPresentCapabilitiesKHX;
		return result;
	}
}
