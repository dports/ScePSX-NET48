using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkDescriptorPool : IEquatable<VkDescriptorPool>
{
	public readonly ulong Handle;

	public static VkDescriptorPool Null => new VkDescriptorPool(0uL);

	private string DebuggerDisplay => string.Format("VkDescriptorPool [0x{0}]", Handle.ToString("X"));

	public VkDescriptorPool(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkDescriptorPool(ulong handle)
	{
		return new VkDescriptorPool(handle);
	}

	public static bool operator ==(VkDescriptorPool left, VkDescriptorPool right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkDescriptorPool left, VkDescriptorPool right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkDescriptorPool left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkDescriptorPool left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkDescriptorPool h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkDescriptorPool h)
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
