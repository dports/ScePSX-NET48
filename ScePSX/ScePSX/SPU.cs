using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ScePSX.CdRom2;

namespace ScePSX;

[Serializable]
public class SPU : IDisposable
{
	[Serializable]
	private struct Control
	{
		public ushort register;

		public bool spuEnabled => ((register >> 15) & 1) != 0;

		public bool spuUnmuted => ((register >> 14) & 1) != 0;

		public int noiseFrequencyShift => (register >> 10) & 0xF;

		public int noiseFrequencyStep => (register >> 8) & 3;

		public bool reverbMasterEnabled => ((register >> 7) & 1) != 0;

		public bool irq9Enabled => ((register >> 6) & 1) != 0;

		public int soundRamTransferMode => (register >> 4) & 3;

		public bool externalAudioReverb => ((register >> 3) & 1) != 0;

		public bool cdAudioReverb => ((register >> 2) & 1) != 0;

		public bool externalAudioEnabled => ((register >> 1) & 1) != 0;

		public bool cdAudioEnabled => (register & 1) != 0;
	}

	[Serializable]
	private struct Status
	{
		public ushort register;

		public bool isSecondHalfCaptureBuffer => ((register >> 11) & 1) != 0;

		public bool dataTransferBusyFlag => ((register >> 10) & 1) != 0;

		public bool dataTransferDmaReadRequest => ((register >> 9) & 1) != 0;

		public bool dataTransferDmaWriteRequest => ((register >> 8) & 1) != 0;

		public bool irq9Flag
		{
			get
			{
				return ((register >> 6) & 1) != 0;
			}
			set
			{
				register = (value ? ((ushort)(register | 0x40)) : ((ushort)(register & -65)));
			}
		}
	}

	private const int CYCLES_PER_SAMPLE = 768;

	private int counter;

	private int reverbCounter;

	private static short[] gaussTable = new short[512]
	{
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, 0, 0, 0, 0,
		0, 0, 0, 1, 1, 1, 1, 2, 2, 2,
		3, 3, 3, 4, 4, 5, 5, 6, 7, 7,
		8, 9, 9, 10, 11, 12, 13, 14, 15, 16,
		17, 18, 19, 21, 22, 24, 25, 27, 28, 30,
		32, 33, 35, 37, 39, 41, 44, 46, 48, 51,
		53, 56, 58, 61, 64, 67, 70, 73, 77, 80,
		84, 87, 91, 95, 99, 103, 107, 111, 116, 120,
		125, 130, 135, 140, 145, 150, 156, 161, 167, 173,
		179, 186, 192, 199, 205, 212, 219, 227, 234, 242,
		250, 257, 266, 274, 283, 291, 300, 309, 319, 328,
		338, 348, 358, 369, 379, 390, 401, 412, 424, 436,
		448, 460, 473, 485, 498, 512, 525, 539, 553, 567,
		582, 597, 612, 627, 643, 659, 675, 692, 708, 726,
		743, 761, 779, 797, 816, 835, 854, 874, 894, 914,
		935, 956, 977, 999, 1020, 1043, 1066, 1089, 1112, 1136,
		1160, 1184, 1209, 1234, 1260, 1286, 1312, 1339, 1366, 1394,
		1422, 1450, 1479, 1508, 1537, 1567, 1598, 1628, 1660, 1691,
		1723, 1756, 1789, 1822, 1856, 1890, 1924, 1959, 1995, 2031,
		2067, 2104, 2141, 2179, 2217, 2256, 2295, 2334, 2374, 2415,
		2456, 2497, 2539, 2582, 2624, 2668, 2712, 2756, 2801, 2846,
		2892, 2938, 2985, 3032, 3079, 3128, 3176, 3225, 3275, 3325,
		3376, 3427, 3479, 3531, 3584, 3637, 3691, 3745, 3799, 3855,
		3910, 3967, 4023, 4081, 4138, 4197, 4255, 4315, 4374, 4435,
		4495, 4557, 4619, 4681, 4744, 4807, 4871, 4935, 5000, 5065,
		5131, 5197, 5264, 5332, 5399, 5468, 5536, 5606, 5676, 5746,
		5817, 5888, 5959, 6032, 6104, 6177, 6251, 6325, 6400, 6475,
		6550, 6626, 6702, 6779, 6856, 6934, 7012, 7091, 7170, 7249,
		7329, 7409, 7490, 7571, 7653, 7735, 7817, 7900, 7983, 8066,
		8150, 8234, 8319, 8404, 8489, 8575, 8661, 8748, 8834, 8922,
		9009, 9097, 9185, 9273, 9362, 9451, 9541, 9630, 9720, 9811,
		9901, 9992, 10083, 10174, 10266, 10358, 10450, 10542, 10635, 10727,
		10820, 10913, 11007, 11100, 11194, 11288, 11382, 11476, 11571, 11665,
		11760, 11855, 11950, 12045, 12140, 12236, 12331, 12427, 12522, 12618,
		12714, 12809, 12905, 13001, 13097, 13193, 13289, 13385, 13481, 13577,
		13673, 13769, 13865, 13961, 14056, 14152, 14248, 14343, 14439, 14534,
		14630, 14725, 14820, 14915, 15010, 15104, 15199, 15293, 15387, 15481,
		15575, 15669, 15762, 15855, 15948, 16041, 16133, 16226, 16317, 16409,
		16500, 16592, 16682, 16773, 16863, 16953, 17042, 17131, 17220, 17308,
		17396, 17484, 17571, 17658, 17744, 17830, 17916, 18001, 18086, 18170,
		18254, 18337, 18420, 18502, 18584, 18665, 18746, 18826, 18905, 18985,
		19063, 19141, 19219, 19295, 19372, 19447, 19522, 19597, 19671, 19744,
		19816, 19888, 19959, 20030, 20100, 20169, 20238, 20306, 20373, 20439,
		20505, 20570, 20634, 20698, 20760, 20822, 20884, 20944, 21004, 21063,
		21121, 21178, 21235, 21290, 21345, 21399, 21452, 21505, 21556, 21607,
		21657, 21706, 21754, 21801, 21848, 21893, 21938, 21982, 22025, 22066,
		22107, 22148, 22187, 22225, 22262, 22299, 22334, 22369, 22402, 22435,
		22467, 22498, 22527, 22556, 22584, 22611, 22637, 22662, 22686, 22709,
		22731, 22752, 22772, 22791, 22809, 22826, 22842, 22857, 22872, 22885,
		22897, 22908, 22918, 22927, 22935, 22942, 22948, 22953, 22957, 22960,
		22962, 22963
	};

	private byte[] spuOutput = new byte[2048];

	private int spuOutputPointer;

	private CDSector cdBuffer = new CDSector(18816);

	[NonSerialized]
	public unsafe byte* ram = (byte*)Marshal.AllocHGlobal(524288);

	private Voice[] voices = new Voice[24];

	private short mainVolumeLeft;

	private short mainVolumeRight;

	private short reverbOutputVolumeLeft;

	private short reverbOutputVolumeRight;

	private uint keyOn;

	private uint keyOff;

	private uint pitchModulationEnableFlags;

	private uint channelNoiseMode;

	private uint channelReverbMode;

	private uint endx;

	private ushort unknownA0;

	private uint ramReverbStartAddress;

	private uint ramReverbInternalAddress;

	private ushort ramIrqAddress;

	private ushort ramDataTransferAddress;

	private uint ramDataTransferAddressInternal;

	private ushort ramDataTransferFifo;

	private ushort ramDataTransferControl;

	private ushort cdVolumeLeft;

	private ushort cdVolumeRight;

	private ushort externVolumeLeft;

	private ushort externVolumeRight;

	private ushort currentVolumeLeft;

	private ushort currentVolumeRight;

	private uint unknownBC;

	private int captureBufferPos;

	private uint dAPF1;

	private uint dAPF2;

	private short vIIR;

	private short vCOMB1;

	private short vCOMB2;

	private short vCOMB3;

	private short vCOMB4;

	private short vWALL;

	private short vAPF1;

	private short vAPF2;

	private uint mLSAME;

	private uint mRSAME;

	private uint mLCOMB1;

	private uint mLCOMB2;

	private uint mRCOMB1;

	private uint mRCOMB2;

	private uint dLSAME;

	private uint dRSAME;

	private uint mLDIFF;

	private uint mRDIFF;

	private uint mLCOMB3;

	private uint mRCOMB3;

	private uint mLCOMB4;

	private uint mRCOMB4;

	private uint dLDIFF;

	private uint dRDIFF;

	private uint mLAPF1;

	private uint mRAPF1;

	private uint mLAPF2;

	private uint mRAPF2;

	private short vLIN;

	private short vRIN;

	private Control control;

	private Status status;

	[NonSerialized]
	public ICoreHandler host;

	private IRQController interruptController;

	private int noiseTimer;

	private int noiseLevel;

	public unsafe SPU(ICoreHandler host, IRQController interruptController)
	{
		this.host = host;
		this.interruptController = interruptController;
		for (int i = 0; i < voices.Length; i++)
		{
			voices[i] = new Voice();
		}
	}

	public unsafe void Dispose()
	{
		Marshal.FreeHGlobal((nint)ram);
	}

	internal void write(uint addr, ushort value)
	{
		if (addr < 528489472 || addr > 528489855)
		{
			switch (addr)
			{
			case 528489856u:
				mainVolumeLeft = (short)value;
				break;
			case 528489858u:
				mainVolumeRight = (short)value;
				break;
			case 528489860u:
				reverbOutputVolumeLeft = (short)value;
				break;
			case 528489862u:
				reverbOutputVolumeRight = (short)value;
				break;
			case 528489864u:
				keyOn = (keyOn & 0xFFFF0000u) | value;
				break;
			case 528489866u:
				keyOn = (keyOn & 0xFFFF) | (uint)(value << 16);
				break;
			case 528489868u:
				keyOff = (keyOff & 0xFFFF0000u) | value;
				break;
			case 528489870u:
				keyOff = (keyOff & 0xFFFF) | (uint)(value << 16);
				break;
			case 528489872u:
				pitchModulationEnableFlags = (pitchModulationEnableFlags & 0xFFFF0000u) | value;
				break;
			case 528489874u:
				pitchModulationEnableFlags = (pitchModulationEnableFlags & 0xFFFF) | (uint)(value << 16);
				break;
			case 528489876u:
				channelNoiseMode = (channelNoiseMode & 0xFFFF0000u) | value;
				break;
			case 528489878u:
				channelNoiseMode = (channelNoiseMode & 0xFFFF) | (uint)(value << 16);
				break;
			case 528489880u:
				channelReverbMode = (channelReverbMode & 0xFFFF0000u) | value;
				break;
			case 528489882u:
				channelReverbMode = (channelReverbMode & 0xFFFF) | (uint)(value << 16);
				break;
			case 528489884u:
				endx = (endx & 0xFFFF0000u) | value;
				break;
			case 528489886u:
				endx = (endx & 0xFFFF) | (uint)(value << 16);
				break;
			case 528489888u:
				unknownA0 = value;
				break;
			case 528489890u:
				ramReverbStartAddress = (uint)(value << 3);
				ramReverbInternalAddress = (uint)(value << 3);
				break;
			case 528489892u:
				ramIrqAddress = value;
				break;
			case 528489894u:
				ramDataTransferAddress = value;
				ramDataTransferAddressInternal = (uint)(value * 8);
				break;
			case 528489896u:
				ramDataTransferFifo = value;
				writeRam(ramDataTransferAddressInternal, value);
				ramDataTransferAddressInternal += 2u;
				break;
			case 528489898u:
				control.register = value;
				if (!control.spuEnabled)
				{
					Voice[] array = voices;
					foreach (Voice obj in array)
					{
						obj.adsrPhase = Voice.Phase.Off;
						obj.adsrVolume = 0;
					}
				}
				if (!control.irq9Enabled)
				{
					status.irq9Flag = false;
				}
				status.register &= 65472;
				status.register |= (ushort)(value & 0x3F);
				break;
			case 528489900u:
				ramDataTransferControl = value;
				break;
			case 528489902u:
				status.register = value;
				break;
			case 528489904u:
				cdVolumeLeft = value;
				break;
			case 528489906u:
				cdVolumeRight = value;
				break;
			case 528489908u:
				externVolumeLeft = value;
				break;
			case 528489910u:
				externVolumeRight = value;
				break;
			case 528489912u:
				currentVolumeLeft = value;
				break;
			case 528489914u:
				currentVolumeRight = value;
				break;
			case 528489916u:
				unknownBC = (unknownBC & 0xFFFF0000u) | value;
				break;
			case 528489918u:
				unknownBC = (unknownBC & 0xFFFF) | (uint)(value << 16);
				break;
			case 528489920u:
				dAPF1 = (uint)(value << 3);
				break;
			case 528489922u:
				dAPF2 = (uint)(value << 3);
				break;
			case 528489924u:
				vIIR = (short)value;
				break;
			case 528489926u:
				vCOMB1 = (short)value;
				break;
			case 528489928u:
				vCOMB2 = (short)value;
				break;
			case 528489930u:
				vCOMB3 = (short)value;
				break;
			case 528489932u:
				vCOMB4 = (short)value;
				break;
			case 528489934u:
				vWALL = (short)value;
				break;
			case 528489936u:
				vAPF1 = (short)value;
				break;
			case 528489938u:
				vAPF2 = (short)value;
				break;
			case 528489940u:
				mLSAME = (uint)(value << 3);
				break;
			case 528489942u:
				mRSAME = (uint)(value << 3);
				break;
			case 528489944u:
				mLCOMB1 = (uint)(value << 3);
				break;
			case 528489946u:
				mRCOMB1 = (uint)(value << 3);
				break;
			case 528489948u:
				mLCOMB2 = (uint)(value << 3);
				break;
			case 528489950u:
				mRCOMB2 = (uint)(value << 3);
				break;
			case 528489952u:
				dLSAME = (uint)(value << 3);
				break;
			case 528489954u:
				dRSAME = (uint)(value << 3);
				break;
			case 528489956u:
				mLDIFF = (uint)(value << 3);
				break;
			case 528489958u:
				mRDIFF = (uint)(value << 3);
				break;
			case 528489960u:
				mLCOMB3 = (uint)(value << 3);
				break;
			case 528489962u:
				mRCOMB3 = (uint)(value << 3);
				break;
			case 528489964u:
				mLCOMB4 = (uint)(value << 3);
				break;
			case 528489966u:
				mRCOMB4 = (uint)(value << 3);
				break;
			case 528489968u:
				dLDIFF = (uint)(value << 3);
				break;
			case 528489970u:
				dRDIFF = (uint)(value << 3);
				break;
			case 528489972u:
				mLAPF1 = (uint)(value << 3);
				break;
			case 528489974u:
				mRAPF1 = (uint)(value << 3);
				break;
			case 528489976u:
				mLAPF2 = (uint)(value << 3);
				break;
			case 528489978u:
				mRAPF2 = (uint)(value << 3);
				break;
			case 528489980u:
				vLIN = (short)value;
				break;
			case 528489982u:
				vRIN = (short)value;
				break;
			default:
				Console.WriteLine($"[SPU] Warning write:{addr:x8} value:{value:x8}");
				writeRam(addr, value);
				break;
			}
		}
		else
		{
			uint num = ((addr & 0xFF0) >> 4) - 192;
			switch (addr & 0xF)
			{
			case 0u:
				voices[num].volumeLeft.register = value;
				break;
			case 2u:
				voices[num].volumeRight.register = value;
				break;
			case 4u:
				voices[num].pitch = value;
				break;
			case 6u:
				voices[num].startAddress = value;
				break;
			case 8u:
				voices[num].adsr.lo = value;
				break;
			case 10u:
				voices[num].adsr.hi = value;
				break;
			case 12u:
				voices[num].adsrVolume = value;
				break;
			case 14u:
				voices[num].adpcmRepeatAddress = value;
				break;
			case 1u:
			case 3u:
			case 5u:
			case 7u:
			case 9u:
			case 11u:
			case 13u:
				break;
			}
		}
	}

	internal ushort read(uint addr)
	{
		if (addr < 528489472 || addr > 528489855)
		{
			return addr switch
			{
				528489856u => (ushort)mainVolumeLeft, 
				528489858u => (ushort)mainVolumeRight, 
				528489860u => (ushort)reverbOutputVolumeLeft, 
				528489862u => (ushort)reverbOutputVolumeRight, 
				528489864u => (ushort)keyOn, 
				528489866u => (ushort)(keyOn >> 16), 
				528489868u => (ushort)keyOff, 
				528489870u => (ushort)(keyOff >> 16), 
				528489872u => (ushort)pitchModulationEnableFlags, 
				528489874u => (ushort)(pitchModulationEnableFlags >> 16), 
				528489876u => (ushort)channelNoiseMode, 
				528489878u => (ushort)(channelNoiseMode >> 16), 
				528489880u => (ushort)channelReverbMode, 
				528489882u => (ushort)(channelReverbMode >> 16), 
				528489884u => (ushort)endx, 
				528489886u => (ushort)(endx >> 16), 
				528489888u => unknownA0, 
				528489890u => (ushort)(ramReverbStartAddress >> 3), 
				528489892u => ramIrqAddress, 
				528489894u => ramDataTransferAddress, 
				528489896u => ramDataTransferFifo, 
				528489898u => control.register, 
				528489900u => ramDataTransferControl, 
				528489902u => status.register, 
				528489904u => cdVolumeLeft, 
				528489906u => cdVolumeRight, 
				528489908u => externVolumeLeft, 
				528489910u => externVolumeRight, 
				528489912u => currentVolumeLeft, 
				528489914u => currentVolumeRight, 
				528489916u => (ushort)unknownBC, 
				528489918u => (ushort)(unknownBC >> 16), 
				528489920u => (ushort)(dAPF1 >> 3), 
				528489922u => (ushort)(dAPF2 >> 3), 
				528489924u => (ushort)vIIR, 
				528489926u => (ushort)vCOMB1, 
				528489928u => (ushort)vCOMB2, 
				528489930u => (ushort)vCOMB3, 
				528489932u => (ushort)vCOMB4, 
				528489934u => (ushort)vWALL, 
				528489936u => (ushort)vAPF1, 
				528489938u => (ushort)vAPF2, 
				528489940u => (ushort)(mLSAME >> 3), 
				528489942u => (ushort)(mRSAME >> 3), 
				528489944u => (ushort)(mLCOMB1 >> 3), 
				528489946u => (ushort)(mRCOMB1 >> 3), 
				528489948u => (ushort)(mLCOMB2 >> 3), 
				528489950u => (ushort)(mRCOMB2 >> 3), 
				528489952u => (ushort)(dLSAME >> 3), 
				528489954u => (ushort)(dRSAME >> 3), 
				528489956u => (ushort)(mLDIFF >> 3), 
				528489958u => (ushort)(mRDIFF >> 3), 
				528489960u => (ushort)(mLCOMB3 >> 3), 
				528489962u => (ushort)(mRCOMB3 >> 3), 
				528489964u => (ushort)(mLCOMB4 >> 3), 
				528489966u => (ushort)(mRCOMB4 >> 3), 
				528489968u => (ushort)(dLDIFF >> 3), 
				528489970u => (ushort)(dRDIFF >> 3), 
				528489972u => (ushort)(mLAPF1 >> 3), 
				528489974u => (ushort)(mRAPF1 >> 3), 
				528489976u => (ushort)(mLAPF2 >> 3), 
				528489978u => (ushort)(mRAPF2 >> 3), 
				528489980u => (ushort)vLIN, 
				528489982u => (ushort)vRIN, 
				_ => (ushort)readRam(addr), 
			};
		}
		uint num = ((addr & 0xFF0) >> 4) - 192;
		return (addr & 0xF) switch
		{
			0u => voices[num].volumeLeft.register, 
			2u => voices[num].volumeRight.register, 
			4u => voices[num].pitch, 
			6u => voices[num].startAddress, 
			8u => voices[num].adsr.lo, 
			10u => voices[num].adsr.hi, 
			12u => voices[num].adsrVolume, 
			14u => voices[num].adpcmRepeatAddress, 
			_ => ushort.MaxValue, 
		};
	}

	internal void pushCdBufferSamples(byte[] decodedXaAdpcm)
	{
		cdBuffer.fillWith(decodedXaAdpcm);
	}

	public bool tick(int cycles)
	{
		bool flag = false;
		counter += cycles;
		if (counter < 768)
		{
			return false;
		}
		counter -= 768;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		uint num5 = keyOn;
		uint num6 = keyOff;
		keyOn = 0u;
		keyOff = 0u;
		tickNoiseGenerator();
		for (int i = 0; i < voices.Length; i++)
		{
			Voice voice = voices[i];
			if ((num6 & (1 << i)) != 0L)
			{
				voice.keyOff();
			}
			if ((num5 & (1 << i)) != 0L)
			{
				endx &= (uint)(~(1 << i));
				voice.keyOn();
			}
			if (voice.adsrPhase == Voice.Phase.Off)
			{
				voice.latest = 0;
				continue;
			}
			short num7;
			if ((channelNoiseMode & (1 << i)) != 0L)
			{
				num7 = (short)noiseLevel;
			}
			else
			{
				num7 = sampleVoice(i);
				flag |= control.irq9Enabled && voice.readRamIrq;
				voice.readRamIrq = false;
			}
			num7 = (short)(num7 * voice.adsrVolume >> 15);
			voice.tickAdsr(i);
			voice.latest = num7;
			num += num7 * voice.processVolume(voice.volumeLeft) >> 15;
			num2 += num7 * voice.processVolume(voice.volumeRight) >> 15;
			if ((channelReverbMode & (1 << i)) != 0L)
			{
				num3 += num7 * voice.processVolume(voice.volumeLeft) >> 15;
				num4 += num7 * voice.processVolume(voice.volumeRight) >> 15;
			}
		}
		if (!control.spuUnmuted)
		{
			num = 0;
			num2 = 0;
		}
		short num8 = 0;
		short num9 = 0;
		if (cdBuffer.hasSamples())
		{
			num8 = cdBuffer.readShort();
			num9 = cdBuffer.readShort();
		}
		if (control.cdAudioEnabled)
		{
			num8 = (short)(num8 * cdVolumeLeft >> 15);
			num9 = (short)(num9 * cdVolumeRight >> 15);
			num += num8;
			num2 += num9;
			if (control.cdAudioReverb)
			{
				num3 += num8;
				num4 += num9;
			}
		}
		if (reverbCounter == 0)
		{
			(short, short) tuple = processReverb(num3, num4);
			short item = tuple.Item1;
			short item2 = tuple.Item2;
			num += item;
			num2 += item2;
		}
		reverbCounter = (reverbCounter + 1) & 1;
		flag |= handleCaptureBuffer(captureBufferPos, num8);
		flag |= handleCaptureBuffer(1024 + captureBufferPos, num9);
		flag |= handleCaptureBuffer(2048 + captureBufferPos, voices[1].latest);
		flag |= handleCaptureBuffer(3072 + captureBufferPos, voices[3].latest);
		captureBufferPos = (captureBufferPos + 2) & 0x3FF;
		num = MathHelper.Clamp(num, -32768, 32767) * mainVolumeLeft >> 15;
		num2 = MathHelper.Clamp(num2, -32768, 32767) * mainVolumeRight >> 15;
		spuOutput[spuOutputPointer++] = (byte)num;
		spuOutput[spuOutputPointer++] = (byte)(num >> 8);
		spuOutput[spuOutputPointer++] = (byte)num2;
		spuOutput[spuOutputPointer++] = (byte)(num2 >> 8);
		if (spuOutputPointer >= 2048)
		{
			host.SamplesReady(spuOutput);
			spuOutputPointer = 0;
		}
		if (control.irq9Enabled && flag)
		{
			status.irq9Flag = true;
		}
		return control.irq9Enabled && flag;
	}

	private bool handleCaptureBuffer(int address, short sample)
	{
		writeRam((uint)address, sample);
		return address >> 3 == ramIrqAddress;
	}

	private void tickNoiseGenerator()
	{
		int num = control.noiseFrequencyStep + 4;
		int noiseFrequencyShift = control.noiseFrequencyShift;
		noiseTimer -= num;
		int num2 = ((noiseLevel >> 15) & 1) ^ ((noiseLevel >> 12) & 1) ^ ((noiseLevel >> 11) & 1) ^ ((noiseLevel >> 10) & 1) ^ 1;
		if (noiseTimer < 0)
		{
			noiseLevel = noiseLevel * 2 + num2;
		}
		if (noiseTimer < 0)
		{
			noiseTimer += 131072 >> noiseFrequencyShift;
		}
		if (noiseTimer < 0)
		{
			noiseTimer += 131072 >> noiseFrequencyShift;
		}
	}

	public unsafe short sampleVoice(int v)
	{
		Voice voice = voices[v];
		if (!voice.hasSamples)
		{
			voice.decodeSamples(ram, ramIrqAddress);
			voice.hasSamples = true;
			if ((voice.spuAdpcm[1] & 4) != 0)
			{
				voice.adpcmRepeatAddress = voice.currentAddress;
			}
		}
		uint interpolationIndex = voice.counter.interpolationIndex;
		uint currentSampleIndex = voice.counter.currentSampleIndex;
		int num = gaussTable[255 - interpolationIndex] * voice.decodedSamples[currentSampleIndex] + gaussTable[511 - interpolationIndex] * voice.decodedSamples[currentSampleIndex + 1] + gaussTable[256 + interpolationIndex] * voice.decodedSamples[currentSampleIndex + 2] + gaussTable[interpolationIndex] * voice.decodedSamples[currentSampleIndex + 3] >> 15;
		int num2 = voice.pitch;
		if ((pitchModulationEnableFlags & (1 << v)) != 0L && v > 0)
		{
			int num3 = voices[v - 1].latest + 32768;
			num2 = num2 * num3 >> 15;
			num2 &= 0xFFFF;
		}
		if (num2 > 16383)
		{
			num2 = 16384;
		}
		voice.counter.register += (ushort)num2;
		if (voice.counter.currentSampleIndex >= 28)
		{
			voice.counter.currentSampleIndex -= 28u;
			voice.currentAddress += 2;
			voice.hasSamples = false;
			byte num4 = voice.spuAdpcm[1];
			bool flag = (num4 & 1) != 0;
			bool flag2 = (num4 & 2) != 0;
			if (flag)
			{
				endx |= (uint)(1 << v);
				if (flag2)
				{
					voice.currentAddress = voice.adpcmRepeatAddress;
				}
				else
				{
					voice.adsrPhase = Voice.Phase.Off;
					voice.adsrVolume = 0;
				}
			}
		}
		return (short)num;
	}

	public (short, short) processReverb(int lInput, int rInput)
	{
		int num = vLIN * lInput >> 15;
		int num2 = vRIN * rInput >> 15;
		short value = saturateSample(num + (readReverb(dLSAME) * vWALL >> 15) - (readReverb(mLSAME - 2) * vIIR >> 15) + readReverb(mLSAME - 2));
		short value2 = saturateSample(num2 + (readReverb(dRSAME) * vWALL >> 15) - (readReverb(mRSAME - 2) * vIIR >> 15) + readReverb(mRSAME - 2));
		writeReverb(mLSAME, value);
		writeReverb(mRSAME, value2);
		short value3 = saturateSample(num + (readReverb(dRDIFF) * vWALL >> 15) - (readReverb(mLDIFF - 2) * vIIR >> 15) + readReverb(mLDIFF - 2));
		short value4 = saturateSample(num2 + (readReverb(dLDIFF) * vWALL >> 15) - (readReverb(mRDIFF - 2) * vIIR >> 15) + readReverb(mRDIFF - 2));
		writeReverb(mLDIFF, value3);
		writeReverb(mRDIFF, value4);
		short num3 = saturateSample((vCOMB1 * readReverb(mLCOMB1) >> 15) + (vCOMB2 * readReverb(mLCOMB2) >> 15) + (vCOMB3 * readReverb(mLCOMB3) >> 15) + (vCOMB4 * readReverb(mLCOMB4) >> 15));
		short num4 = saturateSample((vCOMB1 * readReverb(mRCOMB1) >> 15) + (vCOMB2 * readReverb(mRCOMB2) >> 15) + (vCOMB3 * readReverb(mRCOMB3) >> 15) + (vCOMB4 * readReverb(mRCOMB4) >> 15));
		num3 = saturateSample(num3 - saturateSample(vAPF1 * readReverb(mLAPF1 - dAPF1) >> 15));
		num4 = saturateSample(num4 - saturateSample(vAPF1 * readReverb(mRAPF1 - dAPF1) >> 15));
		writeReverb(mLAPF1, num3);
		writeReverb(mRAPF1, num4);
		num3 = saturateSample((num3 * vAPF1 >> 15) + readReverb(mLAPF1 - dAPF1));
		num4 = saturateSample((num4 * vAPF1 >> 15) + readReverb(mRAPF1 - dAPF1));
		num3 = saturateSample(num3 - saturateSample(vAPF2 * readReverb(mLAPF2 - dAPF2) >> 15));
		num4 = saturateSample(num4 - saturateSample(vAPF2 * readReverb(mRAPF2 - dAPF2) >> 15));
		writeReverb(mLAPF2, num3);
		writeReverb(mRAPF2, num4);
		num3 = saturateSample((num3 * vAPF2 >> 15) + readReverb(mLAPF2 - dAPF2));
		num4 = saturateSample((num4 * vAPF2 >> 15) + readReverb(mRAPF2 - dAPF2));
		num3 = saturateSample(num3 * reverbOutputVolumeLeft >> 15);
		num4 = saturateSample(num4 * reverbOutputVolumeRight >> 15);
		ramReverbInternalAddress = Math.Max(ramReverbStartAddress, (ramReverbInternalAddress + 2) & 0x7FFFE);
		return (num3, num4);
	}

	public short saturateSample(int sample)
	{
		if (sample < -32768)
		{
			return short.MinValue;
		}
		if (sample > 32767)
		{
			return short.MaxValue;
		}
		return (short)sample;
	}

	public unsafe Span<uint> processDmaRead(int size)
	{
		Span<byte> span = new Span<byte>(ram, 524288).Slice((int)ramDataTransferAddressInternal, size * 4);
		uint num = (uint)(ramIrqAddress << 3);
		if (num > ramDataTransferAddressInternal && num < ramDataTransferAddressInternal + size * 4 && control.irq9Enabled)
		{
			status.irq9Flag = true;
			interruptController.set(Interrupt.SPU);
		}
		ramDataTransferAddressInternal += (uint)(size * 4);
		return MemoryMarshal.Cast<byte, uint>(span);
	}

	public unsafe void processDmaWrite(Span<uint> dma)
	{
		int num = dma.Length * 4;
		int num2 = (int)ramDataTransferAddressInternal + num - 1;
		Span<byte> span = MemoryMarshal.Cast<uint, byte>(dma);
		Span<byte> destination = new Span<byte>(ram, 524288);
		Span<byte> destination2 = destination.Slice((int)ramDataTransferAddressInternal);
		uint num3 = (uint)(ramIrqAddress << 3);
		if (num3 > ramDataTransferAddressInternal && num3 < ramDataTransferAddressInternal + num && control.irq9Enabled)
		{
			status.irq9Flag = true;
			interruptController.set(Interrupt.SPU);
		}
		if (num2 <= 524287)
		{
			span.CopyTo(destination2);
		}
		else
		{
			int num4 = num2 - 524287;
			Span<byte> span2 = span.Slice(0, span.Length - num4);
			Span<byte> span3 = span.Slice(span.Length - num4);
			span2.CopyTo(destination2);
			span3.CopyTo(destination);
		}
		ramDataTransferAddressInternal = (uint)((ramDataTransferAddressInternal + num) & 0x7FFFF);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe void writeRam<T>(uint addr, T value) where T : unmanaged
	{
		*(T*)(ram + addr) = value;
	}

	private unsafe short readRam(uint addr)
	{
		return *(short*)(ram + (addr & 0x7FFFF));
	}

	private unsafe void writeReverb(uint addr, short value)
	{
		if (control.reverbMasterEnabled)
		{
			uint num = (addr + ramReverbInternalAddress - ramReverbStartAddress) % (524288 - ramReverbStartAddress);
			uint num2 = (ramReverbStartAddress + num) & 0x7FFFE;
			*(short*)(ram + num2) = value;
		}
	}

	private unsafe short readReverb(uint addr)
	{
		uint num = (addr + ramReverbInternalAddress - ramReverbStartAddress) % (524288 - ramReverbStartAddress);
		uint num2 = (ramReverbStartAddress + num) & 0x7FFFE;
		return *(short*)(ram + num2);
	}
}
