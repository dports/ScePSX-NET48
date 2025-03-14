using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkSurfaceKHR : IEquatable<VkSurfaceKHR>
{
	public readonly ulong Handle;

	public static VkSurfaceKHR Null => new VkSurfaceKHR(0uL);

	private string DebuggerDisplay => string.Format("VkSurfaceKHR [0x{0}]", Handle.ToString("X"));

	public VkSurfaceKHR(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkSurfaceKHR(ulong handle)
	{
		return new VkSurfaceKHR(handle);
	}

	public static bool operator ==(VkSurfaceKHR left, VkSurfaceKHR right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkSurfaceKHR left, VkSurfaceKHR right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkSurfaceKHR left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkSurfaceKHR left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkSurfaceKHR h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkSurfaceKHR h)
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
