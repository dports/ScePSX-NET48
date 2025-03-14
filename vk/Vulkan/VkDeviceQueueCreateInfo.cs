namespace Vulkan;

public struct VkDeviceQueueCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint queueFamilyIndex;

	public uint queueCount;

	public unsafe float* pQueuePriorities;

	public static VkDeviceQueueCreateInfo New()
	{
		VkDeviceQueueCreateInfo result = default(VkDeviceQueueCreateInfo);
		result.sType = VkStructureType.DeviceQueueCreateInfo;
		return result;
	}
}
