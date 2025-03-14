namespace Vulkan;

public struct VkDisplaySurfaceCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkDisplayModeKHR displayMode;

	public uint planeIndex;

	public uint planeStackIndex;

	public VkSurfaceTransformFlagsKHR transform;

	public float globalAlpha;

	public VkDisplayPlaneAlphaFlagsKHR alphaMode;

	public VkExtent2D imageExtent;

	public static VkDisplaySurfaceCreateInfoKHR New()
	{
		VkDisplaySurfaceCreateInfoKHR result = default(VkDisplaySurfaceCreateInfoKHR);
		result.sType = VkStructureType.DisplaySurfaceCreateInfoKHR;
		return result;
	}
}
