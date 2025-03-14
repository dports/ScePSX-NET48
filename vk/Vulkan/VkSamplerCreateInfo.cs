namespace Vulkan;

public struct VkSamplerCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkFilter magFilter;

	public VkFilter minFilter;

	public VkSamplerMipmapMode mipmapMode;

	public VkSamplerAddressMode addressModeU;

	public VkSamplerAddressMode addressModeV;

	public VkSamplerAddressMode addressModeW;

	public float mipLodBias;

	public VkBool32 anisotropyEnable;

	public float maxAnisotropy;

	public VkBool32 compareEnable;

	public VkCompareOp compareOp;

	public float minLod;

	public float maxLod;

	public VkBorderColor borderColor;

	public VkBool32 unnormalizedCoordinates;

	public static VkSamplerCreateInfo New()
	{
		VkSamplerCreateInfo result = default(VkSamplerCreateInfo);
		result.sType = VkStructureType.SamplerCreateInfo;
		return result;
	}
}
