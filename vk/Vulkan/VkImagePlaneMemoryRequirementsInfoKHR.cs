namespace Vulkan;

public struct VkImagePlaneMemoryRequirementsInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImageAspectFlags planeAspect;

	public static VkImagePlaneMemoryRequirementsInfoKHR New()
	{
		VkImagePlaneMemoryRequirementsInfoKHR result = default(VkImagePlaneMemoryRequirementsInfoKHR);
		result.sType = VkStructureType.ImagePlaneMemoryRequirementsInfoKHR;
		return result;
	}
}
