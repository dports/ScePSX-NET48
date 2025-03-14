namespace Vulkan;

public struct VkPresentTimesInfoGOOGLE
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint swapchainCount;

	public unsafe VkPresentTimeGOOGLE* pTimes;

	public static VkPresentTimesInfoGOOGLE New()
	{
		VkPresentTimesInfoGOOGLE result = default(VkPresentTimesInfoGOOGLE);
		result.sType = VkStructureType.PresentTimesInfoGoogle;
		return result;
	}
}
