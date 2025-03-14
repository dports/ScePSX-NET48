using System;

namespace Vulkan;

public struct VkPipelineCacheCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public UIntPtr initialDataSize;

	public unsafe void* pInitialData;

	public static VkPipelineCacheCreateInfo New()
	{
		VkPipelineCacheCreateInfo result = default(VkPipelineCacheCreateInfo);
		result.sType = VkStructureType.PipelineCacheCreateInfo;
		return result;
	}
}
