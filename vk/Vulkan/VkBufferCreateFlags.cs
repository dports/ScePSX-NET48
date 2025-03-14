using System;

namespace Vulkan;

[Flags]
public enum VkBufferCreateFlags
{
	None = 0,
	SparseBinding = 1,
	SparseResidency = 2,
	SparseAliased = 4
}
