using System;

namespace Vulkan;

[Flags]
public enum VkPipelineCreateFlags
{
	None = 0,
	DisableOptimization = 1,
	AllowDerivatives = 2,
	Derivative = 4,
	ViewIndexFromDeviceIndexKHX = 8,
	DispatchBaseKHX = 0x10
}
