using System;

namespace Vulkan;

[Flags]
public enum VkMemoryPropertyFlags
{
	None = 0,
	DeviceLocal = 1,
	HostVisible = 2,
	HostCoherent = 4,
	HostCached = 8,
	LazilyAllocated = 0x10
}
