namespace Vulkan;

public struct VkBindSparseInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint waitSemaphoreCount;

	public unsafe VkSemaphore* pWaitSemaphores;

	public uint bufferBindCount;

	public unsafe VkSparseBufferMemoryBindInfo* pBufferBinds;

	public uint imageOpaqueBindCount;

	public unsafe VkSparseImageOpaqueMemoryBindInfo* pImageOpaqueBinds;

	public uint imageBindCount;

	public unsafe VkSparseImageMemoryBindInfo* pImageBinds;

	public uint signalSemaphoreCount;

	public unsafe VkSemaphore* pSignalSemaphores;

	public static VkBindSparseInfo New()
	{
		VkBindSparseInfo result = default(VkBindSparseInfo);
		result.sType = VkStructureType.BindSparseInfo;
		return result;
	}
}
