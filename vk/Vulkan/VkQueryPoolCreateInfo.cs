namespace Vulkan;

public struct VkQueryPoolCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkQueryType queryType;

	public uint queryCount;

	public VkQueryPipelineStatisticFlags pipelineStatistics;

	public static VkQueryPoolCreateInfo New()
	{
		VkQueryPoolCreateInfo result = default(VkQueryPoolCreateInfo);
		result.sType = VkStructureType.QueryPoolCreateInfo;
		return result;
	}
}
