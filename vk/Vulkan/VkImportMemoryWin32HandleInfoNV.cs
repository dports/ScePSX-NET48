using Vulkan.Win32;

namespace Vulkan;

public struct VkImportMemoryWin32HandleInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkExternalMemoryHandleTypeFlagsNV handleType;

	public HANDLE handle;

	public static VkImportMemoryWin32HandleInfoNV New()
	{
		VkImportMemoryWin32HandleInfoNV result = default(VkImportMemoryWin32HandleInfoNV);
		result.sType = VkStructureType.ImportMemoryWin32HandleInfoNV;
		return result;
	}
}
