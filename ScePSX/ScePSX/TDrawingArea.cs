using System;

namespace ScePSX;

[Serializable]
public struct TDrawingArea : IEquatable<TDrawingArea>
{
	public ushort X;

	public ushort Y;

	public TDrawingArea(uint value)
	{
		X = (ushort)(value & 0x3FF);
		Y = (ushort)((value >> 10) & 0x1FF);
	}

	public override string ToString()
	{
		return $"{"X"}: {X}, {"Y"}: {Y}";
	}

	public bool Equals(TDrawingArea other)
	{
		if (X == other.X)
		{
			return Y == other.Y;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is TDrawingArea other)
		{
			return Equals(other);
		}
		return false;
	}

    public override int GetHashCode()
    {
        unchecked // Для игнорирования переполнения
        {
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }
    }

    public static bool operator ==(TDrawingArea left, TDrawingArea right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(TDrawingArea left, TDrawingArea right)
	{
		return !left.Equals(right);
	}
}
