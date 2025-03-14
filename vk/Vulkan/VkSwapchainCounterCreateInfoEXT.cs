namespace Vulkan;

public struct VkSwapchainCounterCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSurfaceCounterFlagsEXT surfaceCounters;

	public static VkSwapchainCounterCreateInfoEXT New()
	{
		VkSwapchainCounterCreateInfoEXT result = default(VkSwapchainCounterCreateInfoEXT);
		result.sType = VkStructureType.SwapchainCounterCreateInfoEXT;
		return result;
	}
}
