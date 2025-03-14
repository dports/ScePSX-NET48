using Vulkan.Win32;

namespace Vulkan;

public struct VkWin32SurfaceCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public HINSTANCE hinstance;

	public HWND hwnd;

	public static VkWin32SurfaceCreateInfoKHR New()
	{
		VkWin32SurfaceCreateInfoKHR result = default(VkWin32SurfaceCreateInfoKHR);
		result.sType = VkStructureType.Win32SurfaceCreateInfoKHR;
		return result;
	}
}
