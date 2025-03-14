using System;

namespace Vulkan;

[Flags]
public enum VkSampleCountFlags
{
	None = 0,
	Count1 = 1,
	Count2 = 2,
	Count4 = 4,
	Count8 = 8,
	Count16 = 0x10,
	Count32 = 0x20,
	Count64 = 0x40
}
