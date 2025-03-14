using System;

namespace Vulkan;

[Flags]
public enum VkSparseImageFormatFlags
{
	None = 0,
	SingleMiptail = 1,
	AlignedMipSize = 2,
	NonstandardBlockSize = 4
}
