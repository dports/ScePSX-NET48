namespace Vulkan;

public struct VkWriteDescriptorSet
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDescriptorSet dstSet;

	public uint dstBinding;

	public uint dstArrayElement;

	public uint descriptorCount;

	public VkDescriptorType descriptorType;

	public unsafe VkDescriptorImageInfo* pImageInfo;

	public unsafe VkDescriptorBufferInfo* pBufferInfo;

	public unsafe VkBufferView* pTexelBufferView;

	public static VkWriteDescriptorSet New()
	{
		VkWriteDescriptorSet result = default(VkWriteDescriptorSet);
		result.sType = VkStructureType.WriteDescriptorSet;
		return result;
	}
}
