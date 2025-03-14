namespace Vulkan;

public struct VkDisplayModeCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkDisplayModeParametersKHR parameters;

	public static VkDisplayModeCreateInfoKHR New()
	{
		VkDisplayModeCreateInfoKHR result = default(VkDisplayModeCreateInfoKHR);
		result.sType = VkStructureType.DisplayModeCreateInfoKHR;
		return result;
	}
}
