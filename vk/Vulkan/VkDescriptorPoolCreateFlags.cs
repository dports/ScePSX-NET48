using System;

namespace Vulkan;

[Flags]
public enum VkDescriptorPoolCreateFlags
{
	None = 0,
	FreeDescriptorSet = 1
}
