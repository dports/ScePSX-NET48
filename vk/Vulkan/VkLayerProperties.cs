namespace Vulkan;

public struct VkLayerProperties
{
	public unsafe fixed byte layerName[256];

	public uint specVersion;

	public uint implementationVersion;

	public unsafe fixed byte description[256];
}
