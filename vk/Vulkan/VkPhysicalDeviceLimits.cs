using System;

namespace Vulkan;

public struct VkPhysicalDeviceLimits
{
	public uint maxImageDimension1D;

	public uint maxImageDimension2D;

	public uint maxImageDimension3D;

	public uint maxImageDimensionCube;

	public uint maxImageArrayLayers;

	public uint maxTexelBufferElements;

	public uint maxUniformBufferRange;

	public uint maxStorageBufferRange;

	public uint maxPushConstantsSize;

	public uint maxMemoryAllocationCount;

	public uint maxSamplerAllocationCount;

	public ulong bufferImageGranularity;

	public ulong sparseAddressSpaceSize;

	public uint maxBoundDescriptorSets;

	public uint maxPerStageDescriptorSamplers;

	public uint maxPerStageDescriptorUniformBuffers;

	public uint maxPerStageDescriptorStorageBuffers;

	public uint maxPerStageDescriptorSampledImages;

	public uint maxPerStageDescriptorStorageImages;

	public uint maxPerStageDescriptorInputAttachments;

	public uint maxPerStageResources;

	public uint maxDescriptorSetSamplers;

	public uint maxDescriptorSetUniformBuffers;

	public uint maxDescriptorSetUniformBuffersDynamic;

	public uint maxDescriptorSetStorageBuffers;

	public uint maxDescriptorSetStorageBuffersDynamic;

	public uint maxDescriptorSetSampledImages;

	public uint maxDescriptorSetStorageImages;

	public uint maxDescriptorSetInputAttachments;

	public uint maxVertexInputAttributes;

	public uint maxVertexInputBindings;

	public uint maxVertexInputAttributeOffset;

	public uint maxVertexInputBindingStride;

	public uint maxVertexOutputComponents;

	public uint maxTessellationGenerationLevel;

	public uint maxTessellationPatchSize;

	public uint maxTessellationControlPerVertexInputComponents;

	public uint maxTessellationControlPerVertexOutputComponents;

	public uint maxTessellationControlPerPatchOutputComponents;

	public uint maxTessellationControlTotalOutputComponents;

	public uint maxTessellationEvaluationInputComponents;

	public uint maxTessellationEvaluationOutputComponents;

	public uint maxGeometryShaderInvocations;

	public uint maxGeometryInputComponents;

	public uint maxGeometryOutputComponents;

	public uint maxGeometryOutputVertices;

	public uint maxGeometryTotalOutputComponents;

	public uint maxFragmentInputComponents;

	public uint maxFragmentOutputAttachments;

	public uint maxFragmentDualSrcAttachments;

	public uint maxFragmentCombinedOutputResources;

	public uint maxComputeSharedMemorySize;

	public uint maxComputeWorkGroupCount_0;

	public uint maxComputeWorkGroupCount_1;

	public uint maxComputeWorkGroupCount_2;

	public uint maxComputeWorkGroupInvocations;

	public uint maxComputeWorkGroupSize_0;

	public uint maxComputeWorkGroupSize_1;

	public uint maxComputeWorkGroupSize_2;

	public uint subPixelPrecisionBits;

	public uint subTexelPrecisionBits;

	public uint mipmapPrecisionBits;

	public uint maxDrawIndexedIndexValue;

	public uint maxDrawIndirectCount;

	public float maxSamplerLodBias;

	public float maxSamplerAnisotropy;

	public uint maxViewports;

	public uint maxViewportDimensions_0;

	public uint maxViewportDimensions_1;

	public float viewportBoundsRange_0;

	public float viewportBoundsRange_1;

	public uint viewportSubPixelBits;

	public UIntPtr minMemoryMapAlignment;

	public ulong minTexelBufferOffsetAlignment;

	public ulong minUniformBufferOffsetAlignment;

	public ulong minStorageBufferOffsetAlignment;

	public int minTexelOffset;

	public uint maxTexelOffset;

	public int minTexelGatherOffset;

	public uint maxTexelGatherOffset;

	public float minInterpolationOffset;

	public float maxInterpolationOffset;

	public uint subPixelInterpolationOffsetBits;

	public uint maxFramebufferWidth;

	public uint maxFramebufferHeight;

	public uint maxFramebufferLayers;

	public VkSampleCountFlags framebufferColorSampleCounts;

	public VkSampleCountFlags framebufferDepthSampleCounts;

	public VkSampleCountFlags framebufferStencilSampleCounts;

	public VkSampleCountFlags framebufferNoAttachmentsSampleCounts;

	public uint maxColorAttachments;

	public VkSampleCountFlags sampledImageColorSampleCounts;

	public VkSampleCountFlags sampledImageIntegerSampleCounts;

	public VkSampleCountFlags sampledImageDepthSampleCounts;

	public VkSampleCountFlags sampledImageStencilSampleCounts;

	public VkSampleCountFlags storageImageSampleCounts;

	public uint maxSampleMaskWords;

	public VkBool32 timestampComputeAndGraphics;

	public float timestampPeriod;

	public uint maxClipDistances;

	public uint maxCullDistances;

	public uint maxCombinedClipAndCullDistances;

	public uint discreteQueuePriorities;

	public float pointSizeRange_0;

	public float pointSizeRange_1;

	public float lineWidthRange_0;

	public float lineWidthRange_1;

	public float pointSizeGranularity;

	public float lineWidthGranularity;

	public VkBool32 strictLines;

	public VkBool32 standardSampleLocations;

	public ulong optimalBufferCopyOffsetAlignment;

	public ulong optimalBufferCopyRowPitchAlignment;

	public ulong nonCoherentAtomSize;
}
