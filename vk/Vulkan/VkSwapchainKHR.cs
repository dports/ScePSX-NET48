using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkSwapchainKHR : IEquatable<VkSwapchainKHR>
{
	public readonly ulong Handle;

	public static VkSwapchainKHR Null => new VkSwapchainKHR(0uL);

	private string DebuggerDisplay => string.Format("VkSwapchainKHR [0x{0}]", Handle.ToString("X"));

	public VkSwapchainKHR(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkSwapchainKHR(ulong handle)
	{
		return new VkSwapchainKHR(handle);
	}

	public static bool operator ==(VkSwapchainKHR left, VkSwapchainKHR right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkSwapchainKHR left, VkSwapchainKHR right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkSwapchainKHR left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkSwapchainKHR left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkSwapchainKHR h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkSwapchainKHR h)
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
