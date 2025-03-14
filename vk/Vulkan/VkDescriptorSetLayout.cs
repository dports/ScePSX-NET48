using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkDescriptorSetLayout : IEquatable<VkDescriptorSetLayout>
{
	public readonly ulong Handle;

	public static VkDescriptorSetLayout Null => new VkDescriptorSetLayout(0uL);

	private string DebuggerDisplay => string.Format("VkDescriptorSetLayout [0x{0}]", Handle.ToString("X"));

	public VkDescriptorSetLayout(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkDescriptorSetLayout(ulong handle)
	{
		return new VkDescriptorSetLayout(handle);
	}

	public static bool operator ==(VkDescriptorSetLayout left, VkDescriptorSetLayout right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkDescriptorSetLayout left, VkDescriptorSetLayout right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkDescriptorSetLayout left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkDescriptorSetLayout left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkDescriptorSetLayout h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkDescriptorSetLayout h)
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
