using System;

namespace Vulkan;

[Flags]
public enum VkSurfaceTransformFlagsKHR
{
	None = 0,
	IdentityKHR = 1,
	Rotate90KHR = 2,
	Rotate180KHR = 4,
	Rotate270KHR = 8,
	HorizontalMirrorKHR = 0x10,
	HorizontalMirrorRotate90KHR = 0x20,
	HorizontalMirrorRotate180KHR = 0x40,
	HorizontalMirrorRotate270KHR = 0x80,
	InheritKHR = 0x100
}
