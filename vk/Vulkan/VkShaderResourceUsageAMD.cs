using System;

namespace Vulkan;

public struct VkShaderResourceUsageAMD
{
	public uint numUsedVgprs;

	public uint numUsedSgprs;

	public uint ldsSizePerLocalWorkGroup;

	public UIntPtr ldsUsageSizeInBytes;

	public UIntPtr scratchMemUsageInBytes;
}
