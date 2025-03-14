using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkSemaphore : IEquatable<VkSemaphore>
{
	public readonly ulong Handle;

	public static VkSemaphore Null => new VkSemaphore(0uL);

	private string DebuggerDisplay => string.Format("VkSemaphore [0x{0}]", Handle.ToString("X"));

	public VkSemaphore(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkSemaphore(ulong handle)
	{
		return new VkSemaphore(handle);
	}

	public static bool operator ==(VkSemaphore left, VkSemaphore right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkSemaphore left, VkSemaphore right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkSemaphore left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkSemaphore left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkSemaphore h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkSemaphore h)
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
