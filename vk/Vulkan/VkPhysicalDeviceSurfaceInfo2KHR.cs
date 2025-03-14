namespace Vulkan;

public struct VkPhysicalDeviceSurfaceInfo2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSurfaceKHR surface;

	public static VkPhysicalDeviceSurfaceInfo2KHR New()
	{
		VkPhysicalDeviceSurfaceInfo2KHR result = default(VkPhysicalDeviceSurfaceInfo2KHR);
		result.sType = VkStructureType.PhysicalDeviceSurfaceInfo2KHR;
		return result;
	}
}
