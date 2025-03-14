using Vulkan.Xcb;

namespace Vulkan;

public struct VkXcbSurfaceCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public unsafe xcb_connection_t* connection;

	public xcb_window_t window;

	public static VkXcbSurfaceCreateInfoKHR New()
	{
		VkXcbSurfaceCreateInfoKHR result = default(VkXcbSurfaceCreateInfoKHR);
		result.sType = VkStructureType.XcbSurfaceCreateInfoKHR;
		return result;
	}
}
