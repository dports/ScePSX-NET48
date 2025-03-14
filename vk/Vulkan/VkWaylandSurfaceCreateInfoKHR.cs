using Vulkan.Wayland;

namespace Vulkan;

public struct VkWaylandSurfaceCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public unsafe wl_display* display;

	public unsafe wl_surface* surface;

	public static VkWaylandSurfaceCreateInfoKHR New()
	{
		VkWaylandSurfaceCreateInfoKHR result = default(VkWaylandSurfaceCreateInfoKHR);
		result.sType = VkStructureType.WaylandSurfaceCreateInfoKHR;
		return result;
	}
}
