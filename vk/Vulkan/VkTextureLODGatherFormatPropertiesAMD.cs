namespace Vulkan;

public struct VkTextureLODGatherFormatPropertiesAMD
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkBool32 supportsTextureGatherLODBiasAMD;

	public static VkTextureLODGatherFormatPropertiesAMD New()
	{
		VkTextureLODGatherFormatPropertiesAMD result = default(VkTextureLODGatherFormatPropertiesAMD);
		result.sType = VkStructureType.TextureLodGatherFormatPropertiesAMD;
		return result;
	}
}
