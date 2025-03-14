namespace Vulkan;

public struct VkPipelineDiscardRectangleStateCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkDiscardRectangleModeEXT discardRectangleMode;

	public uint discardRectangleCount;

	public unsafe VkRect2D* pDiscardRectangles;

	public static VkPipelineDiscardRectangleStateCreateInfoEXT New()
	{
		VkPipelineDiscardRectangleStateCreateInfoEXT result = default(VkPipelineDiscardRectangleStateCreateInfoEXT);
		result.sType = VkStructureType.PipelineDiscardRectangleStateCreateInfoEXT;
		return result;
	}
}
