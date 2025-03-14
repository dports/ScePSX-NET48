using System;

namespace Vulkan;

[Flags]
public enum VkShaderStageFlags
{
	None = 0,
	Vertex = 1,
	TessellationControl = 2,
	TessellationEvaluation = 4,
	Geometry = 8,
	Fragment = 0x10,
	Compute = 0x20,
	AllGraphics = 0x1F,
	All = int.MaxValue
}
