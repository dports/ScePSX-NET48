namespace Vulkan;

public struct VkInstanceCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public unsafe VkApplicationInfo* pApplicationInfo;

	public uint enabledLayerCount;

	public unsafe byte** ppEnabledLayerNames;

	public uint enabledExtensionCount;

	public unsafe byte** ppEnabledExtensionNames;

	public static VkInstanceCreateInfo New()
	{
		VkInstanceCreateInfo result = default(VkInstanceCreateInfo);
		result.sType = VkStructureType.InstanceCreateInfo;
		return result;
	}
}
