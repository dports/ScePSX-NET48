namespace Vulkan;

public struct VkFenceGetFdInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkFence fence;

	public VkExternalFenceHandleTypeFlagsKHR handleType;

	public static VkFenceGetFdInfoKHR New()
	{
		VkFenceGetFdInfoKHR result = default(VkFenceGetFdInfoKHR);
		result.sType = VkStructureType.FenceGetFdInfoKHR;
		return result;
	}
}
