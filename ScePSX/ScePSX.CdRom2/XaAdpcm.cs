using System;
using System.Collections.Generic;

namespace ScePSX.CdRom2;

[Serializable]
public class XaAdpcm
{
	private const int BYTES_PER_HEADER = 24;

	private static short oldL;

	private static short olderL;

	private static short oldR;

	private static short olderR;

	private static int sixStep = 6;

	private static int resamplePointer;

	private static short[][] resampleRingBuffer = new short[2][]
	{
		new short[32],
		new short[32]
	};

	private static short[] nibbleBuffer = new short[28];

	private static short[][] zigZagTable = new short[7][]
	{
		new short[29]
		{
			0, 0, 0, 0, 0, -2, 10, -34, 65, -84,
			52, 9, -266, 1024, -2680, 9036, 26516, -6016, 3021, -1571,
			848, -365, 107, 10, -16, 17, -8, 3, -1
		},
		new short[29]
		{
			0, 0, 0, -2, 0, 3, -19, 60, -75, 162,
			-227, 306, -67, -615, 3229, 29883, -4532, 2488, -1471, 882,
			-424, 166, -27, 5, 6, -8, 3, -1, 0
		},
		new short[29]
		{
			0, 0, -1, 3, -2, -5, 31, -74, 179, -402,
			689, -926, 1272, -1446, 31033, -1446, 1272, -926, 689, -402,
			179, -74, 31, -5, -2, 3, -1, 0, 0
		},
		new short[29]
		{
			0, -1, 3, -8, 6, 5, -27, 166, -424, 882,
			-1471, 2488, -4532, 29883, 3229, -615, -67, 306, -227, 162,
			-75, 60, -19, 3, 0, -2, 0, 0, 0
		},
		new short[29]
		{
			-1, 3, -8, 17, -16, 10, 107, -365, 848, -1571,
			3021, -6016, 26516, 9036, -2680, 1024, -266, 9, 52, -84,
			65, -34, 10, -1, 0, 1, 0, 0, 0
		},
		new short[29]
		{
			2, -8, 16, -35, 43, 26, -235, 635, -1352, 2810,
			-5882, 21472, 15367, -4681, 2062, -839, 347, -68, -23, 70,
			-35, 17, -5, 0, 0, 0, 0, 0, 0
		},
		new short[29]
		{
			-5, 17, -35, 70, -23, -68, 347, -839, 2062, -4681,
			15367, 21472, -5882, 2810, -1352, 635, -235, 26, 43, -35,
			16, -8, 2, 0, 0, 0, 0, 0, 0
		}
	};

	private static List<short> l = new List<short>(2016);

	private static List<short> r = new List<short>(2016);

	private static List<short> mono = new List<short>(4032);

	private static List<byte> decoded = new List<byte>(37632);

	private static List<short> stereoResamples = new List<short>(2352);

	private static List<short> monoResamples = new List<short>(4704);

	private static ReadOnlySpan<sbyte> positiveXaAdpcmTable => new sbyte[5] { 0, 60, 115, 98, 122 };

	private static ReadOnlySpan<sbyte> negativeXaAdpcmTable => new sbyte[5] { 0, 0, -52, -55, -60 };

	public static byte[] Decode(byte[] xaadpcm, byte codingInfo)
	{
		XaAdpcm.l.Clear();
		r.Clear();
		mono.Clear();
		decoded.Clear();
		bool flag = (codingInfo & 1) == 1;
		bool is18900hz = ((codingInfo >> 2) & 1) == 1;
		int num = 24;
		for (int i = 0; i < 18; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (flag)
				{
					XaAdpcm.l.AddRange(decodeNibbles(xaadpcm, num, j, 0, ref oldL, ref olderL));
					r.AddRange(decodeNibbles(xaadpcm, num, j, 1, ref oldR, ref olderR));
				}
				else
				{
					mono.AddRange(decodeNibbles(xaadpcm, num, j, 0, ref oldL, ref olderL));
					mono.AddRange(decodeNibbles(xaadpcm, num, j, 1, ref oldL, ref olderL));
				}
			}
			num += 128;
		}
		if (flag)
		{
			List<short> list = resampleTo44100Hz(XaAdpcm.l, flag, is18900hz, 0);
			List<short> list2 = resampleTo44100Hz(r, flag, is18900hz, 1);
			for (int k = 0; k < list.Count; k++)
			{
				decoded.Add((byte)list[k]);
				decoded.Add((byte)(list[k] >> 8));
				decoded.Add((byte)list2[k]);
				decoded.Add((byte)(list2[k] >> 8));
			}
		}
		else
		{
			List<short> list3 = resampleTo44100Hz(mono, flag, is18900hz, 0);
			for (int l = 0; l < list3.Count; l++)
			{
				decoded.Add((byte)list3[l]);
				decoded.Add((byte)(list3[l] >> 8));
				decoded.Add((byte)list3[l]);
				decoded.Add((byte)(list3[l] >> 8));
			}
		}
		return decoded.ToArray();
	}

	private static List<short> resampleTo44100Hz(List<short> samples, bool isStereo, bool is18900hz, int channel)
	{
		List<short> list = (isStereo ? stereoResamples : monoResamples);
		list.Clear();
		for (int i = 0; i < samples.Count; i++)
		{
			resampleRingBuffer[channel][resamplePointer++ & 0x1F] = samples[i];
			sixStep--;
			if (sixStep == 0)
			{
				sixStep = 6;
				for (int j = 0; j < 7; j++)
				{
					list.Add(zigZagInterpolate(resamplePointer, j, channel));
				}
			}
		}
		return list;
	}

	private static short zigZagInterpolate(int resamplePointer, int table, int channel)
	{
		int num = 0;
		for (int i = 0; i < 29; i++)
		{
			num += resampleRingBuffer[channel][(resamplePointer - i) & 0x1F] * zigZagTable[table][i] / 32768;
		}
		return (short)MathHelper.Clamp(num, -32768, 32767);
	}

	public static short[] decodeNibbles(byte[] xaapdcm, int position, int blk, int nibble, ref short old, ref short older)
	{
		int num = 12 - (xaapdcm[position + 4 + blk * 2 + nibble] & 0xF);
		int index = (xaapdcm[position + 4 + blk * 2 + nibble] & 0x30) >> 4;
		int num2 = positiveXaAdpcmTable[index];
		int num3 = negativeXaAdpcmTable[index];
		for (int i = 0; i < 28; i++)
		{
			short num4 = (short)MathHelper.Clamp((signed4bit((byte)((xaapdcm[position + 16 + blk + i * 4] >> nibble * 4) & 0xF)) << num) + (old * num2 + older * num3 + 32) / 64, -32768, 32767);
			nibbleBuffer[i] = num4;
			older = old;
			old = num4;
		}
		return nibbleBuffer;
	}

	public static int signed4bit(byte value)
	{
		return value << 28 >> 28;
	}
}
