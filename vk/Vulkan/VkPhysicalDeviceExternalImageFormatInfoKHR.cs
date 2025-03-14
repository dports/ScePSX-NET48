namespace Vulkan;

public struct VkPhysicalDeviceExternalImageFormatInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsKHR handleType;

	public static VkPhysicalDeviceExternalImageFormatInfoKHR New()
	{
		VkPhysicalDeviceExternalImageFormatInfoKHR result = default(VkPhysicalDeviceExternalImageFormatInfoKHR);
		result.sType = VkStructureType.PhysicalDeviceExternalImageFormatInfoKHR;
		return result;
	}
}
