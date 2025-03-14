namespace Vulkan;

public struct VkWin32KeyedMutexAcquireReleaseInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint acquireCount;

	public unsafe VkDeviceMemory* pAcquireSyncs;

	public unsafe ulong* pAcquireKeys;

	public unsafe uint* pAcquireTimeoutMilliseconds;

	public uint releaseCount;

	public unsafe VkDeviceMemory* pReleaseSyncs;

	public unsafe ulong* pReleaseKeys;

	public static VkWin32KeyedMutexAcquireReleaseInfoNV New()
	{
		VkWin32KeyedMutexAcquireReleaseInfoNV result = default(VkWin32KeyedMutexAcquireReleaseInfoNV);
		result.sType = VkStructureType.Win32KeyedMutexAcquireReleaseInfoNV;
		return result;
	}
}
