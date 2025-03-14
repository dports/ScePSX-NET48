using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkCommandBuffer : IEquatable<VkCommandBuffer>
{
	public readonly IntPtr Handle;

	public static VkCommandBuffer Null => new VkCommandBuffer(IntPtr.Zero);

	private string DebuggerDisplay => string.Format("VkCommandBuffer [0x{0}]", Handle.ToString("X"));

	public VkCommandBuffer(IntPtr existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkCommandBuffer(IntPtr handle)
	{
		return new VkCommandBuffer(handle);
	}

	public static bool operator ==(VkCommandBuffer left, VkCommandBuffer right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkCommandBuffer left, VkCommandBuffer right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkCommandBuffer left, IntPtr right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkCommandBuffer left, IntPtr right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkCommandBuffer h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkCommandBuffer h)
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
