namespace Vulkan;

public struct VkPhysicalDeviceMultiviewFeaturesKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 multiview;

	public VkBool32 multiviewGeometryShader;

	public VkBool32 multiviewTessellationShader;

	public static VkPhysicalDeviceMultiviewFeaturesKHX New()
	{
		VkPhysicalDeviceMultiviewFeaturesKHX result = default(VkPhysicalDeviceMultiviewFeaturesKHX);
		result.sType = VkStructureType.PhysicalDeviceMultiviewFeaturesKHX;
		return result;
	}
}
