using System;

namespace Vulkan;

[Flags]
public enum VkQueryResultFlags
{
	None = 0,
	_64 = 1,
	Wait = 2,
	WithAvailability = 4,
	Partial = 8
}
