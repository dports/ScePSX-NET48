using System;

namespace Vulkan;

[Flags]
public enum VkExternalSemaphoreFeatureFlagsKHR
{
	None = 0,
	ExportableKHR = 1,
	ImportableKHR = 2
}
