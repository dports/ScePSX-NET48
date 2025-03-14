using Vulkan.Android;

namespace Vulkan;

public struct VkAndroidSurfaceCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public unsafe ANativeWindow* window;

	public static VkAndroidSurfaceCreateInfoKHR New()
	{
		VkAndroidSurfaceCreateInfoKHR result = default(VkAndroidSurfaceCreateInfoKHR);
		result.sType = VkStructureType.AndroidSurfaceCreateInfoKHR;
		return result;
	}
}
