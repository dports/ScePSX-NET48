using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkFence : IEquatable<VkFence>
{
	public readonly ulong Handle;

	public static VkFence Null => new VkFence(0uL);

	private string DebuggerDisplay => string.Format("VkFence [0x{0}]", Handle.ToString("X"));

	public VkFence(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkFence(ulong handle)
	{
		return new VkFence(handle);
	}

	public static bool operator ==(VkFence left, VkFence right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkFence left, VkFence right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkFence left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkFence left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkFence h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkFence h)
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
