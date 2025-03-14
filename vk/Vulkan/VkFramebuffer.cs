using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkFramebuffer : IEquatable<VkFramebuffer>
{
	public readonly ulong Handle;

	public static VkFramebuffer Null => new VkFramebuffer(0uL);

	private string DebuggerDisplay => string.Format("VkFramebuffer [0x{0}]", Handle.ToString("X"));

	public VkFramebuffer(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkFramebuffer(ulong handle)
	{
		return new VkFramebuffer(handle);
	}

	public static bool operator ==(VkFramebuffer left, VkFramebuffer right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkFramebuffer left, VkFramebuffer right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkFramebuffer left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkFramebuffer left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkFramebuffer h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkFramebuffer h)
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
