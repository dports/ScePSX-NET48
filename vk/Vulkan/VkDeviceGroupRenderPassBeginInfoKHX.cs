namespace Vulkan;

public struct VkDeviceGroupRenderPassBeginInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint deviceMask;

	public uint deviceRenderAreaCount;

	public unsafe VkRect2D* pDeviceRenderAreas;

	public static VkDeviceGroupRenderPassBeginInfoKHX New()
	{
		VkDeviceGroupRenderPassBeginInfoKHX result = default(VkDeviceGroupRenderPassBeginInfoKHX);
		result.sType = VkStructureType.DeviceGroupRenderPassBeginInfoKHX;
		return result;
	}
}
