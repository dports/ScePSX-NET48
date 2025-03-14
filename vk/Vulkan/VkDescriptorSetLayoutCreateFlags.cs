using System;

namespace Vulkan;

[Flags]
public enum VkDescriptorSetLayoutCreateFlags
{
	None = 0,
	PushDescriptorKHR = 1
}
