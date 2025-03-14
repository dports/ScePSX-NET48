using System;

namespace Vulkan;

public struct VkSpecializationMapEntry
{
	public uint constantID;

	public uint offset;

	public UIntPtr size;
}
