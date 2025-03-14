namespace Vulkan;

public struct VkExportMemoryAllocateInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsNV handleTypes;

	public static VkExportMemoryAllocateInfoNV New()
	{
		VkExportMemoryAllocateInfoNV result = default(VkExportMemoryAllocateInfoNV);
		result.sType = VkStructureType.ExportMemoryAllocateInfoNV;
		return result;
	}
}
