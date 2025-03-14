namespace Vulkan;

public struct VkRenderPassCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public uint attachmentCount;

	public unsafe VkAttachmentDescription* pAttachments;

	public uint subpassCount;

	public unsafe VkSubpassDescription* pSubpasses;

	public uint dependencyCount;

	public unsafe VkSubpassDependency* pDependencies;

	public static VkRenderPassCreateInfo New()
	{
		VkRenderPassCreateInfo result = default(VkRenderPassCreateInfo);
		result.sType = VkStructureType.RenderPassCreateInfo;
		return result;
	}
}
