using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkObjectTableNVX : IEquatable<VkObjectTableNVX>
{
	public readonly ulong Handle;

	public static VkObjectTableNVX Null => new VkObjectTableNVX(0uL);

	private string DebuggerDisplay => string.Format("VkObjectTableNVX [0x{0}]", Handle.ToString("X"));

	public VkObjectTableNVX(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkObjectTableNVX(ulong handle)
	{
		return new VkObjectTableNVX(handle);
	}

	public static bool operator ==(VkObjectTableNVX left, VkObjectTableNVX right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkObjectTableNVX left, VkObjectTableNVX right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkObjectTableNVX left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkObjectTableNVX left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkObjectTableNVX h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkObjectTableNVX h)
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
