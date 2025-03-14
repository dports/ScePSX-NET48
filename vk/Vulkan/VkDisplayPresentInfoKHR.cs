namespace Vulkan;

public struct VkDisplayPresentInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkRect2D srcRect;

	public VkRect2D dstRect;

	public VkBool32 persistent;

	public static VkDisplayPresentInfoKHR New()
	{
		VkDisplayPresentInfoKHR result = default(VkDisplayPresentInfoKHR);
		result.sType = VkStructureType.DisplayPresentInfoKHR;
		return result;
	}
}
