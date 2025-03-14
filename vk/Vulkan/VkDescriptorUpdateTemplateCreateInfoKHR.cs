namespace Vulkan;

public struct VkDescriptorUpdateTemplateCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint descriptorUpdateEntryCount;

	public unsafe VkDescriptorUpdateTemplateEntryKHR* pDescriptorUpdateEntries;

	public VkDescriptorUpdateTemplateTypeKHR templateType;

	public VkDescriptorSetLayout descriptorSetLayout;

	public VkPipelineBindPoint pipelineBindPoint;

	public VkPipelineLayout pipelineLayout;

	public uint set;

	public static VkDescriptorUpdateTemplateCreateInfoKHR New()
	{
		VkDescriptorUpdateTemplateCreateInfoKHR result = default(VkDescriptorUpdateTemplateCreateInfoKHR);
		result.sType = VkStructureType.DescriptorUpdateTemplateCreateInfoKHR;
		return result;
	}
}
