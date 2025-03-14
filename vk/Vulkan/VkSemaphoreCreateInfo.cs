namespace Vulkan;

public struct VkSemaphoreCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public static VkSemaphoreCreateInfo New()
	{
		VkSemaphoreCreateInfo result = default(VkSemaphoreCreateInfo);
		result.sType = VkStructureType.SemaphoreCreateInfo;
		return result;
	}
}
