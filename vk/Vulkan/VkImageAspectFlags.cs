using System;

namespace Vulkan;

[Flags]
public enum VkImageAspectFlags
{
	None = 0,
	Color = 1,
	Depth = 2,
	Stencil = 4,
	Metadata = 8,
	Plane0KHR = 0x10,
	Plane1KHR = 0x20,
	Plane2KHR = 0x40
}
