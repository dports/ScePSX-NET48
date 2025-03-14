namespace Vulkan;

public struct VkMemoryWin32HandlePropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint memoryTypeBits;

	public static VkMemoryWin32HandlePropertiesKHR New()
	{
		VkMemoryWin32HandlePropertiesKHR result = default(VkMemoryWin32HandlePropertiesKHR);
		result.sType = VkStructureType.MemoryWin32HandlePropertiesKHR;
		return result;
	}
}
