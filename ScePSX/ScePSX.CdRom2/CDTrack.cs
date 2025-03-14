using System;
using System.Collections.Generic;

namespace ScePSX.CdRom2;

[Serializable]
public class CDTrack
{
	public string File;

	public long FilePosition;

	public long FileLength;

	public byte Index;

	public int LbaStart;

	public int LbaEnd;

	public int LbaLength;

	public IList<TrackIndex> Indices { get; } = new List<TrackIndex>();

	public CDTrack()
	{
	}

	public CDTrack(string file, long fileLength, byte index, int lbaStart, int lbaEnd)
	{
		File = file;
		FileLength = fileLength;
		Index = index;
		LbaStart = lbaStart;
		LbaEnd = lbaEnd;
	}

	public override string ToString()
	{
		return $"{"Index"}: {Index}, {"LbaStart"}: {LbaStart}, {"LbaEnd"}: {LbaEnd}, {"LbaLength"}: {LbaLength}, {"Indices"}: {Indices.Count}, {"FilePosition"}: {FilePosition}";
	}
}
