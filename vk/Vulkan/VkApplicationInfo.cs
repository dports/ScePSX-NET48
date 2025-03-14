namespace Vulkan;

public struct VkApplicationInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public unsafe byte* pApplicationName;

	public uint applicationVersion;

	public unsafe byte* pEngineName;

	public uint engineVersion;

	public uint apiVersion;

	public static VkApplicationInfo New()
	{
		VkApplicationInfo result = default(VkApplicationInfo);
		result.sType = VkStructureType.ApplicationInfo;
		return result;
	}
}
