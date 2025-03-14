namespace Vulkan;

public struct VkSharedPresentSurfaceCapabilitiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImageUsageFlags sharedPresentSupportedUsageFlags;

	public static VkSharedPresentSurfaceCapabilitiesKHR New()
	{
		VkSharedPresentSurfaceCapabilitiesKHR result = default(VkSharedPresentSurfaceCapabilitiesKHR);
		result.sType = VkStructureType.SharedPresentSurfaceCapabilitiesKHR;
		return result;
	}
}
