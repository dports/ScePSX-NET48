using System;

namespace Vulkan;

[Flags]
public enum VkImageCreateFlags
{
	None = 0,
	SparseBinding = 1,
	SparseResidency = 2,
	SparseAliased = 4,
	MutableFormat = 8,
	CubeCompatible = 0x10,
	BindSfrKHX = 0x40,
	_2dArrayCompatibleKHR = 0x20,
	BlockTexelViewCompatibleKHR = 0x80,
	ExtendedUsageKHR = 0x100,
	SampleLocationsCompatibleDepthEXT = 0x1000,
	DisjointKHR = 0x200,
	AliasKHR = 0x400
}
