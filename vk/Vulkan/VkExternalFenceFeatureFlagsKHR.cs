using System;

namespace Vulkan;

[Flags]
public enum VkExternalFenceFeatureFlagsKHR
{
	None = 0,
	ExportableKHR = 1,
	ImportableKHR = 2
}
