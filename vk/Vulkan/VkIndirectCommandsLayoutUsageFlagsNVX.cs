using System;

namespace Vulkan;

[Flags]
public enum VkIndirectCommandsLayoutUsageFlagsNVX
{
	None = 0,
	UnorderedSequencesNVX = 1,
	SparseSequencesNVX = 2,
	EmptyExecutionsNVX = 4,
	IndexedSequencesNVX = 8
}
