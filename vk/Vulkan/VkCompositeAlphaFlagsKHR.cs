using System;

namespace Vulkan;

[Flags]
public enum VkCompositeAlphaFlagsKHR
{
	None = 0,
	OpaqueKHR = 1,
	PreMultipliedKHR = 2,
	PostMultipliedKHR = 4,
	InheritKHR = 8
}
