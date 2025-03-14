namespace Vulkan;

public struct VkDisplayPowerInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDisplayPowerStateEXT powerState;

	public static VkDisplayPowerInfoEXT New()
	{
		VkDisplayPowerInfoEXT result = default(VkDisplayPowerInfoEXT);
		result.sType = VkStructureType.DisplayPowerInfoEXT;
		return result;
	}
}
