using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkQueue : IEquatable<VkQueue>
{
	public readonly IntPtr Handle;

	public static VkQueue Null => new VkQueue(IntPtr.Zero);

	private string DebuggerDisplay => string.Format("VkQueue [0x{0}]", Handle.ToString("X"));

	public VkQueue(IntPtr existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkQueue(IntPtr handle)
	{
		return new VkQueue(handle);
	}

	public static bool operator ==(VkQueue left, VkQueue right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkQueue left, VkQueue right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkQueue left, IntPtr right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkQueue left, IntPtr right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkQueue h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkQueue h)
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
