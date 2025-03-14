namespace Vulkan;

public struct VkMultisamplePropertiesEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExtent2D maxSampleLocationGridSize;

	public static VkMultisamplePropertiesEXT New()
	{
		VkMultisamplePropertiesEXT result = default(VkMultisamplePropertiesEXT);
		result.sType = VkStructureType.MultisamplePropertiesEXT;
		return result;
	}
}
