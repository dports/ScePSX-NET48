using System;

namespace Vulkan;

[Flags]
public enum VkCommandPoolResetFlags
{
	None = 0,
	ReleaseResources = 1
}
