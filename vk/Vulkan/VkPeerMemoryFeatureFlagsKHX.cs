using System;

namespace Vulkan;

[Flags]
public enum VkPeerMemoryFeatureFlagsKHX
{
	None = 0,
	CopySrcKHX = 1,
	CopyDstKHX = 2,
	GenericSrcKHX = 4,
	GenericDstKHX = 8
}
