using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkQueryPool : IEquatable<VkQueryPool>
{
	public readonly ulong Handle;

	public static VkQueryPool Null => new VkQueryPool(0uL);

	private string DebuggerDisplay => string.Format("VkQueryPool [0x{0}]", Handle.ToString("X"));

	public VkQueryPool(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkQueryPool(ulong handle)
	{
		return new VkQueryPool(handle);
	}

	public static bool operator ==(VkQueryPool left, VkQueryPool right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkQueryPool left, VkQueryPool right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkQueryPool left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkQueryPool left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkQueryPool h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkQueryPool h)
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
