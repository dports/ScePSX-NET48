namespace Vulkan;

public struct VkPresentRegionsKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint swapchainCount;

	public unsafe VkPresentRegionKHR* pRegions;

	public static VkPresentRegionsKHR New()
	{
		VkPresentRegionsKHR result = default(VkPresentRegionsKHR);
		result.sType = VkStructureType.PresentRegionsKHR;
		return result;
	}
}
