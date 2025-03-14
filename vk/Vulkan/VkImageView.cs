using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkImageView : IEquatable<VkImageView>
{
	public readonly ulong Handle;

	public static VkImageView Null => new VkImageView(0uL);

	private string DebuggerDisplay => string.Format("VkImageView [0x{0}]", Handle.ToString("X"));

	public VkImageView(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkImageView(ulong handle)
	{
		return new VkImageView(handle);
	}

	public static bool operator ==(VkImageView left, VkImageView right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkImageView left, VkImageView right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkImageView left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkImageView left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkImageView h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkImageView h)
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
