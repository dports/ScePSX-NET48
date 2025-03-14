namespace Vulkan;

public struct VkD3D12FenceSubmitInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint waitSemaphoreValuesCount;

	public unsafe ulong* pWaitSemaphoreValues;

	public uint signalSemaphoreValuesCount;

	public unsafe ulong* pSignalSemaphoreValues;

	public static VkD3D12FenceSubmitInfoKHR New()
	{
		VkD3D12FenceSubmitInfoKHR result = default(VkD3D12FenceSubmitInfoKHR);
		result.sType = VkStructureType.D3d12FenceSubmitInfoKHR;
		return result;
	}
}
