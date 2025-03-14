using System;

namespace Vulkan;

[Flags]
public enum VkCommandBufferUsageFlags
{
	None = 0,
	OneTimeSubmit = 1,
	RenderPassContinue = 2,
	SimultaneousUse = 4
}
