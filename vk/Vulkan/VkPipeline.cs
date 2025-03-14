using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkPipeline : IEquatable<VkPipeline>
{
	public readonly ulong Handle;

	public static VkPipeline Null => new VkPipeline(0uL);

	private string DebuggerDisplay => string.Format("VkPipeline [0x{0}]", Handle.ToString("X"));

	public VkPipeline(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkPipeline(ulong handle)
	{
		return new VkPipeline(handle);
	}

	public static bool operator ==(VkPipeline left, VkPipeline right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkPipeline left, VkPipeline right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkPipeline left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkPipeline left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkPipeline h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkPipeline h)
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
