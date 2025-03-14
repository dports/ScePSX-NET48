using System;
using System.Diagnostics;

namespace Vulkan;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct VkDebugReportCallbackEXT : IEquatable<VkDebugReportCallbackEXT>
{
	public readonly ulong Handle;

	public static VkDebugReportCallbackEXT Null => new VkDebugReportCallbackEXT(0uL);

	private string DebuggerDisplay => string.Format("VkDebugReportCallbackEXT [0x{0}]", Handle.ToString("X"));

	public VkDebugReportCallbackEXT(ulong existingHandle)
	{
		Handle = existingHandle;
	}

	public static implicit operator VkDebugReportCallbackEXT(ulong handle)
	{
		return new VkDebugReportCallbackEXT(handle);
	}

	public static bool operator ==(VkDebugReportCallbackEXT left, VkDebugReportCallbackEXT right)
	{
		return left.Handle == right.Handle;
	}

	public static bool operator !=(VkDebugReportCallbackEXT left, VkDebugReportCallbackEXT right)
	{
		return left.Handle != right.Handle;
	}

	public static bool operator ==(VkDebugReportCallbackEXT left, ulong right)
	{
		return left.Handle == right;
	}

	public static bool operator !=(VkDebugReportCallbackEXT left, ulong right)
	{
		return left.Handle != right;
	}

	public bool Equals(VkDebugReportCallbackEXT h)
	{
		return Handle == h.Handle;
	}

	public override bool Equals(object o)
	{
		if (o is VkDebugReportCallbackEXT h)
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
