namespace Vulkan;

public struct VkPhysicalDeviceVariablePointerFeaturesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 variablePointersStorageBuffer;

	public VkBool32 variablePointers;

	public static VkPhysicalDeviceVariablePointerFeaturesKHR New()
	{
		VkPhysicalDeviceVariablePointerFeaturesKHR result = default(VkPhysicalDeviceVariablePointerFeaturesKHR);
		result.sType = VkStructureType.PhysicalDeviceVariablePointerFeaturesKHR;
		return result;
	}
}
