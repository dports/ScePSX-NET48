using System;

namespace Vulkan;

public struct VkDebugReportCallbackCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkDebugReportFlagsEXT flags;

	public IntPtr pfnCallback;

	public unsafe void* pUserData;

	public static VkDebugReportCallbackCreateInfoEXT New()
	{
		VkDebugReportCallbackCreateInfoEXT result = default(VkDebugReportCallbackCreateInfoEXT);
		result.sType = VkStructureType.DebugReportCallbackCreateInfoEXT;
		return result;
	}
}
