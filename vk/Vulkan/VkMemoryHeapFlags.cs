using System;

namespace Vulkan;

[Flags]
public enum VkMemoryHeapFlags
{
	None = 0,
	DeviceLocal = 1,
	MultiInstanceKHX = 2
}
