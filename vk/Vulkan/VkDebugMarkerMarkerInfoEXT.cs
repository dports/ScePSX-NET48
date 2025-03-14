namespace Vulkan;

public struct VkDebugMarkerMarkerInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public unsafe byte* pMarkerName;

	public float color_0;

	public float color_1;

	public float color_2;

	public float color_3;

	public static VkDebugMarkerMarkerInfoEXT New()
	{
		VkDebugMarkerMarkerInfoEXT result = default(VkDebugMarkerMarkerInfoEXT);
		result.sType = VkStructureType.DebugMarkerMarkerInfoEXT;
		return result;
	}
}
