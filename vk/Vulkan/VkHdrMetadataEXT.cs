namespace Vulkan;

public struct VkHdrMetadataEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkXYColorEXT displayPrimaryRed;

	public VkXYColorEXT displayPrimaryGreen;

	public VkXYColorEXT displayPrimaryBlue;

	public VkXYColorEXT whitePoint;

	public float maxLuminance;

	public float minLuminance;

	public float maxContentLightLevel;

	public float maxFrameAverageLightLevel;

	public static VkHdrMetadataEXT New()
	{
		VkHdrMetadataEXT result = default(VkHdrMetadataEXT);
		result.sType = VkStructureType.HdrMetadataEXT;
		return result;
	}
}
