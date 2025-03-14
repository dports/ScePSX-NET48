using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkDisplayModeKHR : IEquatable<VkDisplayModeKHR>
{
	public readonly ulong Handle;

	public static VkDisplayModeKHR Null => new VkDisplayModeKHR(0uL);

	private string DebuggerDisplay => string.Format("VkDisplayModeKHR [0x{0}]", Handle.ToString("X"));

	public VkDisplayModeKHR(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkDisplayModeKHR(ulong handle)
	{
		return new VkDisplayModeKHR(handle);
	}

	public static bool operator ==(VkDisplayModeKHR left, VkDisplayModeKHR right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkDisplayModeKHR left, VkDisplayModeKHR right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkDisplayModeKHR left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkDisplayModeKHR left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkDisplayModeKHR h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkDisplayModeKHR h)
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
