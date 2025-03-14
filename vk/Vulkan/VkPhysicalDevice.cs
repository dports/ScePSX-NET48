using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkPhysicalDevice : IEquatable<VkPhysicalDevice>
{
	public readonly IntPtr Handle;

	public static VkPhysicalDevice Null => new VkPhysicalDevice(IntPtr.Zero);

	private string DebuggerDisplay => string.Format("VkPhysicalDevice [0x{0}]", Handle.ToString("X"));

	public VkPhysicalDevice(IntPtr existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkPhysicalDevice(IntPtr handle)
	{
		return new VkPhysicalDevice(handle);
	}

	public static bool operator ==(VkPhysicalDevice left, VkPhysicalDevice right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkPhysicalDevice left, VkPhysicalDevice right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkPhysicalDevice left, IntPtr right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkPhysicalDevice left, IntPtr right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkPhysicalDevice h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkPhysicalDevice h)
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
