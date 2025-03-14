using System;

namespace Vulkan;

[Flags]
public enum VkDeviceGroupPresentModeFlagsKHX
{
	None = 0,
	LocalKHX = 1,
	RemoteKHX = 2,
	SumKHX = 4,
	LocalMultiDeviceKHX = 8
}
