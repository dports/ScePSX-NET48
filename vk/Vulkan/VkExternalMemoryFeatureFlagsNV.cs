using System;

namespace Vulkan;

[Flags]
public enum VkExternalMemoryFeatureFlagsNV
{
	None = 0,
	DedicatedOnlyNV = 1,
	ExportableNV = 2,
	ImportableNV = 4
}
