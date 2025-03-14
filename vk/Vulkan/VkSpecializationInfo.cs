using System;

namespace Vulkan;

public struct VkSpecializationInfo
{
	public uint mapEntryCount;

	public unsafe VkSpecializationMapEntry* pMapEntries;

	public UIntPtr dataSize;

	public unsafe void* pData;
}
