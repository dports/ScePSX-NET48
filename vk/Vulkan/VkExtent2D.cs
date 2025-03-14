using System;

namespace Vulkan;

public struct VkExtent2D : IEquatable<VkExtent2D>
{
	public uint width;

	public uint height;

	public static readonly VkExtent2D Zero = new VkExtent2D(0, 0);

	public VkExtent2D(uint width, uint height)
	{
		this.width = width;
		this.height = height;
	}

	public VkExtent2D(int width, int height)
	{
		this.width = (uint)width;
		this.height = (uint)height;
	}

	public bool Equals(ref VkExtent2D other)
	{
		if (other.width == width)
		{
			return other.height == height;
		}
		return false;
	}

	public bool Equals(VkExtent2D other)
	{
		return Equals(ref other);
	}

	public override bool Equals(object obj)
	{
		if (obj is VkExtent2D)
		{
			return Equals((VkExtent2D)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (width.GetHashCode() * 397) ^ height.GetHashCode();
	}

	public static bool operator ==(VkExtent2D left, VkExtent2D right)
	{
		return left.Equals(ref right);
	}

	public static bool operator !=(VkExtent2D left, VkExtent2D right)
	{
		return !left.Equals(ref right);
	}
}
