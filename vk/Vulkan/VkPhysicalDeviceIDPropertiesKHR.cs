namespace Vulkan;

public struct VkPhysicalDeviceIDPropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public unsafe fixed byte deviceUUID[16];

	public unsafe fixed byte driverUUID[16];

	public unsafe fixed byte deviceLUID[8];

	public uint deviceNodeMask;

	public VkBool32 deviceLUIDValid;

	public static VkPhysicalDeviceIDPropertiesKHR New()
	{
		VkPhysicalDeviceIDPropertiesKHR result = default(VkPhysicalDeviceIDPropertiesKHR);
		result.sType = VkStructureType.PhysicalDeviceIdPropertiesKHR;
		return result;
	}
}
