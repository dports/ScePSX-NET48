namespace Vulkan;

public struct VkPhysicalDeviceSampleLocationsPropertiesEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSampleCountFlags sampleLocationSampleCounts;

	public VkExtent2D maxSampleLocationGridSize;

	public float sampleLocationCoordinateRange_0;

	public float sampleLocationCoordinateRange_1;

	public uint sampleLocationSubPixelBits;

	public VkBool32 variableSampleLocations;

	public static VkPhysicalDeviceSampleLocationsPropertiesEXT New()
	{
		VkPhysicalDeviceSampleLocationsPropertiesEXT result = default(VkPhysicalDeviceSampleLocationsPropertiesEXT);
		result.sType = VkStructureType.PhysicalDeviceSampleLocationsPropertiesEXT;
		return result;
	}
}
