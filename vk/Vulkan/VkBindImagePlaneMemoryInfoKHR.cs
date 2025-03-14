namespace Vulkan;

public struct VkBindImagePlaneMemoryInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImageAspectFlags planeAspect;

	public static VkBindImagePlaneMemoryInfoKHR New()
	{
		VkBindImagePlaneMemoryInfoKHR result = default(VkBindImagePlaneMemoryInfoKHR);
		result.sType = VkStructureType.BindImagePlaneMemoryInfoKHR;
		return result;
	}
}
