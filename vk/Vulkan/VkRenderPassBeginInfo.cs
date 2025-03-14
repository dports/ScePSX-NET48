namespace Vulkan;

public struct VkRenderPassBeginInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkRenderPass renderPass;

	public VkFramebuffer framebuffer;

	public VkRect2D renderArea;

	public uint clearValueCount;

	public unsafe VkClearValue* pClearValues;

	public static VkRenderPassBeginInfo New()
	{
		VkRenderPassBeginInfo result = default(VkRenderPassBeginInfo);
		result.sType = VkStructureType.RenderPassBeginInfo;
		return result;
	}
}
