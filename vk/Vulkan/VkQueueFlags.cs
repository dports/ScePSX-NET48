using System;

namespace Vulkan;

[Flags]
public enum VkQueueFlags
{
	None = 0,
	Graphics = 1,
	Compute = 2,
	Transfer = 4,
	SparseBinding = 8
}
