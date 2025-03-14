namespace Vulkan;

public struct VkPhysicalDeviceMultiviewPerViewAttributesPropertiesNVX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 perViewPositionAllComponents;

	public static VkPhysicalDeviceMultiviewPerViewAttributesPropertiesNVX New()
	{
		VkPhysicalDeviceMultiviewPerViewAttributesPropertiesNVX result = default(VkPhysicalDeviceMultiviewPerViewAttributesPropertiesNVX);
		result.sType = VkStructureType.PhysicalDeviceMultiviewPerViewAttributesPropertiesNVX;
		return result;
	}
}
