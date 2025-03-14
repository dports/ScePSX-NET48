namespace Vulkan;

public struct VkPastPresentationTimingGOOGLE
{
	public uint presentID;

	public ulong desiredPresentTime;

	public ulong actualPresentTime;

	public ulong earliestPresentTime;

	public ulong presentMargin;
}
