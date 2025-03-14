namespace Vulkan;

public struct VkMemoryHostPointerPropertiesEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint memoryTypeBits;

	public static VkMemoryHostPointerPropertiesEXT New()
	{
		VkMemoryHostPointerPropertiesEXT result = default(VkMemoryHostPointerPropertiesEXT);
		result.sType = VkStructureType.MemoryHostPointerPropertiesEXT;
		return result;
	}
}
