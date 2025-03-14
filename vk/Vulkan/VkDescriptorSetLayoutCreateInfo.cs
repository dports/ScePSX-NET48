namespace Vulkan;

public struct VkDescriptorSetLayoutCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDescriptorSetLayoutCreateFlags flags;

	public uint bindingCount;

	public unsafe VkDescriptorSetLayoutBinding* pBindings;

	public static VkDescriptorSetLayoutCreateInfo New()
	{
		VkDescriptorSetLayoutCreateInfo result = default(VkDescriptorSetLayoutCreateInfo);
		result.sType = VkStructureType.DescriptorSetLayoutCreateInfo;
		return result;
	}
}
