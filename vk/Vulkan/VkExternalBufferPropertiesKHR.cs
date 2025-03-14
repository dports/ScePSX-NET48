namespace Vulkan;

public struct VkExternalBufferPropertiesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryPropertiesKHR externalMemoryProperties;

	public static VkExternalBufferPropertiesKHR New()
	{
		VkExternalBufferPropertiesKHR result = default(VkExternalBufferPropertiesKHR);
		result.sType = VkStructureType.ExternalBufferPropertiesKHR;
		return result;
	}
}
