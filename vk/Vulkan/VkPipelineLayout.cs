using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkPipelineLayout : IEquatable<VkPipelineLayout>
{
	public readonly ulong Handle;

	public static VkPipelineLayout Null => new VkPipelineLayout(0uL);

	private string DebuggerDisplay => string.Format("VkPipelineLayout [0x{0}]", Handle.ToString("X"));

	public VkPipelineLayout(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkPipelineLayout(ulong handle)
	{
		return new VkPipelineLayout(handle);
	}

	public static bool operator ==(VkPipelineLayout left, VkPipelineLayout right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkPipelineLayout left, VkPipelineLayout right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkPipelineLayout left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkPipelineLayout left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkPipelineLayout h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkPipelineLayout h)
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
