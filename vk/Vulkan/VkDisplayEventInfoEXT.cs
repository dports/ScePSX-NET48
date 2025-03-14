namespace Vulkan;

public struct VkDisplayEventInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDisplayEventTypeEXT displayEvent;

	public static VkDisplayEventInfoEXT New()
	{
		VkDisplayEventInfoEXT result = default(VkDisplayEventInfoEXT);
		result.sType = VkStructureType.DisplayEventInfoEXT;
		return result;
	}
}
