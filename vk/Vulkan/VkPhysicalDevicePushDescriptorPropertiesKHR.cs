namespace Vulkan;

public struct VkPhysicalDevicePushDescriptorPropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint maxPushDescriptors;

	public static VkPhysicalDevicePushDescriptorPropertiesKHR New()
	{
		VkPhysicalDevicePushDescriptorPropertiesKHR result = default(VkPhysicalDevicePushDescriptorPropertiesKHR);
		result.sType = VkStructureType.PhysicalDevicePushDescriptorPropertiesKHR;
		return result;
	}
}
