namespace Vulkan;

public struct VkCommandPoolCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkCommandPoolCreateFlags flags;

	public uint queueFamilyIndex;

	public static VkCommandPoolCreateInfo New()
	{
		VkCommandPoolCreateInfo result = default(VkCommandPoolCreateInfo);
		result.sType = VkStructureType.CommandPoolCreateInfo;
		return result;
	}
}
