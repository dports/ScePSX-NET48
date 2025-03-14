namespace Vulkan;

public struct VkFenceGetWin32HandleInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkFence fence;

	public VkExternalFenceHandleTypeFlagsKHR handleType;

	public static VkFenceGetWin32HandleInfoKHR New()
	{
		VkFenceGetWin32HandleInfoKHR result = default(VkFenceGetWin32HandleInfoKHR);
		result.sType = VkStructureType.FenceGetWin32HandleInfoKHR;
		return result;
	}
}
