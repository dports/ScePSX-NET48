using System;

namespace Vulkan;

[Flags]
public enum VkExternalMemoryFeatureFlagsKHR
{
	None = 0,
	DedicatedOnlyKHR = 1,
	ExportableKHR = 2,
	ImportableKHR = 4
}
