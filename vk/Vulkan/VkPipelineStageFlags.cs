using System;

namespace Vulkan;

[Flags]
public enum VkPipelineStageFlags
{
	None = 0,
	TopOfPipe = 1,
	DrawIndirect = 2,
	VertexInput = 4,
	VertexShader = 8,
	TessellationControlShader = 0x10,
	TessellationEvaluationShader = 0x20,
	GeometryShader = 0x40,
	FragmentShader = 0x80,
	EarlyFragmentTests = 0x100,
	LateFragmentTests = 0x200,
	ColorAttachmentOutput = 0x400,
	ComputeShader = 0x800,
	Transfer = 0x1000,
	BottomOfPipe = 0x2000,
	Host = 0x4000,
	AllGraphics = 0x8000,
	AllCommands = 0x10000,
	CommandProcessNVX = 0x20000
}
