namespace Vulkan;

public struct VkSurfaceCapabilities2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSurfaceCapabilitiesKHR surfaceCapabilities;

	public static VkSurfaceCapabilities2KHR New()
	{
		VkSurfaceCapabilities2KHR result = default(VkSurfaceCapabilities2KHR);
		result.sType = VkStructureType.SurfaceCapabilities2KHR;
		return result;
	}
}
