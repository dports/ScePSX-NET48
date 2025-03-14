namespace Vulkan;

public struct VkSurfaceFormat2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSurfaceFormatKHR surfaceFormat;

	public static VkSurfaceFormat2KHR New()
	{
		VkSurfaceFormat2KHR result = default(VkSurfaceFormat2KHR);
		result.sType = VkStructureType.SurfaceFormat2KHR;
		return result;
	}
}
