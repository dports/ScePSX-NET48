using System;

namespace Vulkan;

public struct VkBool32 : IEquatable<VkBool32>
{
	public uint Value;

	public static readonly VkBool32 True = new VkBool32(1u);

	public static readonly VkBool32 False = new VkBool32(0u);

	public VkBool32(uint value)
	{
		Value = value;
	}

	public bool Equals(VkBool32 other)
	{
		return Value.Equals(other.Value);
	}

	public override bool Equals(object obj)
	{
		if (obj is VkBool32 other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format("{0} ({1})", this ? "True" : "False", Value);
	}

	public static implicit operator bool(VkBool32 b)
	{
		return b.Value != 0;
	}

	public static implicit operator uint(VkBool32 b)
	{
		return b.Value;
	}

	public static implicit operator VkBool32(bool b)
	{
		if (!b)
		{
			return False;
		}
		return True;
	}

	public static implicit operator VkBool32(uint value)
	{
		return new VkBool32(value);
	}

	public static bool operator ==(VkBool32 left, VkBool32 right)
	{
		return left.Value == right.Value;
	}

	public static bool operator !=(VkBool32 left, VkBool32 right)
	{
		return left.Value != right.Value;
	}
}
