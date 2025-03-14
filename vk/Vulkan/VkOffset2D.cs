using System;

namespace Vulkan;

public struct VkOffset2D : IEquatable<VkOffset2D>
{
	public int x;

	public int y;

	public static readonly VkOffset2D Zero;

	public VkOffset2D(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public bool Equals(ref VkOffset2D other)
	{
		if (other.x == x)
		{
			return other.y == y;
		}
		return false;
	}

	public bool Equals(VkOffset2D other)
	{
		return Equals(ref other);
	}

	public override bool Equals(object obj)
	{
		if (obj is VkOffset2D)
		{
			return Equals((VkOffset2D)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (x * 397) ^ y;
	}

	public static bool operator ==(VkOffset2D left, VkOffset2D right)
	{
		return left.Equals(ref right);
	}

	public static bool operator !=(VkOffset2D left, VkOffset2D right)
	{
		return !left.Equals(ref right);
	}
}
