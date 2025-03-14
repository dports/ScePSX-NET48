namespace Vulkan;

public struct VkPipelineCoverageModulationStateCreateInfoNV
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public VkCoverageModulationModeNV coverageModulationMode;

	public VkBool32 coverageModulationTableEnable;

	public uint coverageModulationTableCount;

	public unsafe float* pCoverageModulationTable;

	public static VkPipelineCoverageModulationStateCreateInfoNV New()
	{
		VkPipelineCoverageModulationStateCreateInfoNV result = default(VkPipelineCoverageModulationStateCreateInfoNV);
		result.sType = VkStructureType.PipelineCoverageModulationStateCreateInfoNV;
		return result;
	}
}
