namespace Vulkan;

public struct VkRenderPassMultiviewCreateInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint subpassCount;

	public unsafe uint* pViewMasks;

	public uint dependencyCount;

	public unsafe int* pViewOffsets;

	public uint correlationMaskCount;

	public unsafe uint* pCorrelationMasks;

	public static VkRenderPassMultiviewCreateInfoKHX New()
	{
		VkRenderPassMultiviewCreateInfoKHX result = default(VkRenderPassMultiviewCreateInfoKHX);
		result.sType = VkStructureType.RenderPassMultiviewCreateInfoKHX;
		return result;
	}
}
