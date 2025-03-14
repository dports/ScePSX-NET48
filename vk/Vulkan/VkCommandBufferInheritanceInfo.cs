namespace Vulkan;

public struct VkCommandBufferInheritanceInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkRenderPass renderPass;

	public uint subpass;

	public VkFramebuffer framebuffer;

	public VkBool32 occlusionQueryEnable;

	public VkQueryControlFlags queryFlags;

	public VkQueryPipelineStatisticFlags pipelineStatistics;

	public static VkCommandBufferInheritanceInfo New()
	{
		VkCommandBufferInheritanceInfo result = default(VkCommandBufferInheritanceInfo);
		result.sType = VkStructureType.CommandBufferInheritanceInfo;
		return result;
	}
}
