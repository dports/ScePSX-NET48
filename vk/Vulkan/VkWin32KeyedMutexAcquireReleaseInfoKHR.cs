namespace Vulkan;

public struct VkWin32KeyedMutexAcquireReleaseInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint acquireCount;

	public unsafe VkDeviceMemory* pAcquireSyncs;

	public unsafe ulong* pAcquireKeys;

	public unsafe uint* pAcquireTimeouts;

	public uint releaseCount;

	public unsafe VkDeviceMemory* pReleaseSyncs;

	public unsafe ulong* pReleaseKeys;

	public static VkWin32KeyedMutexAcquireReleaseInfoKHR New()
	{
		VkWin32KeyedMutexAcquireReleaseInfoKHR result = default(VkWin32KeyedMutexAcquireReleaseInfoKHR);
		result.sType = VkStructureType.Win32KeyedMutexAcquireReleaseInfoKHR;
		return result;
	}
}
