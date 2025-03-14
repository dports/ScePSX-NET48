namespace Vulkan;

public struct VkImageFormatProperties2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkImageFormatProperties imageFormatProperties;

	public static VkImageFormatProperties2KHR New()
	{
		VkImageFormatProperties2KHR result = default(VkImageFormatProperties2KHR);
		result.sType = VkStructureType.ImageFormatProperties2KHR;
		return result;
	}
}
