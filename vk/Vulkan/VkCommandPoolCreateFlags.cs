using System;

namespace Vulkan;

[Flags]
public enum VkCommandPoolCreateFlags
{
	None = 0,
	Transient = 1,
	ResetCommandBuffer = 2
}
