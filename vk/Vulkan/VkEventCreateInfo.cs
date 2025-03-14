namespace Vulkan;

public struct VkEventCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public static VkEventCreateInfo New()
	{
		VkEventCreateInfo result = default(VkEventCreateInfo);
		result.sType = VkStructureType.EventCreateInfo;
		return result;
	}
}
