namespace Vulkan;

public struct VkRenderPassSampleLocationsBeginInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint attachmentInitialSampleLocationsCount;

	public unsafe VkAttachmentSampleLocationsEXT* pAttachmentInitialSampleLocations;

	public uint postSubpassSampleLocationsCount;

	public unsafe VkSubpassSampleLocationsEXT* pPostSubpassSampleLocations;

	public static VkRenderPassSampleLocationsBeginInfoEXT New()
	{
		VkRenderPassSampleLocationsBeginInfoEXT result = default(VkRenderPassSampleLocationsBeginInfoEXT);
		result.sType = VkStructureType.RenderPassSampleLocationsBeginInfoEXT;
		return result;
	}
}
