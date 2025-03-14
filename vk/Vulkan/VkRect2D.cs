using System;

namespace Vulkan;

public struct VkRect2D : IEquatable<VkRect2D>
{
	public VkOffset2D offset;

	public VkExtent2D extent;

	public static readonly VkRect2D Zero = new VkRect2D(VkOffset2D.Zero, VkExtent2D.Zero);

	public VkRect2D(VkOffset2D offset, VkExtent2D extent)
	{
		this.offset = offset;
		this.extent = extent;
	}

	public VkRect2D(VkExtent2D extent)
	{
		offset = default(VkOffset2D);
		this.extent = extent;
	}

	public VkRect2D(int x, int y, uint width, uint height)
	{
		offset = new VkOffset2D(x, y);
		extent = new VkExtent2D(width, height);
	}

	public VkRect2D(int x, int y, int width, int height)
	{
		offset = new VkOffset2D(x, y);
		extent = new VkExtent2D(width, height);
	}

	public VkRect2D(uint width, uint height)
	{
		offset = default(VkOffset2D);
		extent = new VkExtent2D(width, height);
	}

	public bool Equals(ref VkRect2D other)
	{
		if (other.offset.Equals(ref offset))
		{
			return other.extent.Equals(ref extent);
		}
		return false;
	}

	public bool Equals(VkRect2D other)
	{
		return Equals(ref other);
	}

	public override bool Equals(object obj)
	{
		if (obj is VkRect2D)
		{
			return Equals((VkRect2D)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (extent.GetHashCode() * 397) ^ offset.GetHashCode();
	}

	public static bool operator ==(VkRect2D left, VkRect2D right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(VkRect2D left, VkRect2D right)
	{
		return !left.Equals(right);
	}
}
