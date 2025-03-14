using System;

namespace Vulkan;

[Flags]
public enum VkQueryPipelineStatisticFlags
{
	None = 0,
	InputAssemblyVertices = 1,
	InputAssemblyPrimitives = 2,
	VertexShaderInvocations = 4,
	GeometryShaderInvocations = 8,
	GeometryShaderPrimitives = 0x10,
	ClippingInvocations = 0x20,
	ClippingPrimitives = 0x40,
	FragmentShaderInvocations = 0x80,
	TessellationControlShaderPatches = 0x100,
	TessellationEvaluationShaderInvocations = 0x200,
	ComputeShaderInvocations = 0x400
}
