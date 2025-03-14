namespace Vulkan;

public struct VkDescriptorSetAllocateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDescriptorPool descriptorPool;

	public uint descriptorSetCount;

	public unsafe VkDescriptorSetLayout* pSetLayouts;

	public static VkDescriptorSetAllocateInfo New()
	{
		VkDescriptorSetAllocateInfo result = default(VkDescriptorSetAllocateInfo);
		result.sType = VkStructureType.DescriptorSetAllocateInfo;
		return result;
	}
}
