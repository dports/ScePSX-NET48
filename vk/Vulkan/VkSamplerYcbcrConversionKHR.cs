using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkSamplerYcbcrConversionKHR : IEquatable<VkSamplerYcbcrConversionKHR>
{
	public readonly ulong Handle;

	public static VkSamplerYcbcrConversionKHR Null => new VkSamplerYcbcrConversionKHR(0uL);

	private string DebuggerDisplay => string.Format("VkSamplerYcbcrConversionKHR [0x{0}]", Handle.ToString("X"));

	public VkSamplerYcbcrConversionKHR(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkSamplerYcbcrConversionKHR(ulong handle)
	{
		return new VkSamplerYcbcrConversionKHR(handle);
	}

	public static bool operator ==(VkSamplerYcbcrConversionKHR left, VkSamplerYcbcrConversionKHR right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkSamplerYcbcrConversionKHR left, VkSamplerYcbcrConversionKHR right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkSamplerYcbcrConversionKHR left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkSamplerYcbcrConversionKHR left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkSamplerYcbcrConversionKHR h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkSamplerYcbcrConversionKHR h)
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
