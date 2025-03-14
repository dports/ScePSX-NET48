namespace Vulkan;

public struct VkViSurfaceCreateInfoNN
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public unsafe void* window;

	public static VkViSurfaceCreateInfoNN New()
	{
		VkViSurfaceCreateInfoNN result = default(VkViSurfaceCreateInfoNN);
		result.sType = VkStructureType.ViSurfaceCreateInfoNn;
		return result;
	}
}
