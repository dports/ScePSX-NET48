using System;

namespace Vulkan;

public struct VkValidationCacheCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public UIntPtr initialDataSize;

	public unsafe void* pInitialData;

	public static VkValidationCacheCreateInfoEXT New()
	{
		VkValidationCacheCreateInfoEXT result = default(VkValidationCacheCreateInfoEXT);
		result.sType = VkStructureType.ValidationCacheCreateInfoEXT;
		return result;
	}
}
