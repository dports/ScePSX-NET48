namespace Vulkan;

public struct VkFormatProperties2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkFormatProperties formatProperties;

	public static VkFormatProperties2KHR New()
	{
		VkFormatProperties2KHR result = default(VkFormatProperties2KHR);
		result.sType = VkStructureType.FormatProperties2KHR;
		return result;
	}
}
