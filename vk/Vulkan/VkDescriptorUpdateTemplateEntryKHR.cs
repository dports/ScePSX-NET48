using System;

namespace Vulkan;

public struct VkDescriptorUpdateTemplateEntryKHR
{
	public uint dstBinding;

	public uint dstArrayElement;

	public uint descriptorCount;

	public VkDescriptorType descriptorType;

	public UIntPtr offset;

	public UIntPtr stride;
}
