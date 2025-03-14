using System;

namespace Vulkan;

public struct VkDebugMarkerObjectTagInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDebugReportObjectTypeEXT objectType;

	public ulong @object;

	public ulong tagName;

	public UIntPtr tagSize;

	public unsafe void* pTag;

	public static VkDebugMarkerObjectTagInfoEXT New()
	{
		VkDebugMarkerObjectTagInfoEXT result = default(VkDebugMarkerObjectTagInfoEXT);
		result.sType = VkStructureType.DebugMarkerObjectTagInfoEXT;
		return result;
	}
}
