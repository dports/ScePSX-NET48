namespace Vulkan;

public struct VkShaderModuleValidationCacheCreateInfoEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public VkValidationCacheEXT validationCache;

	public static VkShaderModuleValidationCacheCreateInfoEXT New()
	{
		VkShaderModuleValidationCacheCreateInfoEXT result = default(VkShaderModuleValidationCacheCreateInfoEXT);
		result.sType = VkStructureType.ShaderModuleValidationCacheCreateInfoEXT;
		return result;
	}
}
