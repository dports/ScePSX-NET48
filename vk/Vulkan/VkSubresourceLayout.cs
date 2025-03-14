namespace Vulkan;

public struct VkSubresourceLayout
{
	public ulong offset;

	public ulong size;

	public ulong rowPitch;

	public ulong arrayPitch;

	public ulong depthPitch;
}
