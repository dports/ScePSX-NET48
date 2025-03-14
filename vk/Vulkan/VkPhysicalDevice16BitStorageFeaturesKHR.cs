namespace Vulkan;

public struct VkPhysicalDevice16BitStorageFeaturesKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 storageBuffer16BitAccess;

	public VkBool32 uniformAndStorageBuffer16BitAccess;

	public VkBool32 storagePushConstant16;

	public VkBool32 storageInputOutput16;

	public static VkPhysicalDevice16BitStorageFeaturesKHR New()
	{
		VkPhysicalDevice16BitStorageFeaturesKHR result = default(VkPhysicalDevice16BitStorageFeaturesKHR);
		result.sType = VkStructureType.PhysicalDevice16bitStorageFeaturesKHR;
		return result;
	}
}
