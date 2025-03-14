using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkBufferView : IEquatable<VkBufferView>
{
	public readonly ulong Handle;

	public static VkBufferView Null => new VkBufferView(0uL);

	private string DebuggerDisplay => string.Format("VkBufferView [0x{0}]", Handle.ToString("X"));

	public VkBufferView(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkBufferView(ulong handle)
	{
		return new VkBufferView(handle);
	}

	public static bool operator ==(VkBufferView left, VkBufferView right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkBufferView left, VkBufferView right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkBufferView left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkBufferView left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkBufferView h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkBufferView h)
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
