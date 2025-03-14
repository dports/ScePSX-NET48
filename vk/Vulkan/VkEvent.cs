using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkEvent : IEquatable<VkEvent>
{
	public readonly ulong Handle;

	public static VkEvent Null => new VkEvent(0uL);

	private string DebuggerDisplay => string.Format("VkEvent [0x{0}]", Handle.ToString("X"));

	public VkEvent(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkEvent(ulong handle)
	{
		return new VkEvent(handle);
	}

	public static bool operator ==(VkEvent left, VkEvent right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkEvent left, VkEvent right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkEvent left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkEvent left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkEvent h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkEvent h)
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
