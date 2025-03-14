using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkValidationCacheEXT : IEquatable<VkValidationCacheEXT>
{
	public readonly ulong Handle;

	public static VkValidationCacheEXT Null => new VkValidationCacheEXT(0uL);

	private string DebuggerDisplay => string.Format("VkValidationCacheEXT [0x{0}]", Handle.ToString("X"));

	public VkValidationCacheEXT(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkValidationCacheEXT(ulong handle)
	{
		return new VkValidationCacheEXT(handle);
	}

	public static bool operator ==(VkValidationCacheEXT left, VkValidationCacheEXT right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkValidationCacheEXT left, VkValidationCacheEXT right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkValidationCacheEXT left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkValidationCacheEXT left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkValidationCacheEXT h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkValidationCacheEXT h)
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
