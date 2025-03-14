namespace Vulkan;

public struct VkClearDepthStencilValue
{
	public float depth;

	public uint stencil;

	public VkClearDepthStencilValue(float depth, uint stencil)
	{
		this.depth = depth;
		this.stencil = stencil;
	}
}
