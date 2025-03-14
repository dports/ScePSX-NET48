namespace Vulkan;

public struct VkShaderStatisticsInfoAMD
{
	public VkShaderStageFlags shaderStageMask;

	public VkShaderResourceUsageAMD resourceUsage;

	public uint numPhysicalVgprs;

	public uint numPhysicalSgprs;

	public uint numAvailableVgprs;

	public uint numAvailableSgprs;

	public uint computeWorkGroupSize_0;

	public uint computeWorkGroupSize_1;

	public uint computeWorkGroupSize_2;
}
