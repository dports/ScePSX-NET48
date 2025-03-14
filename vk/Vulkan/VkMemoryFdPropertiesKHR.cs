namespace Vulkan;

public struct VkMemoryFdPropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint memoryTypeBits;

	public static VkMemoryFdPropertiesKHR New()
	{
		VkMemoryFdPropertiesKHR result = default(VkMemoryFdPropertiesKHR);
		result.sType = VkStructureType.MemoryFdPropertiesKHR;
		return result;
	}
}
