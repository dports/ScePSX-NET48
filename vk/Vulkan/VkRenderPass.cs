using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkRenderPass : IEquatable<VkRenderPass>
{
	public readonly ulong Handle;

	public static VkRenderPass Null => new VkRenderPass(0uL);

	private string DebuggerDisplay => string.Format("VkRenderPass [0x{0}]", Handle.ToString("X"));

	public VkRenderPass(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkRenderPass(ulong handle)
	{
		return new VkRenderPass(handle);
	}

	public static bool operator ==(VkRenderPass left, VkRenderPass right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkRenderPass left, VkRenderPass right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkRenderPass left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkRenderPass left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkRenderPass h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkRenderPass h)
		{
			return Equals(h);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Handle.GetHashCode();
	}
}
