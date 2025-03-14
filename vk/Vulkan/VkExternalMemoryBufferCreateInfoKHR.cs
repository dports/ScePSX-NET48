namespace Vulkan;

public struct VkExternalMemoryBufferCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsKHR handleTypes;

	public static VkExternalMemoryBufferCreateInfoKHR New()
	{
		VkExternalMemoryBufferCreateInfoKHR result = default(VkExternalMemoryBufferCreateInfoKHR);
		result.sType = VkStructureType.ExternalMemoryBufferCreateInfoKHR;
		return result;
	}
}
