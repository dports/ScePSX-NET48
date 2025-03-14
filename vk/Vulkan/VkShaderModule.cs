using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkShaderModule : IEquatable<VkShaderModule>
{
	public readonly ulong Handle;

	public static VkShaderModule Null => new VkShaderModule(0uL);

	private string DebuggerDisplay => string.Format("VkShaderModule [0x{0}]", Handle.ToString("X"));

	public VkShaderModule(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkShaderModule(ulong handle)
	{
		return new VkShaderModule(handle);
	}

	public static bool operator ==(VkShaderModule left, VkShaderModule right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkShaderModule left, VkShaderModule right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkShaderModule left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkShaderModule left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkShaderModule h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkShaderModule h)
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
