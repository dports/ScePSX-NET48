namespace Vulkan;

public struct VkFenceCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkFenceCreateFlags flags;

	public static VkFenceCreateInfo New()
	{
		VkFenceCreateInfo result = default(VkFenceCreateInfo);
		result.sType = VkStructureType.FenceCreateInfo;
		return result;
	}
}
