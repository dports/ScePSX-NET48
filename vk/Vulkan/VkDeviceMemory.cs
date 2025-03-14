using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkDeviceMemory : IEquatable<VkDeviceMemory>
{
	public readonly ulong Handle;

	public static VkDeviceMemory Null => new VkDeviceMemory(0uL);

	private string DebuggerDisplay => string.Format("VkDeviceMemory [0x{0}]", Handle.ToString("X"));

	public VkDeviceMemory(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkDeviceMemory(ulong handle)
	{
		return new VkDeviceMemory(handle);
	}

	public static bool operator ==(VkDeviceMemory left, VkDeviceMemory right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkDeviceMemory left, VkDeviceMemory right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkDeviceMemory left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkDeviceMemory left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkDeviceMemory h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkDeviceMemory h)
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
