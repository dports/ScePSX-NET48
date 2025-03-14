using System;

namespace ScePSX.CdRom2;

[Serializable]
public struct TrackIndex
{
	public int Number;

	public TrackPosition Position;

	public TrackIndex(int number, TrackPosition position)
	{
		Number = number;
		Position = position;
	}

	public override string ToString()
	{
		return $"{"Number"}: {Number}, {"Position"}: {Position}";
	}
}
