using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkBuffer : IEquatable<VkBuffer>
{
	public readonly ulong Handle;

	public static VkBuffer Null => new VkBuffer(0uL);

	private string DebuggerDisplay => string.Format("VkBuffer [0x{0}]", Handle.ToString("X"));

	public VkBuffer(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkBuffer(ulong handle)
	{
		return new VkBuffer(handle);
	}

	public static bool operator ==(VkBuffer left, VkBuffer right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkBuffer left, VkBuffer right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkBuffer left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkBuffer left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkBuffer h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkBuffer h)
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
