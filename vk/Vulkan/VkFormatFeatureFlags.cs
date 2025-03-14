using System;

namespace Vulkan;

[Flags]
public enum VkFormatFeatureFlags
{
	None = 0,
	SampledImage = 1,
	StorageImage = 2,
	StorageImageAtomic = 4,
	UniformTexelBuffer = 8,
	StorageTexelBuffer = 0x10,
	StorageTexelBufferAtomic = 0x20,
	VertexBuffer = 0x40,
	ColorAttachment = 0x80,
	ColorAttachmentBlend = 0x100,
	DepthStencilAttachment = 0x200,
	BlitSrc = 0x400,
	BlitDst = 0x800,
	SampledImageFilterLinear = 0x1000,
	SampledImageFilterCubicImg = 0x2000,
	TransferSrcKHR = 0x4000,
	TransferDstKHR = 0x8000,
	SampledImageFilterMinmaxEXT = 0x10000,
	MidpointChromaSamplesKHR = 0x20000,
	SampledImageYcbcrConversionLinearFilterKHR = 0x40000,
	SampledImageYcbcrConversionSeparateReconstructionFilterKHR = 0x80000,
	SampledImageYcbcrConversionChromaReconstructionExplicitKHR = 0x100000,
	SampledImageYcbcrConversionChromaReconstructionExplicitForceableKHR = 0x200000,
	DisjointKHR = 0x400000,
	CositedChromaSamplesKHR = 0x800000
}
