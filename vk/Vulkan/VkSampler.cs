using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkSampler : IEquatable<VkSampler>
{
	public readonly ulong Handle;

	public static VkSampler Null => new VkSampler(0uL);

	private string DebuggerDisplay => string.Format("VkSampler [0x{0}]", Handle.ToString("X"));

	public VkSampler(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkSampler(ulong handle)
	{
		return new VkSampler(handle);
	}

	public static bool operator ==(VkSampler left, VkSampler right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkSampler left, VkSampler right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkSampler left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkSampler left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkSampler h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkSampler h)
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
