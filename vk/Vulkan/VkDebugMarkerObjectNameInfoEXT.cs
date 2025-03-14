namespace Vulkan;

public struct VkDebugMarkerObjectNameInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDebugReportObjectTypeEXT objectType;

	public ulong @object;

	public unsafe byte* pObjectName;

	public static VkDebugMarkerObjectNameInfoEXT New()
	{
		VkDebugMarkerObjectNameInfoEXT result = default(VkDebugMarkerObjectNameInfoEXT);
		result.sType = VkStructureType.DebugMarkerObjectNameInfoEXT;
		return result;
	}
}
