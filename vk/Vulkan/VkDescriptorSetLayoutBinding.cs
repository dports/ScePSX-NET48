namespace Vulkan;

public struct VkDescriptorSetLayoutBinding
{
	public uint binding;

	public VkDescriptorType descriptorType;

	public uint descriptorCount;

	public VkShaderStageFlags stageFlags;

	public unsafe VkSampler* pImmutableSamplers;
}
