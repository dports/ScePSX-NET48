namespace Vulkan;

public struct VkCopyDescriptorSet
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDescriptorSet srcSet;

	public uint srcBinding;

	public uint srcArrayElement;

	public VkDescriptorSet dstSet;

	public uint dstBinding;

	public uint dstArrayElement;

	public uint descriptorCount;

	public static VkCopyDescriptorSet New()
	{
		VkCopyDescriptorSet result = default(VkCopyDescriptorSet);
		result.sType = VkStructureType.CopyDescriptorSet;
		return result;
	}
}
