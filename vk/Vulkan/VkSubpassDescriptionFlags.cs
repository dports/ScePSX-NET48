using System;

namespace Vulkan;

[Flags]
public enum VkSubpassDescriptionFlags
{
	None = 0,
	PerViewAttributesNVX = 1,
	PerViewPositionXOnlyNVX = 2
}
