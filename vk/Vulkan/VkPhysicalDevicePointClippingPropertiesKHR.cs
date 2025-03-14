namespace Vulkan;

public struct VkPhysicalDevicePointClippingPropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkPointClippingBehaviorKHR pointClippingBehavior;

	public static VkPhysicalDevicePointClippingPropertiesKHR New()
	{
		VkPhysicalDevicePointClippingPropertiesKHR result = default(VkPhysicalDevicePointClippingPropertiesKHR);
		result.sType = VkStructureType.PhysicalDevicePointClippingPropertiesKHR;
		return result;
	}
}
