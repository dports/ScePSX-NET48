using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkDescriptorSet : IEquatable<VkDescriptorSet>
{
	public readonly ulong Handle;

	public static VkDescriptorSet Null => new VkDescriptorSet(0uL);

	private string DebuggerDisplay => string.Format("VkDescriptorSet [0x{0}]", Handle.ToString("X"));

	public VkDescriptorSet(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkDescriptorSet(ulong handle)
	{
		return new VkDescriptorSet(handle);
	}

	public static bool operator ==(VkDescriptorSet left, VkDescriptorSet right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkDescriptorSet left, VkDescriptorSet right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkDescriptorSet left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkDescriptorSet left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkDescriptorSet h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkDescriptorSet h)
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
