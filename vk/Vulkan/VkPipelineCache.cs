using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkPipelineCache : IEquatable<VkPipelineCache>
{
	public readonly ulong Handle;

	public static VkPipelineCache Null => new VkPipelineCache(0uL);

	private string DebuggerDisplay => string.Format("VkPipelineCache [0x{0}]", Handle.ToString("X"));

	public VkPipelineCache(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkPipelineCache(ulong handle)
	{
		return new VkPipelineCache(handle);
	}

	public static bool operator ==(VkPipelineCache left, VkPipelineCache right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkPipelineCache left, VkPipelineCache right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkPipelineCache left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkPipelineCache left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkPipelineCache h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkPipelineCache h)
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
