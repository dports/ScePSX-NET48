using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkDescriptorUpdateTemplateKHR : IEquatable<VkDescriptorUpdateTemplateKHR>
{
	public readonly ulong Handle;

	public static VkDescriptorUpdateTemplateKHR Null => new VkDescriptorUpdateTemplateKHR(0uL);

	private string DebuggerDisplay => string.Format("VkDescriptorUpdateTemplateKHR [0x{0}]", Handle.ToString("X"));

	public VkDescriptorUpdateTemplateKHR(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkDescriptorUpdateTemplateKHR(ulong handle)
	{
		return new VkDescriptorUpdateTemplateKHR(handle);
	}

	public static bool operator ==(VkDescriptorUpdateTemplateKHR left, VkDescriptorUpdateTemplateKHR right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkDescriptorUpdateTemplateKHR left, VkDescriptorUpdateTemplateKHR right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkDescriptorUpdateTemplateKHR left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkDescriptorUpdateTemplateKHR left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkDescriptorUpdateTemplateKHR h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkDescriptorUpdateTemplateKHR h)
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
