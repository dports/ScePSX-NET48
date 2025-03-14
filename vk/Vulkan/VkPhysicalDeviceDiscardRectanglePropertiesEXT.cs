namespace Vulkan;

public struct VkPhysicalDeviceDiscardRectanglePropertiesEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint maxDiscardRectangles;

	public static VkPhysicalDeviceDiscardRectanglePropertiesEXT New()
	{
		VkPhysicalDeviceDiscardRectanglePropertiesEXT result = default(VkPhysicalDeviceDiscardRectanglePropertiesEXT);
		result.sType = VkStructureType.PhysicalDeviceDiscardRectanglePropertiesEXT;
		return result;
	}
}
