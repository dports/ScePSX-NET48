namespace Vulkan;

public struct VkBindImageMemoryDeviceGroupInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint deviceIndexCount;

	public unsafe uint* pDeviceIndices;

	public uint SFRRectCount;

	public unsafe VkRect2D* pSFRRects;

	public static VkBindImageMemoryDeviceGroupInfoKHX New()
	{
		VkBindImageMemoryDeviceGroupInfoKHX result = default(VkBindImageMemoryDeviceGroupInfoKHX);
		result.sType = VkStructureType.BindImageMemoryDeviceGroupInfoKHX;
		return result;
	}
}
