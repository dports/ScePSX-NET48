namespace Vulkan;

public struct VkPhysicalDeviceExternalMemoryHostPropertiesEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public ulong minImportedHostPointerAlignment;

	public static VkPhysicalDeviceExternalMemoryHostPropertiesEXT New()
	{
		VkPhysicalDeviceExternalMemoryHostPropertiesEXT result = default(VkPhysicalDeviceExternalMemoryHostPropertiesEXT);
		result.sType = VkStructureType.PhysicalDeviceExternalMemoryHostPropertiesEXT;
		return result;
	}
}
