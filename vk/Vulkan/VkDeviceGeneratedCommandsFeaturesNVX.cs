namespace Vulkan;

public struct VkDeviceGeneratedCommandsFeaturesNVX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 computeBindingPointSupport;

	public static VkDeviceGeneratedCommandsFeaturesNVX New()
	{
		VkDeviceGeneratedCommandsFeaturesNVX result = default(VkDeviceGeneratedCommandsFeaturesNVX);
		result.sType = VkStructureType.DeviceGeneratedCommandsFeaturesNVX;
		return result;
	}
}
