using System;

namespace Vulkan;

[Flags]
public enum VkExternalMemoryHandleTypeFlagsNV
{
	None = 0,
	OpaqueWin32NV = 1,
	OpaqueWin32KmtNV = 2,
	D3d11ImageNV = 4,
	D3d11ImageKmtNV = 8
}
