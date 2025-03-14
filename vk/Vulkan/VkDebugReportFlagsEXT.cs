using System;

namespace Vulkan;

[Flags]
public enum VkDebugReportFlagsEXT
{
	None = 0,
	InformationEXT = 1,
	WarningEXT = 2,
	PerformanceWarningEXT = 4,
	ErrorEXT = 8,
	DebugEXT = 0x10
}
