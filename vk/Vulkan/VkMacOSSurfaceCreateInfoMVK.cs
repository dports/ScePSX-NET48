namespace Vulkan;

public struct VkMacOSSurfaceCreateInfoMVK
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public unsafe void* pView;

	public static VkMacOSSurfaceCreateInfoMVK New()
	{
		VkMacOSSurfaceCreateInfoMVK result = default(VkMacOSSurfaceCreateInfoMVK);
		result.sType = VkStructureType.MacosSurfaceCreateInfoMvk;
		return result;
	}
}
