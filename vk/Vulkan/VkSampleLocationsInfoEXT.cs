namespace Vulkan;

public struct VkSampleLocationsInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkSampleCountFlags sampleLocationsPerPixel;

	public VkExtent2D sampleLocationGridSize;

	public uint sampleLocationsCount;

	public unsafe VkSampleLocationEXT* pSampleLocations;

	public static VkSampleLocationsInfoEXT New()
	{
		VkSampleLocationsInfoEXT result = default(VkSampleLocationsInfoEXT);
		result.sType = VkStructureType.SampleLocationsInfoEXT;
		return result;
	}
}
