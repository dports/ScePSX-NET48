using System;

namespace Vulkan;

[Flags]
public enum VkDependencyFlags
{
	None = 0,
	ByRegion = 1,
	ViewLocalKHX = 2,
	DeviceGroupKHX = 4
}
