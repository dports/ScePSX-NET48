using System;

namespace Vulkan;

[Flags]
public enum VkExternalSemaphoreHandleTypeFlagsKHR
{
	None = 0,
	OpaqueFdKHR = 1,
	OpaqueWin32KHR = 2,
	OpaqueWin32KmtKHR = 4,
	D3d12FenceKHR = 8,
	SyncFdKHR = 0x10
}
