using System;

namespace Vulkan;

[Flags]
public enum VkColorComponentFlags
{
	None = 0,
	R = 1,
	G = 2,
	B = 4,
	A = 8
}
