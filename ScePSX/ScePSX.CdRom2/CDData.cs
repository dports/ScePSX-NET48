using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ScePSX.CdRom2;

[Serializable]
public class CDData
{
	private const int BYTES_PER_SECTOR_RAW = 2352;

	private const int PRE_GAP = 150;

	private byte[] rawSectorBuffer = new byte[2352];

	[NonSerialized]
	private FileStream[] streams;

	public bool isTrackChange;

	public List<CDTrack> tracks;

	public bool isCue;

	public string DiskID = "";

	public CDData(string diskFilename, string diskid = "")
	{
		Console.ForegroundColor = ConsoleColor.Yellow;
		switch (Path.GetExtension(diskFilename))
		{
		default:
			return;
		case ".bin":
		case ".iso":
			isCue = false;
			tracks = FromBin(diskFilename);
			break;
		case ".cue":
			isCue = true;
			tracks = FromCue(diskFilename);
			break;
		}
		if (diskid != "")
		{
			DiskID = diskid;
		}
		streams = new FileStream[tracks.Count];
		for (int i = 0; i < tracks.Count; i++)
		{
			streams[i] = new FileStream(tracks[i].File, FileMode.Open, FileAccess.Read);
			if (DiskID == "")
			{
				try
				{
					if (Path.GetExtension(tracks[i].File) == ".img")
					{
						DiskID = $"{CalcCRC32(tracks[i].File):X8}";
					}
					else
					{
						DiskID = ReadDiscId(tracks[i].File);
					}
				}
				catch
				{
					return;
				}
			}
			Console.WriteLine($"[CDROM] Track [{i}] {Path.GetFileName(tracks[i].File)} {tracks[i].FileLength / 1024} KB, LBA {tracks[i].LbaStart} - {tracks[i].LbaEnd}");
		}
		Console.ResetColor();
	}

	public void LoadFileStream()
	{
		streams = new FileStream[tracks.Count];
		for (int i = 0; i < tracks.Count; i++)
		{
			streams[i] = new FileStream(tracks[i].File, FileMode.Open, FileAccess.Read);
		}
	}

	public byte[] Read(int loc)
	{
		CDTrack trackFromLoc = getTrackFromLoc(loc);
		int num = loc - trackFromLoc.LbaStart;
		if (num < 0)
		{
			num = 0;
		}
		FileStream fileStream = streams[trackFromLoc.Index - 1];
		if (isCue && num >= 150)
		{
			num -= 150;
			if (trackFromLoc.Indices.Count > 1)
			{
				num += 150;
			}
		}
		num = (int)(num * 2352 + trackFromLoc.FilePosition);
		fileStream.Seek(num, SeekOrigin.Begin);
		int num2 = rawSectorBuffer.Length;
		int num3 = fileStream.Read(rawSectorBuffer, 0, num2);
		if (num3 != num2)
		{
			Console.WriteLine($"[CDROM] ERROR: Could only read {num3} of {num2} bytes from {fileStream.Name}.");
		}
		return rawSectorBuffer;
	}

	public CDTrack getTrackFromLoc(int loc)
	{
		foreach (CDTrack track in tracks)
		{
			isTrackChange = loc == track.LbaEnd;
			if (track.LbaEnd >= loc)
			{
				return track;
			}
		}
		Console.WriteLine("[CDROM] WARNING: LBA beyond tracks!");
		return tracks[0];
	}

	public int getLBA()
	{
		int num = 150;
		foreach (CDTrack track in tracks)
		{
			num += track.LbaLength;
		}
		Console.WriteLine($"[CDROM] LBA: {num:x8}");
		return num;
	}

	public static string ReadDiscId(string filePath)
	{
		using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
		var (num, num2) = FindSystemCnfMetadata(fileStream);
		if (num == 0)
		{
			return "";
		}
		int num3 = 0;
		long length = fileStream.Length;
		if (length % 2352 == 0L)
		{
			num3 = 2352;
		}
		if (length % 2048 == 0L)
		{
			num3 = 2048;
		}
		int num4;
		switch (num3)
		{
		case 0:
			return "";
		default:
			num4 = 0;
			break;
		case 2352:
			num4 = 16;
			break;
		}
		int num5 = num4;
		long offset = num * num3 + num5;
		fileStream.Seek(offset, SeekOrigin.Begin);
		byte[] array = new byte[num2];
		if (fileStream.Read(array, 0, (int)num2) != num2)
		{
			return "";
		}
		string[] array2 = Encoding.ASCII.GetString(array).Split(new char[3] { '\0', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in array2)
		{
			if (text.Trim().StartsWith("BOOT", StringComparison.OrdinalIgnoreCase))
			{
				Match match = Regex.Match(text, "(?i)[\\\\:]([A-Z]{4}_\\d{3}\\.\\d{2})");
				if (match.Success)
				{
                    string[] array3 = match.Groups[1].Value.Split('.');
                    return (array3[0] + array3[1]).Replace("_", "-");
				}
			}
		}
		return "";
	}

	private static (uint Lba, uint Size) FindSystemCnfMetadata(FileStream fs)
	{
		byte[] array = new byte[1048576];
		int num2;
		for (long num = 0L; num < fs.Length; num += num2)
		{
			num2 = fs.Read(array, 0, array.Length);
			for (int i = 0; i < num2 - 64; i++)
			{
				int num3 = array[i];
				if (num3 != 0 && i + num3 <= num2)
				{
					int num4 = array[i + 32];
					if (num4 >= 11 && Encoding.ASCII.GetString(array, i + 33, num4).Split(';')[0].Trim().ToUpper() == "SYSTEM.CNF")
					{
						uint item = BitConverter.ToUInt32(array, i + 2);
						uint item2 = BitConverter.ToUInt32(array, i + 10);
						return (Lba: item, Size: item2);
					}
				}
			}
		}
		return (Lba: 0u, Size: 0u);
	}

	public static uint CalcCRC32(string filename)
	{
		uint[] array = new uint[256];
		for (uint num = 0u; num < 256; num++)
		{
			uint num2 = num;
			for (int i = 0; i < 8; i++)
			{
				num2 = (((num2 & 1) != 1) ? (num2 >> 1) : ((num2 >> 1) ^ 0xEDB88320u));
			}
			array[num] = num2;
		}
		uint num3 = uint.MaxValue;
		using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
		{
			byte[] array2 = new byte[4096];
			int num4;
			while ((num4 = fileStream.Read(array2, 0, array2.Length)) > 0)
			{
				for (int j = 0; j < num4; j++)
				{
					byte b = (byte)((num3 ^ array2[j]) & 0xFF);
					num3 = (num3 >> 8) ^ array[b];
				}
			}
		}
		return num3 ^ 0xFFFFFFFFu;
	}

	public static List<CDTrack> FromBin(string file)
	{
		List<CDTrack> list = new List<CDTrack>();
		long length = new FileInfo(file).Length;
		int num = (int)(length / 2352);
		int lbaStart = 150;
		int lbaEnd = num;
		byte index = 1;
		list.Add(new CDTrack(file, length, index, lbaStart, lbaEnd));
		return list;
	}

	public static List<CDTrack> FromCue(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			Console.WriteLine("[CDROM] Value cannot be null or whitespace.", "path");
		}
		Console.WriteLine("[CDROM] Generating CD Tracks for: " + Path.GetFileName(path));
		string directoryName = Path.GetDirectoryName(path);
		using StreamReader streamReader = new StreamReader(path);
		List<CDTrack> list = new List<CDTrack>();
		Regex regex = new Regex("^\\s*FILE\\s+(\".*\")\\s+BINARY\\s*$", RegexOptions.Compiled | RegexOptions.Singleline);
		Regex regex2 = new Regex("^\\s*TRACK\\s+(\\d{2})\\s+(MODE1/2352|MODE2/2352|AUDIO)\\s*$", RegexOptions.Compiled | RegexOptions.Singleline);
		Regex regex3 = new Regex("^\\s*INDEX\\s+(\\d{2})\\s+(\\d{2}):(\\d{2}):(\\d{2})\\s*$", RegexOptions.Compiled | RegexOptions.Singleline);
		HashSet<string> hashSet = new HashSet<string>();
		string text = null;
		CDTrack cDTrack = null;
		int num = 0;
		string text2;
		while ((text2 = streamReader.ReadLine()) != null)
		{
			num++;
			if (string.IsNullOrWhiteSpace(text2))
			{
				continue;
			}
			Match match = regex.Match(text2);
			if (match.Success)
			{
				hashSet.Add(text = Path.Combine(directoryName, match.Groups[1].Value.Trim('"')));
				continue;
			}
			Match match2 = regex2.Match(text2);
			if (match2.Success)
			{
				if (text == null)
				{
					Console.WriteLine($"[CDROM] TRACK at line {num} does not have a parent FILE.");
					return null;
				}
				cDTrack = new CDTrack
				{
					File = text,
					Index = Convert.ToByte(match2.Groups[1].Value)
				};
				list.Add(cDTrack);
				continue;
			}
			Match match3 = regex3.Match(text2);
			if (match3.Success)
			{
				if (cDTrack == null)
				{
					Console.WriteLine($"[CDROM] INDEX at line {num} does not have a parent TRACK.");
					return null;
				}
				int number = Convert.ToInt32(match3.Groups[1].Value);
				int m = Convert.ToInt32(match3.Groups[2].Value);
				int s = Convert.ToInt32(match3.Groups[3].Value);
				int f = Convert.ToInt32(match3.Groups[4].Value);
				cDTrack.Indices.Add(new TrackIndex(number, new TrackPosition(m, s, f)));
			}
		}
		if (hashSet.Count == 1)
		{
			long length = new FileInfo(hashSet.Single()).Length;
			for (int i = 0; i < list.Count; i++)
			{
				CDTrack cDTrack2 = list[i];
				cDTrack2.FileLength = length;
				cDTrack2.LbaStart = cDTrack2.Indices.Last().Position.ToInt32();
				if (i == list.Count - 1)
				{
					cDTrack2.LbaEnd = (int)(length / 2352 - 1);
				}
				else
				{
					cDTrack2.LbaEnd = list[i + 1].Indices.First().Position.ToInt32() - 1;
				}
				cDTrack2.LbaLength = cDTrack2.LbaEnd - cDTrack2.LbaStart + 1;
				cDTrack2.FilePosition = cDTrack2.LbaStart * 2352;
			}
		}
		else
		{
			int num2 = 0;
			foreach (CDTrack item in list)
			{
				long length2 = new FileInfo(item.File).Length;
				long num3 = length2 / 2352;
				item.LbaStart = num2;
				item.FileLength = length2;
				foreach (TrackIndex index in item.Indices)
				{
					int lbaStart = item.LbaStart;
					TrackPosition position = index.Position;
					item.LbaStart = lbaStart + position.ToInt32();
				}
				item.LbaEnd = (int)(item.LbaStart + num3 - 1);
				foreach (TrackIndex index2 in item.Indices)
				{
					int lbaEnd = item.LbaEnd;
					TrackPosition position = index2.Position;
					item.LbaEnd = lbaEnd - position.ToInt32();
				}
				item.LbaLength = item.LbaEnd - item.LbaStart + 1;
				item.FilePosition = item.LbaStart * 2352;
				num2 += (int)num3;
			}
		}
		return list;
	}
}
