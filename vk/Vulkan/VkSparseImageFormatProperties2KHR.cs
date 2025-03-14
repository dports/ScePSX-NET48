namespace Vulkan;

public struct VkSparseImageFormatProperties2KHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSparseImageFormatProperties properties;

	public static VkSparseImageFormatProperties2KHR New()
	{
		VkSparseImageFormatProperties2KHR result = default(VkSparseImageFormatProperties2KHR);
		result.sType = VkStructureType.SparseImageFormatProperties2KHR;
		return result;
	}
}
