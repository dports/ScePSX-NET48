namespace Vulkan;

public struct VkValidationFlagsEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint disabledValidationCheckCount;

	public unsafe VkValidationCheckEXT* pDisabledValidationChecks;

	public static VkValidationFlagsEXT New()
	{
		VkValidationFlagsEXT result = default(VkValidationFlagsEXT);
		result.sType = VkStructureType.ValidationEXT;
		return result;
	}
}
