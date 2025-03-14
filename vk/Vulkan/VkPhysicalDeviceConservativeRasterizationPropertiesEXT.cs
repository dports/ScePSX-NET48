namespace Vulkan;

public struct VkPhysicalDeviceConservativeRasterizationPropertiesEXT
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public float primitiveOverestimationSize;

	public float maxExtraPrimitiveOverestimationSize;

	public float extraPrimitiveOverestimationSizeGranularity;

	public VkBool32 primitiveUnderestimation;

	public VkBool32 conservativePointAndLineRasterization;

	public VkBool32 degenerateTrianglesRasterized;

	public VkBool32 degenerateLinesRasterized;

	public VkBool32 fullyCoveredFragmentShaderInputVariable;

	public VkBool32 conservativeRasterizationPostDepthCoverage;

	public static VkPhysicalDeviceConservativeRasterizationPropertiesEXT New()
	{
		VkPhysicalDeviceConservativeRasterizationPropertiesEXT result = default(VkPhysicalDeviceConservativeRasterizationPropertiesEXT);
		result.sType = VkStructureType.PhysicalDeviceConservativeRasterizationPropertiesEXT;
		return result;
	}
}
