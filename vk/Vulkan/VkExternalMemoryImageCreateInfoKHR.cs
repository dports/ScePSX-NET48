namespace Vulkan;

public struct VkExternalMemoryImageCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsKHR handleTypes;

	public static VkExternalMemoryImageCreateInfoKHR New()
	{
		VkExternalMemoryImageCreateInfoKHR result = default(VkExternalMemoryImageCreateInfoKHR);
		result.sType = VkStructureType.ExternalMemoryImageCreateInfoKHR;
		return result;
	}
}
