namespace Vulkan;

public struct VkPresentRegionKHR
{
	public uint rectangleCount;

	public unsafe VkRectLayerKHR* pRectangles;
}
