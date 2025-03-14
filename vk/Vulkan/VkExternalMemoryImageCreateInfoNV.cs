namespace Vulkan;

public struct VkExternalMemoryImageCreateInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsNV handleTypes;

	public static VkExternalMemoryImageCreateInfoNV New()
	{
		VkExternalMemoryImageCreateInfoNV result = default(VkExternalMemoryImageCreateInfoNV);
		result.sType = VkStructureType.ExternalMemoryImageCreateInfoNV;
		return result;
	}
}
