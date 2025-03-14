namespace Vulkan;

public struct VkExtensionProperties
{
	public unsafe fixed byte extensionName[256];

	public uint specVersion;
}
