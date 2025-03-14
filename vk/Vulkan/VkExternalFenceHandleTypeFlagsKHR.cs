using System;

namespace Vulkan;

[Flags]
public enum VkExternalFenceHandleTypeFlagsKHR
{
	None = 0,
	OpaqueFdKHR = 1,
	OpaqueWin32KHR = 2,
	OpaqueWin32KmtKHR = 4,
	SyncFdKHR = 8
}
