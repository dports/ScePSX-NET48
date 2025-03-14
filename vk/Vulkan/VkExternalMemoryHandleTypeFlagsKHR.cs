using System;

namespace Vulkan;

[Flags]
public enum VkExternalMemoryHandleTypeFlagsKHR
{
	None = 0,
	OpaqueFdKHR = 1,
	OpaqueWin32KHR = 2,
	OpaqueWin32KmtKHR = 4,
	D3d11TextureKHR = 8,
	D3d11TextureKmtKHR = 0x10,
	D3d12HeapKHR = 0x20,
	D3d12ResourceKHR = 0x40,
	DmaBufEXT = 0x200,
	HostAllocationEXT = 0x80,
	HostMappedForeignMemoryEXT = 0x100
}
