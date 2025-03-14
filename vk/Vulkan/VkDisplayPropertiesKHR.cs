namespace Vulkan;

public struct VkDisplayPropertiesKHR
{
	public VkDisplayKHR display;

	public unsafe byte* displayName;

	public VkExtent2D physicalDimensions;

	public VkExtent2D physicalResolution;

	public VkSurfaceTransformFlagsKHR supportedTransforms;

	public VkBool32 planeReorderPossible;

	public VkBool32 persistentContent;
}
