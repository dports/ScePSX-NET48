using System;

namespace ScePSX.CdRom2;

[Serializable]
public struct TrackPosition
{
	public int M;

	public int S;

	public int F;

	public TrackPosition(int m, int s, int f)
	{
		M = m;
		S = s;
		F = f;
	}

	public override string ToString()
	{
		return $"{M:D2}:{S:D2}:{F:D2}";
	}

	public int ToInt32()
	{
		return M * 60 * 75 + S * 75 + F;
	}
}
