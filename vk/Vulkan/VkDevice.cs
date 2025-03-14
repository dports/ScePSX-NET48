using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkDevice : IEquatable<VkDevice>
{
	public readonly IntPtr Handle;

	public static VkDevice Null => new VkDevice(IntPtr.Zero);

	private string DebuggerDisplay => string.Format("VkDevice [0x{0}]", Handle.ToString("X"));

	public VkDevice(IntPtr existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkDevice(IntPtr handle)
	{
		return new VkDevice(handle);
	}

	public static bool operator ==(VkDevice left, VkDevice right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkDevice left, VkDevice right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkDevice left, IntPtr right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkDevice left, IntPtr right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkDevice h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkDevice h)
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
