using Vulkan.Mir;

namespace Vulkan;

public struct VkMirSurfaceCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public unsafe MirConnection* connection;

	public unsafe MirSurface* mirSurface;

	public static VkMirSurfaceCreateInfoKHR New()
	{
		VkMirSurfaceCreateInfoKHR result = default(VkMirSurfaceCreateInfoKHR);
		result.sType = VkStructureType.MirSurfaceCreateInfoKHR;
		return result;
	}
}
