using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkIndirectCommandsLayoutNVX : IEquatable<VkIndirectCommandsLayoutNVX>
{
	public readonly ulong Handle;

	public static VkIndirectCommandsLayoutNVX Null => new VkIndirectCommandsLayoutNVX(0uL);

	private string DebuggerDisplay => string.Format("VkIndirectCommandsLayoutNVX [0x{0}]", Handle.ToString("X"));

	public VkIndirectCommandsLayoutNVX(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkIndirectCommandsLayoutNVX(ulong handle)
	{
		return new VkIndirectCommandsLayoutNVX(handle);
	}

	public static bool operator ==(VkIndirectCommandsLayoutNVX left, VkIndirectCommandsLayoutNVX right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkIndirectCommandsLayoutNVX left, VkIndirectCommandsLayoutNVX right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkIndirectCommandsLayoutNVX left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkIndirectCommandsLayoutNVX left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkIndirectCommandsLayoutNVX h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkIndirectCommandsLayoutNVX h)
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
