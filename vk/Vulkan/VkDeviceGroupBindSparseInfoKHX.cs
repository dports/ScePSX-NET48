namespace Vulkan;

public struct VkDeviceGroupBindSparseInfoKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint resourceDeviceIndex;

	public uint memoryDeviceIndex;

	public static VkDeviceGroupBindSparseInfoKHX New()
	{
		VkDeviceGroupBindSparseInfoKHX result = default(VkDeviceGroupBindSparseInfoKHX);
		result.sType = VkStructureType.DeviceGroupBindSparseInfoKHX;
		return result;
	}
}
