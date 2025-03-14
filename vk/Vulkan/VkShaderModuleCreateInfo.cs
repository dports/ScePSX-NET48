using System;

namespace Vulkan;

public struct VkShaderModuleCreateInfo
{
	public VkStructureType sType;

	public unsafe void* pNext;

	public uint flags;

	public UIntPtr codeSize;

	public unsafe uint* pCode;

	public static VkShaderModuleCreateInfo New()
	{
		VkShaderModuleCreateInfo result = default(VkShaderModuleCreateInfo);
		result.sType = VkStructureType.ShaderModuleCreateInfo;
		return result;
	}
}
