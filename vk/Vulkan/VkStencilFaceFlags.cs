using System;

namespace Vulkan;

[Flags]
public enum VkStencilFaceFlags
{
	None = 0,
	Front = 1,
	Back = 2,
	FrontAndBack = 3
}
