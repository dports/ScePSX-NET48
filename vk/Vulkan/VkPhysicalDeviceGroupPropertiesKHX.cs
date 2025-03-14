namespace Vulkan;

public struct VkPhysicalDeviceGroupPropertiesKHX
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint physicalDeviceCount;

	public VkPhysicalDevice physicalDevices_0;

	public VkPhysicalDevice physicalDevices_1;

	public VkPhysicalDevice physicalDevices_2;

	public VkPhysicalDevice physicalDevices_3;

	public VkPhysicalDevice physicalDevices_4;

	public VkPhysicalDevice physicalDevices_5;

	public VkPhysicalDevice physicalDevices_6;

	public VkPhysicalDevice physicalDevices_7;

	public VkPhysicalDevice physicalDevices_8;

	public VkPhysicalDevice physicalDevices_9;

	public VkPhysicalDevice physicalDevices_10;

	public VkPhysicalDevice physicalDevices_11;

	public VkPhysicalDevice physicalDevices_12;

	public VkPhysicalDevice physicalDevices_13;

	public VkPhysicalDevice physicalDevices_14;

	public VkPhysicalDevice physicalDevices_15;

	public VkPhysicalDevice physicalDevices_16;

	public VkPhysicalDevice physicalDevices_17;

	public VkPhysicalDevice physicalDevices_18;

	public VkPhysicalDevice physicalDevices_19;

	public VkPhysicalDevice physicalDevices_20;

	public VkPhysicalDevice physicalDevices_21;

	public VkPhysicalDevice physicalDevices_22;

	public VkPhysicalDevice physicalDevices_23;

	public VkPhysicalDevice physicalDevices_24;

	public VkPhysicalDevice physicalDevices_25;

	public VkPhysicalDevice physicalDevices_26;

	public VkPhysicalDevice physicalDevices_27;

	public VkPhysicalDevice physicalDevices_28;

	public VkPhysicalDevice physicalDevices_29;

	public VkPhysicalDevice physicalDevices_30;

	public VkPhysicalDevice physicalDevices_31;

	public VkBool32 subsetAllocation;

	public static VkPhysicalDeviceGroupPropertiesKHX New()
	{
		VkPhysicalDeviceGroupPropertiesKHX result = default(VkPhysicalDeviceGroupPropertiesKHX);
		result.sType = VkStructureType.PhysicalDeviceGroupPropertiesKHX;
		return result;
	}
}
