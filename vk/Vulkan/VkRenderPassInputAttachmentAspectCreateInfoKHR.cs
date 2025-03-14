namespace Vulkan;

public struct VkRenderPassInputAttachmentAspectCreateInfoKHR
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint aspectReferenceCount;

	public unsafe VkInputAttachmentAspectReferenceKHR* pAspectReferences;

	public static VkRenderPassInputAttachmentAspectCreateInfoKHR New()
	{
		VkRenderPassInputAttachmentAspectCreateInfoKHR result = default(VkRenderPassInputAttachmentAspectCreateInfoKHR);
		result.sType = VkStructureType.RenderPassInputAttachmentAspectCreateInfoKHR;
		return result;
	}
}
