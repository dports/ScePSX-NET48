using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkDisplayKHR : IEquatable<VkDisplayKHR>
{
	public readonly ulong Handle;

	public static VkDisplayKHR Null => new VkDisplayKHR(0uL);

	private string DebuggerDisplay => string.Format("VkDisplayKHR [0x{0}]", Handle.ToString("X"));

	public VkDisplayKHR(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkDisplayKHR(ulong handle)
	{
		return new VkDisplayKHR(handle);
	}

	public static bool operator ==(VkDisplayKHR left, VkDisplayKHR right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkDisplayKHR left, VkDisplayKHR right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkDisplayKHR left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkDisplayKHR left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkDisplayKHR h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkDisplayKHR h)
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
