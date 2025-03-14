namespace Vulkan;

public struct VkPushConstantRange
{
	public VkShaderStageFlags stageFlags;

	public uint offset;

	public uint size;
}
