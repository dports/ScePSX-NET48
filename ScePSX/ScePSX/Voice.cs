using System;

namespace ScePSX;

[Serializable]
public class Voice
{
	[Serializable]
	public struct Volume
	{
		public ushort register;

		public bool isSweepMode => ((register >> 15) & 1) != 0;

		public short fixedVolume => (short)(register << 1);

		public bool isSweepExponential => ((register >> 14) & 1) != 0;

		public bool isSweepDirectionDecrease => ((register >> 13) & 1) != 0;

		public bool isSweepPhaseNegative => ((register >> 12) & 1) != 0;

		public int sweepShift => (register >> 2) & 0x1F;

		public int sweepStep => register & 3;
	}

	[Serializable]
	public struct ADSR
	{
		public ushort lo;

		public ushort hi;

		public bool isAttackModeExponential => ((lo >> 15) & 1) != 0;

		public int attackShift => (lo >> 10) & 0x1F;

		public int attackStep => (lo >> 8) & 3;

		public int decayShift => (lo >> 4) & 0xF;

		public int sustainLevel => lo & 0xF;

		public bool isSustainModeExponential => ((hi >> 15) & 1) != 0;

		public bool isSustainDirectionDecrease => ((hi >> 14) & 1) != 0;

		public int sustainShift => (hi >> 8) & 0x1F;

		public int sustainStep => (hi >> 6) & 3;

		public bool isReleaseModeExponential => ((hi >> 5) & 1) != 0;

		public int releaseShift => hi & 0x1F;
	}

	[Serializable]
	public struct Counter
	{
		public uint register;

		public uint currentSampleIndex
		{
			get
			{
				return (register >> 12) & 0x1F;
			}
			set
			{
				register = (ushort)(register &= 4095u);
				register |= value << 12;
			}
		}

		public uint interpolationIndex => (register >> 3) & 0xFF;
	}

	public enum Phase
	{
		Attack,
		Decay,
		Sustain,
		Release,
		Off
	}

	public Volume volumeLeft;

	public Volume volumeRight;

	public ushort pitch;

	public ushort startAddress;

	public ushort currentAddress;

	public ADSR adsr;

	public ushort adsrVolume;

	public ushort adpcmRepeatAddress;

	public Counter counter;

	public Phase adsrPhase;

	public short old;

	public short older;

	public short latest;

	public bool hasSamples;

	public bool readRamIrq;

	public byte[] spuAdpcm = new byte[16];

	public short[] decodedSamples = new short[31];

	private int adsrCounter;

	private static ReadOnlySpan<sbyte> positiveXaAdpcmTable => new sbyte[5] { 0, 60, 115, 98, 122 };

	private static ReadOnlySpan<sbyte> negativeXaAdpcmTable => new sbyte[5] { 0, 0, -52, -55, -60 };

	public Voice()
	{
		adsrPhase = Phase.Off;
	}

	public void keyOn()
	{
		hasSamples = false;
		old = 0;
		older = 0;
		currentAddress = startAddress;
		adsrCounter = 0;
		adsrVolume = 0;
		adsrPhase = Phase.Attack;
	}

	public void keyOff()
	{
		adsrCounter = 0;
		adsrPhase = Phase.Release;
	}

	internal unsafe void decodeSamples(byte* ram, ushort ramIrqAddress)
	{
		decodedSamples[2] = decodedSamples[decodedSamples.Length - 1];
		decodedSamples[1] = decodedSamples[decodedSamples.Length - 2];
		decodedSamples[0] = decodedSamples[decodedSamples.Length - 3];
		Span<byte> span = new Span<byte>(ram, 524288);
		span = span.Slice(currentAddress * 8, 16);
		span.CopyTo(spuAdpcm);
		readRamIrq |= currentAddress == ramIrqAddress || currentAddress + 1 == ramIrqAddress;
		int num = spuAdpcm[0] & 0xF;
		if (num > 12)
		{
			num = 9;
		}
		int num2 = 12 - num;
		int num3 = (spuAdpcm[0] & 0x70) >> 4;
		if (num3 > 4)
		{
			num3 = 4;
		}
		int num4 = positiveXaAdpcmTable[num3];
		int num5 = negativeXaAdpcmTable[num3];
		int num6 = 2;
		int num7 = 1;
		for (int i = 0; i < 28; i++)
		{
			num7 = (num7 + 1) & 1;
			short num8 = (short)MathHelper.Clamp((signed4bit((byte)((spuAdpcm[num6] >> num7 * 4) & 0xF)) << num2) + (old * num4 + older * num5 + 32) / 64, -32768, 32767);
			decodedSamples[3 + i] = num8;
			older = old;
			old = num8;
			num6 += num7;
		}
	}

	public static int signed4bit(byte value)
	{
		return value << 28 >> 28;
	}

	internal short processVolume(Volume volume)
	{
		if (!volume.isSweepMode)
		{
			return volume.fixedVolume;
		}
		return short.MaxValue;
	}

	internal void tickAdsr(int v)
	{
		if (adsrPhase == Phase.Off)
		{
			adsrVolume = 0;
			return;
		}
		int num;
		int num2;
		int num3;
		bool flag;
		bool flag2;
		switch (adsrPhase)
		{
		case Phase.Attack:
			num = 32767;
			num2 = adsr.attackShift;
			num3 = 7 - adsr.attackStep;
			flag = false;
			flag2 = adsr.isAttackModeExponential;
			break;
		case Phase.Decay:
			num = (adsr.sustainLevel + 1) * 2048;
			num2 = adsr.decayShift;
			num3 = -8;
			flag = true;
			flag2 = true;
			break;
		case Phase.Sustain:
			num = 0;
			num2 = adsr.sustainShift;
			num3 = (adsr.isSustainDirectionDecrease ? (-8 + adsr.sustainStep) : (7 - adsr.sustainStep));
			flag = adsr.isSustainDirectionDecrease;
			flag2 = adsr.isSustainModeExponential;
			break;
		case Phase.Release:
			num = 0;
			num2 = adsr.releaseShift;
			num3 = -8;
			flag = true;
			flag2 = adsr.isReleaseModeExponential;
			break;
		default:
			num = 0;
			num2 = 0;
			num3 = 0;
			flag = false;
			flag2 = false;
			break;
		}
		if (adsrCounter > 0)
		{
			adsrCounter--;
			return;
		}
		int num4 = 1 << Math.Max(0, num2 - 11);
		int num5 = num3 << Math.Max(0, 11 - num2);
		if (flag2 && !flag && adsrVolume > 24576)
		{
			num4 *= 4;
		}
		if (flag2 && flag)
		{
			num5 = num5 * adsrVolume >> 15;
		}
		adsrVolume = (ushort)MathHelper.Clamp(adsrVolume + num5, 0, 32767);
		adsrCounter = num4;
		if ((flag ? (adsrVolume <= num) : (adsrVolume >= num)) && adsrPhase != Phase.Sustain)
		{
			adsrPhase++;
			adsrCounter = 0;
		}
	}
}
