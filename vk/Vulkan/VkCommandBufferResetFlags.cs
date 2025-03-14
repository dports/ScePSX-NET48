using System;

namespace Vulkan;

[Flags]
public enum VkCommandBufferResetFlags
{
	None = 0,
	ReleaseResources = 1
}
