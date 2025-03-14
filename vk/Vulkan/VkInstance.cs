using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkInstance : IEquatable<VkInstance>
{
	public readonly IntPtr Handle;

	public static VkInstance Null => new VkInstance(IntPtr.Zero);

	private string DebuggerDisplay => string.Format("VkInstance [0x{0}]", Handle.ToString("X"));

	public VkInstance(IntPtr existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkInstance(IntPtr handle)
	{
		return new VkInstance(handle);
	}

	public static bool operator ==(VkInstance left, VkInstance right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkInstance left, VkInstance right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkInstance left, IntPtr right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkInstance left, IntPtr right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkInstance h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkInstance h)
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
