namespace Vulkan;

public struct VkNativeBufferANDROID
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public unsafe void* handle;

	public int stride;

	public int format;

	public int usage;

	public static VkNativeBufferANDROID New()
	{
		VkNativeBufferANDROID result = default(VkNativeBufferANDROID);
		result.sType = VkStructureType.NativeBufferAndroid;
		return result;
	}
}
