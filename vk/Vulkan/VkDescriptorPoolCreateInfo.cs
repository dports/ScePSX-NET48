namespace Vulkan;

public struct VkDescriptorPoolCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDescriptorPoolCreateFlags flags;

	public uint maxSets;

	public uint poolSizeCount;

	public unsafe VkDescriptorPoolSize* pPoolSizes;

	public static VkDescriptorPoolCreateInfo New()
	{
		VkDescriptorPoolCreateInfo result = default(VkDescriptorPoolCreateInfo);
		result.sType = VkStructureType.DescriptorPoolCreateInfo;
		return result;
	}
}
