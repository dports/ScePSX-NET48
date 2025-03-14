namespace Vulkan;

public struct VkBindBufferMemoryDeviceGroupInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint deviceIndexCount;

	public unsafe uint* pDeviceIndices;

	public static VkBindBufferMemoryDeviceGroupInfoKHX New()
	{
		VkBindBufferMemoryDeviceGroupInfoKHX result = default(VkBindBufferMemoryDeviceGroupInfoKHX);
		result.sType = VkStructureType.BindBufferMemoryDeviceGroupInfoKHX;
		return result;
	}
}
