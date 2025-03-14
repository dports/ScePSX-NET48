namespace Vulkan;

public struct VkPhysicalDeviceMultiviewPropertiesKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint maxMultiviewViewCount;

	public uint maxMultiviewInstanceIndex;

	public static VkPhysicalDeviceMultiviewPropertiesKHX New()
	{
		VkPhysicalDeviceMultiviewPropertiesKHX result = default(VkPhysicalDeviceMultiviewPropertiesKHX);
		result.sType = VkStructureType.PhysicalDeviceMultiviewPropertiesKHX;
		return result;
	}
}
