namespace Vulkan;

public struct VkIOSSurfaceCreateInfoMVK
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public unsafe void* pView;

	public static VkIOSSurfaceCreateInfoMVK New()
	{
		VkIOSSurfaceCreateInfoMVK result = default(VkIOSSurfaceCreateInfoMVK);
		result.sType = VkStructureType.IosSurfaceCreateInfoMvk;
		return result;
	}
}
