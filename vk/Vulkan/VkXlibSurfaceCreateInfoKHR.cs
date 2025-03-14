using Vulkan.Xlib;

namespace Vulkan;

public struct VkXlibSurfaceCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public unsafe Display* dpy;

	public Window window;

	public static VkXlibSurfaceCreateInfoKHR New()
	{
		VkXlibSurfaceCreateInfoKHR result = default(VkXlibSurfaceCreateInfoKHR);
		result.sType = VkStructureType.XlibSurfaceCreateInfoKHR;
		return result;
	}
}
