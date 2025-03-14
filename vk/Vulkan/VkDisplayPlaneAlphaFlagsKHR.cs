using System;

namespace Vulkan;

[Flags]
public enum VkDisplayPlaneAlphaFlagsKHR
{
	None = 0,
	OpaqueKHR = 1,
	GlobalKHR = 2,
	PerPixelKHR = 4,
	PerPixelPremultipliedKHR = 8
}
