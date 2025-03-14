using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkCommandPool : IEquatable<VkCommandPool>
{
	public readonly ulong Handle;

	public static VkCommandPool Null => new VkCommandPool(0uL);

	private string DebuggerDisplay => string.Format("VkCommandPool [0x{0}]", Handle.ToString("X"));

	public VkCommandPool(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkCommandPool(ulong handle)
	{
		return new VkCommandPool(handle);
	}

	public static bool operator ==(VkCommandPool left, VkCommandPool right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkCommandPool left, VkCommandPool right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkCommandPool left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkCommandPool left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkCommandPool h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkCommandPool h)
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
