using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkImage : IEquatable<VkImage>
{
	public readonly ulong Handle;

	public static VkImage Null => new VkImage(0uL);

	private string DebuggerDisplay => string.Format("VkImage [0x{0}]", Handle.ToString("X"));

	public VkImage(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkImage(ulong handle)
	{
		return new VkImage(handle);
	}

	public static bool operator ==(VkImage left, VkImage right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkImage left, VkImage right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkImage left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkImage left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkImage h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkImage h)
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
