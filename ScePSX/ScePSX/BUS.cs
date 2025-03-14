using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ScePSX.CdRom2;

namespace ScePSX;

[Serializable]
public class BUS : IDisposable
{
	private delegate uint ReadHandler(uint address);

	private delegate void WriteHandler(uint address, uint value);

	private delegate void Write16Handler(uint address, ushort value);

	private delegate void Write8Handler(uint address, byte value);

	private class AddressRange
	{
		public uint Start;

		public uint End;

		public ReadHandler Read32;

		public WriteHandler Write32;

		public Write16Handler Write16;

		public Write8Handler Write8;
	}

	private byte[] ram = new byte[2097152];

	private byte[] scrathpadram = new byte[1024];

	private byte[] biosram = new byte[524288];

	private byte[] sio = new byte[16];

	private byte[] memctl1 = new byte[64];

	private byte[] memctl2 = new byte[16];

	private byte[] spuram = new byte[524288];

	private uint memoryCache;

	public IRQController IRQCTL;

	public DMA dma;

	public CPU cpu;

	public GPU gpu;

	public CDData cddata;

	public CDROM cdrom;

	public TIMERS timers;

	public JoyBus joybus;

	[NonSerialized]
	public MDEC mdec;

	public SPU spu;

	public Expansion exp2;

	public Controller controller1;

	public Controller controller2;

	public MemCard memoryCard;

	public MemCard memoryCard2;

	[NonSerialized]
	public SerialIO SIO;

	public string DiskID = "";

	[NonSerialized]
	private List<AddressRange> _read32JumpTable;

	[NonSerialized]
	private List<AddressRange> _write32JumpTable;

	[NonSerialized]
	private List<AddressRange> _write16JumpTable;

	[NonSerialized]
	private List<AddressRange> _write8JumpTable;

	[NonSerialized]
	public unsafe byte* ramPtr = (byte*)Marshal.AllocHGlobal(2097152);

	[NonSerialized]
	private unsafe byte* scrathpadPtr = (byte*)Marshal.AllocHGlobal(1024);

	[NonSerialized]
	private unsafe byte* biosPtr = (byte*)Marshal.AllocHGlobal(524288);

	[NonSerialized]
	private unsafe byte* memoryControl1 = (byte*)Marshal.AllocHGlobal(64);

	[NonSerialized]
	private unsafe byte* memoryControl2 = (byte*)Marshal.AllocHGlobal(16);

	private static uint[] RegionMask = new uint[8] { 4294967295u, 4294967295u, 4294967295u, 4294967295u, 2147483647u, 536870911u, 4294967295u, 4294967295u };

	public unsafe BUS(ICoreHandler Host, string BiosFile, string RomFile, string diskid = "")
	{
		InitializeJumpTables();
		cddata = new CDData(RomFile, diskid);
		DiskID = cddata.DiskID;
		if (DiskID == "")
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("ISO " + RomFile + " Non PSX CDROM!");
			Console.ResetColor();
		}
		else if (LoadBios(BiosFile))
		{
			IRQCTL = new IRQController();
			dma = new DMA(this);
			spu = new SPU(Host, IRQCTL);
			cdrom = new CDROM(cddata, spu);
			SIO = new SerialIO();
			controller1 = new Controller();
			controller2 = new Controller();
			memoryCard = new MemCard("./Save/" + DiskID + ".dat");
			memoryCard2 = new MemCard("./Save/MemCard2.dat");
			joybus = new JoyBus(controller1, controller2, memoryCard, memoryCard2);
			gpu = new GPU(Host);
			timers = new TIMERS();
			mdec = new MDEC();
			exp2 = new Expansion();
			cpu = new CPU(this, isExecept: false);
		}
	}

	public void SwapDisk(string RomFile)
	{
		CDData cDData = new CDData(RomFile);
		if (cDData.DiskID == "")
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("ISO " + RomFile + " Non PSX CDROM!");
			Console.ResetColor();
		}
		else
		{
			cddata = cDData;
			DiskID = cddata.DiskID;
			cdrom.SwapDisk(cddata);
		}
	}

	public unsafe void ReadySerializable()
	{
		Marshal.Copy((nint)ramPtr, ram, 0, ram.Length);
		Marshal.Copy((nint)scrathpadPtr, scrathpadram, 0, scrathpadram.Length);
		Marshal.Copy((nint)biosPtr, biosram, 0, biosram.Length);
		Marshal.Copy((nint)memoryControl1, memctl1, 0, memctl1.Length);
		Marshal.Copy((nint)memoryControl2, memctl2, 0, memctl2.Length);
		Marshal.Copy((nint)spu.ram, spuram, 0, spuram.Length);
		gpu.ReadySerialized();
	}

	public unsafe void DeSerializable(ICoreHandler Host)
	{
		ramPtr = (byte*)Marshal.AllocHGlobal(2097152);
		scrathpadPtr = (byte*)Marshal.AllocHGlobal(1024);
		biosPtr = (byte*)Marshal.AllocHGlobal(524288);
		memoryControl1 = (byte*)Marshal.AllocHGlobal(64);
		memoryControl2 = (byte*)Marshal.AllocHGlobal(16);
		spu.ram = (byte*)Marshal.AllocHGlobal(524288);
		Marshal.Copy(ram, 0, (nint)ramPtr, ram.Length);
		Marshal.Copy(scrathpadram, 0, (nint)scrathpadPtr, scrathpadram.Length);
		Marshal.Copy(biosram, 0, (nint)biosPtr, biosram.Length);
		Marshal.Copy(memctl1, 0, (nint)memoryControl1, memctl1.Length);
		Marshal.Copy(memctl2, 0, (nint)memoryControl2, memctl2.Length);
		Marshal.Copy(spuram, 0, (nint)spu.ram, spuram.Length);
		InitializeJumpTables();
		mdec = new MDEC();
		SIO = new SerialIO();
		spu.host = Host;
		gpu.host = Host;
		gpu.Manger = new GPUManager();
		gpu.SelectGPU();
		gpu.DeSerialized();
		cddata.LoadFileStream();
	}

	public unsafe void Dispose()
	{
		Marshal.FreeHGlobal((nint)ramPtr);
		Marshal.FreeHGlobal((nint)scrathpadPtr);
		Marshal.FreeHGlobal((nint)biosPtr);
		Marshal.FreeHGlobal((nint)memoryControl1);
		Marshal.FreeHGlobal((nint)memoryControl2);
		Marshal.FreeHGlobal((nint)spu.ram);
	}

	public unsafe bool LoadBios(string biosfile)
	{
		try
		{
			byte[] array = File.ReadAllBytes(biosfile);
			Marshal.Copy(array, 0, (nint)biosPtr, array.Length);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[BIOS] " + Path.GetFileName(biosfile) + " loaded.");
			Console.ResetColor();
			return true;
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("[BIOS] " + Path.GetFileName(biosfile) + " not found.\n" + ex.Message);
			return false;
		}
	}

	private void InitializeJumpTables()
	{
		_read32JumpTable = new List<AddressRange>();
		_write32JumpTable = new List<AddressRange>();
		_write16JumpTable = new List<AddressRange>();
		_write8JumpTable = new List<AddressRange>();
		AddReadHandler(528488464u, 528488465u, (uint addr) => gpu.GPUREAD());
		AddReadHandler(528488468u, 528488469u, (uint addr) => gpu.GPUSTAT());
		AddReadHandler(528488496u, 528490496u, (uint addr) => spu.read(addr));
		AddReadHandler(528486528u, 528486656u, (uint addr) => dma.read(addr));
		AddReadHandler(528486720u, 528488452u, (uint addr) => cdrom.read(addr));
		AddReadHandler(528482304u, 528483328u, (uint addr) => ReadScratchpad(addr));
		AddReadHandler(528483328u, 528486464u, (uint addr) => ReadMemoryControl1(addr));
		AddReadHandler(528486496u, 528486512u, (uint addr) => ReadMemoryControl2(addr));
		AddReadHandler(528486512u, 528486528u, (uint addr) => IRQCTL.read(addr));
		AddReadHandler(4294836528u, 4294836529u, (uint addr) => memoryCache);
		AddReadHandler(528486464u, 528486480u, (uint addr) => joybus.read(addr));
		AddReadHandler(528486480u, 528486496u, (uint addr) => SIO.read(addr));
		AddReadHandler(528486656u, 528486720u, (uint addr) => timers.read(addr));
		AddReadHandler(528488480u, 528488481u, (uint addr) => mdec.readMDEC0_Data());
		AddReadHandler(528488484u, 528488485u, (uint addr) => mdec.readMDEC1_Status());
		AddReadHandler(528490496u, 528498688u, (uint addr) => exp2.read(addr));
		AddReadHandler(520093696u, 528482304u, (uint addr) => 0u);
		AddWriteHandler(528488464u, 528488480u, delegate(uint addr, uint value)
		{
			gpu.write(addr, value);
		});
		AddWriteHandler(528488496u, 528490496u, delegate(uint addr, uint value)
		{
			spu.write(addr, (ushort)value);
		});
		AddWriteHandler(528486528u, 528486656u, delegate(uint addr, uint value)
		{
			dma.write(addr, value);
		});
		AddWriteHandler(528486720u, 528488464u, delegate(uint addr, uint value)
		{
			cdrom.write(addr, (byte)value);
		});
		AddWriteHandler(528482304u, 528483328u, delegate(uint addr, uint value)
		{
			WriteScratchpad32(addr, value);
		});
		AddWriteHandler(528483328u, 528486464u, delegate(uint addr, uint value)
		{
			WriteMemoryContro1_32(addr, value);
		});
		AddWriteHandler(528486496u, 528486512u, delegate(uint addr, uint value)
		{
			WriteMemoryContro2_32(addr, value);
		});
		AddWriteHandler(528486512u, 528486528u, delegate(uint addr, uint value)
		{
			IRQCTL.write(addr, value);
		});
		AddWriteHandler(4294836528u, 4294836529u, delegate(uint addr, uint value)
		{
			memoryCache = value;
		});
		AddWriteHandler(528486464u, 528486480u, delegate(uint addr, uint value)
		{
			joybus.write(addr, value);
		});
		AddWriteHandler(528486480u, 528486496u, delegate(uint addr, uint value)
		{
			SIO.write(addr, value);
		});
		AddWriteHandler(528486656u, 528486720u, delegate(uint addr, uint value)
		{
			timers.write(addr, value);
		});
		AddWriteHandler(528488480u, 528488496u, delegate(uint addr, uint value)
		{
			mdec.write(addr, value);
		});
		AddWriteHandler(528490496u, 528498688u, delegate(uint addr, uint value)
		{
			exp2.write(addr, value);
		});
		AddWriteHandler(520093696u, 528482304u, delegate
		{
		});
		AddWrite16Handler(528488464u, 528488480u, delegate(uint addr, ushort value)
		{
			gpu.write(addr, value);
		});
		AddWrite16Handler(528488496u, 528490496u, delegate(uint addr, ushort value)
		{
			spu.write(addr, value);
		});
		AddWrite16Handler(528486528u, 528486656u, delegate(uint addr, ushort value)
		{
			dma.write(addr, value);
		});
		AddWrite16Handler(528482304u, 528483328u, delegate(uint addr, ushort value)
		{
			WriteScratchpad16(addr, value);
		});
		AddWrite16Handler(528486720u, 528488464u, delegate(uint addr, ushort value)
		{
			cdrom.write(addr, (byte)value);
		});
		AddWrite16Handler(528486512u, 528486528u, delegate(uint addr, ushort value)
		{
			IRQCTL.write(addr, value);
		});
		AddWrite16Handler(528483328u, 528486464u, delegate(uint addr, ushort value)
		{
			WriteMemoryContro1_16(addr, value);
		});
		AddWrite16Handler(528486496u, 528486512u, delegate(uint addr, ushort value)
		{
			WriteMemoryContro2_16(addr, value);
		});
		AddWrite16Handler(4294836528u, 4294836529u, delegate(uint addr, ushort value)
		{
			memoryCache = value;
		});
		AddWrite16Handler(528486464u, 528486480u, delegate(uint addr, ushort value)
		{
			joybus.write(addr, value);
		});
		AddWrite16Handler(528486656u, 528486720u, delegate(uint addr, ushort value)
		{
			timers.write(addr, value);
		});
		AddWrite16Handler(528488480u, 528488496u, delegate(uint addr, ushort value)
		{
			mdec.write(addr, value);
		});
		AddWrite16Handler(528490496u, 528498688u, delegate(uint addr, ushort value)
		{
			exp2.write(addr, value);
		});
		AddWrite16Handler(528486480u, 528486496u, delegate(uint addr, ushort value)
		{
			SIO.write(addr, value);
		});
		AddWrite16Handler(520093696u, 528482304u, delegate
		{
		});
		AddWrite8Handler(528488464u, 528488480u, delegate(uint addr, byte value)
		{
			gpu.write(addr, value);
		});
		AddWrite8Handler(528488496u, 528490496u, delegate(uint addr, byte value)
		{
			spu.write(addr, value);
		});
		AddWrite8Handler(528486528u, 528486656u, delegate(uint addr, byte value)
		{
			dma.write(addr, value);
		});
		AddWrite8Handler(528486720u, 528488464u, delegate(uint addr, byte value)
		{
			cdrom.write(addr, value);
		});
		AddWrite8Handler(528482304u, 528483328u, delegate(uint addr, byte value)
		{
			WriteScratchpad8(addr, value);
		});
		AddWrite8Handler(528483328u, 528486464u, delegate(uint addr, byte value)
		{
			WriteMemoryContro1_8(addr, value);
		});
		AddWrite8Handler(528486496u, 528486512u, delegate(uint addr, byte value)
		{
			WriteMemoryContro2_8(addr, value);
		});
		AddWrite8Handler(528486512u, 528486528u, delegate(uint addr, byte value)
		{
			IRQCTL.write(addr, value);
		});
		AddWrite8Handler(4294836528u, 4294836529u, delegate(uint addr, byte value)
		{
			memoryCache = value;
		});
		AddWrite8Handler(528486464u, 528486480u, delegate(uint addr, byte value)
		{
			joybus.write(addr, value);
		});
		AddWrite8Handler(528486656u, 528486720u, delegate(uint addr, byte value)
		{
			timers.write(addr, value);
		});
		AddWrite8Handler(528488480u, 528488496u, delegate(uint addr, byte value)
		{
			mdec.write(addr, value);
		});
		AddWrite8Handler(528490496u, 528498688u, delegate(uint addr, byte value)
		{
			exp2.write(addr, value);
		});
		AddWrite8Handler(528486480u, 528486496u, delegate(uint addr, byte value)
		{
			SIO.write(addr, value);
		});
		AddWrite8Handler(520093696u, 528482304u, delegate
		{
		});
	}

	private void AddReadHandler(uint start, uint end, ReadHandler handler)
	{
		_read32JumpTable.Add(new AddressRange
		{
			Start = start,
			End = end,
			Read32 = handler
		});
		_read32JumpTable.Sort((AddressRange a, AddressRange b) => a.Start.CompareTo(b.Start));
	}

	private void AddWriteHandler(uint start, uint end, WriteHandler handler)
	{
		_write32JumpTable.Add(new AddressRange
		{
			Start = start,
			End = end,
			Write32 = handler
		});
		_write32JumpTable.Sort((AddressRange a, AddressRange b) => a.Start.CompareTo(b.Start));
	}

	private void AddWrite16Handler(uint start, uint end, Write16Handler handler)
	{
		_write16JumpTable.Add(new AddressRange
		{
			Start = start,
			End = end,
			Write16 = handler
		});
		_write16JumpTable.Sort((AddressRange a, AddressRange b) => a.Start.CompareTo(b.Start));
	}

	private void AddWrite8Handler(uint start, uint end, Write8Handler handler)
	{
		_write8JumpTable.Add(new AddressRange
		{
			Start = start,
			End = end,
			Write8 = handler
		});
		_write8JumpTable.Sort((AddressRange a, AddressRange b) => a.Start.CompareTo(b.Start));
	}

	private unsafe uint BusReadRam(uint address)
	{
		return *(uint*)(ramPtr + (address & 0x1FFFFF));
	}

	private unsafe uint BusReadBios(uint address)
	{
		return *(uint*)(biosPtr + (address & 0x7FFFF));
	}

	private unsafe uint ReadScratchpad(uint address)
	{
		return *(uint*)(scrathpadPtr + (address & 0x3FF));
	}

	private unsafe uint ReadMemoryControl1(uint address)
	{
		return *(uint*)(memoryControl1 + (address & 0x3F));
	}

	private unsafe uint ReadMemoryControl2(uint address)
	{
		return *(uint*)(memoryControl2 + (address & 0xF));
	}

	private unsafe void WriteRam(uint address, uint value)
	{
		*(uint*)(ramPtr + (address & 0x1FFFFF)) = value;
	}

	private unsafe void WriteRam16(uint addr, ushort value)
	{
		*(ushort*)(ramPtr + (addr & 0x1FFFFF)) = value;
	}

	private unsafe void WriteRam8(uint addr, byte value)
	{
		ramPtr[addr & 0x1FFFFF] = value;
	}

	private unsafe void WriteScratchpad32(uint address, uint value)
	{
		*(uint*)(scrathpadPtr + (address & 0x3FF)) = value;
	}

	private unsafe void WriteScratchpad16(uint address, ushort value)
	{
		*(ushort*)(scrathpadPtr + (address & 0x3FF)) = value;
	}

	private unsafe void WriteScratchpad8(uint address, byte value)
	{
		scrathpadPtr[address & 0x3FF] = value;
	}

	private unsafe void WriteMemoryContro1_32(uint addr, uint value)
	{
		*(uint*)(memoryControl1 + (addr & 0x3F)) = value;
	}

	private unsafe void WriteMemoryContro1_16(uint addr, ushort value)
	{
		*(ushort*)(memoryControl1 + (addr & 0x3F)) = value;
	}

	private unsafe void WriteMemoryContro1_8(uint addr, byte value)
	{
		memoryControl1[addr & 0x3F] = value;
	}

	private unsafe void WriteMemoryContro2_32(uint addr, uint value)
	{
		*(uint*)(memoryControl2 + (addr & 0xF)) = value;
	}

	private unsafe void WriteMemoryContro2_16(uint addr, ushort value)
	{
		*(ushort*)(memoryControl2 + (addr & 0xF)) = value;
	}

	private unsafe void WriteMemoryContro2_8(uint addr, byte value)
	{
		memoryControl2[addr & 0xF] = value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe uint read32(uint address)
	{
		uint mask = GetMask(address);
		if (mask < 520093696)
		{
			return *(uint*)(ramPtr + (mask & 0x1FFFFF));
		}
		if (mask >= 532676608 && mask < 533200896)
		{
			return *(uint*)(biosPtr + (mask & 0x7FFFF));
		}
		int num = 0;
		int num2 = _read32JumpTable.Count - 1;
		while (num <= num2)
		{
			int num3 = (num + num2) / 2;
			AddressRange addressRange = _read32JumpTable[num3];
			if (mask < addressRange.Start)
			{
				num2 = num3 - 1;
				continue;
			}
			if (mask >= addressRange.End)
			{
				num = num3 + 1;
				continue;
			}
			return addressRange.Read32(mask);
		}
		Console.WriteLine($"[BUS] Read32 Unsupported: {address:x8} mask {mask:x8}");
		return uint.MaxValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void write32(uint address, uint value)
	{
		uint mask = GetMask(address);
		if (mask < 520093696)
		{
			*(uint*)(ramPtr + (mask & 0x1FFFFF)) = value;
			return;
		}
		int num = 0;
		int num2 = _write32JumpTable.Count - 1;
		while (num <= num2)
		{
			int num3 = (num + num2) / 2;
			AddressRange addressRange = _write32JumpTable[num3];
			if (mask < addressRange.Start)
			{
				num2 = num3 - 1;
				continue;
			}
			if (mask >= addressRange.End)
			{
				num = num3 + 1;
				continue;
			}
			addressRange.Write32(mask, value);
			return;
		}
		Console.WriteLine($"[BUS] Write32 Unsupported: {address:x8} mask {mask:x8}");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void write16(uint address, ushort value)
	{
		uint mask = GetMask(address);
		if (mask < 520093696)
		{
			*(ushort*)(ramPtr + (mask & 0x1FFFFF)) = value;
			return;
		}
		int num = 0;
		int num2 = _write16JumpTable.Count - 1;
		while (num <= num2)
		{
			int num3 = (num + num2) / 2;
			AddressRange addressRange = _write16JumpTable[num3];
			if (mask < addressRange.Start)
			{
				num2 = num3 - 1;
				continue;
			}
			if (mask >= addressRange.End)
			{
				num = num3 + 1;
				continue;
			}
			addressRange.Write16(mask, value);
			return;
		}
		Console.WriteLine($"[BUS] Write16 Unsupported: {address:x8} mask {mask:x8}");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void write8(uint address, byte value)
	{
		uint mask = GetMask(address);
		if (mask < 520093696)
		{
			ramPtr[mask & 0x1FFFFF] = value;
			return;
		}
		int num = 0;
		int num2 = _write8JumpTable.Count - 1;
		while (num <= num2)
		{
			int num3 = (num + num2) / 2;
			AddressRange addressRange = _write8JumpTable[num3];
			if (mask < addressRange.Start)
			{
				num2 = num3 - 1;
				continue;
			}
			if (mask >= addressRange.End)
			{
				num = num3 + 1;
				continue;
			}
			addressRange.Write8(mask, value);
			return;
		}
		Console.WriteLine($"[BUS] Write8 Unsupported: {address:x8} mask {mask:x8}");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void tick(int cycles)
	{
		if (gpu.tick(cycles))
		{
			IRQCTL.set(Interrupt.VBLANK);
		}
		if (cdrom.tick(cycles))
		{
			IRQCTL.set(Interrupt.CDROM);
		}
		if (dma.tick())
		{
			IRQCTL.set(Interrupt.DMA);
		}
		timers.syncGPU(gpu.GetBlanksAndDot());
		if (timers.tick(0, cycles))
		{
			IRQCTL.set(Interrupt.TIMER0);
		}
		if (timers.tick(1, cycles))
		{
			IRQCTL.set(Interrupt.TIMER1);
		}
		if (timers.tick(2, cycles))
		{
			IRQCTL.set(Interrupt.TIMER2);
		}
		if (joybus.tick())
		{
			IRQCTL.set(Interrupt.CONTR);
		}
		if (spu.tick(cycles))
		{
			IRQCTL.set(Interrupt.SPU);
		}
		if (SIO.tick(cycles))
		{
			IRQCTL.set(Interrupt.SIO);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe T read<T>(uint addr, byte* ptr) where T : unmanaged
	{
		return *(T*)(ptr + addr);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void write<T>(uint addr, T value, byte* ptr) where T : unmanaged
	{
		*(T*)(ptr + addr) = value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe uint ReadRam(uint addr)
	{
		return *(uint*)(ramPtr + (addr & 0x1FFFFF));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe uint ReadBios(uint addr)
	{
		return *(uint*)(biosPtr + (addr & 0x7FFFF));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe Span<uint> DmaFromRam(uint addr, uint size)
	{
		return new Span<uint>(ramPtr + (addr & 0x1FFFFF), (int)size);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void DmaToRam(uint addr, uint value)
	{
		*(uint*)(ramPtr + (addr & 0x1FFFFF)) = value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void DmaToRam(uint addr, byte[] buffer, uint size)
	{
		fixed (byte* ptr2 = buffer)
		{
			byte* ptr = ramPtr + (addr & 0x1FFFFF);
			if (((ulong)ptr & 3uL) == 0L)
			{
				Buffer.MemoryCopy(ptr2, ptr, size, size);
			}
			else
			{
				ManualAlignedCopy(ptr2, ptr, size);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe void ManualAlignedCopy(byte* src, byte* dest, uint size)
	{
		for (uint num = 0u; num < size; num++)
		{
			dest[num] = src[num];
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DmaFromGpu(uint address, int size)
	{
		for (int i = 0; i < size; i++)
		{
			uint value = gpu.GPUREAD();
			DmaToRam(address, value);
			address += 4;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DmaToGpu(Span<uint> buffer)
	{
		gpu.ProcessDma(buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void DmaFromCD(uint address, int size)
	{
		Span<uint> span = cdrom.processDmaRead(size);
		Span<uint> destination = new Span<uint>(ramPtr + (address & 0x1FFFFC), size);
		span.CopyTo(destination);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DmaToMdecIn(Span<uint> dma)
	{
		Span<uint> span = dma;
		for (int i = 0; i < span.Length; i++)
		{
			uint value = span[i];
			mdec.writeMDEC0_Command(value);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void DmaFromMdecOut(uint address, int size)
	{
		Span<uint> span = mdec.processDmaLoad(size);
		Span<uint> destination = new Span<uint>(ramPtr + (address & 0x1FFFFC), size);
		span.CopyTo(destination);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DmaToSpu(Span<uint> dma)
	{
		spu.processDmaWrite(dma);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void DmaFromSpu(uint address, int size)
	{
		Span<uint> span = spu.processDmaRead(size);
		Span<uint> destination = new Span<uint>(ramPtr + (address & 0x1FFFFC), size);
		span.CopyTo(destination);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DmaOTC(uint baseAddress, int size)
	{
		for (int i = 0; i < size - 1; i++)
		{
			DmaToRam(baseAddress, baseAddress - 4);
			baseAddress -= 4;
		}
		DmaToRam(baseAddress, 16777215u);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public uint GetMask(uint address)
	{
		uint num = address >> 29;
		return address & RegionMask[num];
	}

	public unsafe void LoadEXE(string fileName)
	{
		byte[] array = File.ReadAllBytes(fileName);
		uint num = Unsafe.As<byte, uint>(ref array[16]);
		uint num2 = Unsafe.As<byte, uint>(ref array[20]);
		uint num3 = Unsafe.As<byte, uint>(ref array[48]);
		uint num4 = num3;
		num4 += Unsafe.As<byte, uint>(ref array[52]);
		uint num5 = Unsafe.As<byte, uint>(ref array[24]);
		Console.WriteLine($"SideLoad PSX EXE: PC {num:x8} R28 {num2:x8} R29 {num3:x8} R30 {num4:x8}");
		Marshal.Copy(array, 2048, (nint)(ramPtr + (num5 & 0x1FFFFF)), array.Length - 2048);
		write(28656u, 0x3C080000 | (num >> 16), biosPtr);
		write(28660u, 0x35080000 | (num & 0xFFFF), biosPtr);
		write(28664u, 0x3C1C0000 | (num2 >> 16), biosPtr);
		write(28668u, 0x379C0000 | (num2 & 0xFFFF), biosPtr);
		if (num3 != 0)
		{
			write(28672u, 0x3C1D0000 | (num3 >> 16), biosPtr);
			write(28676u, 0x37BD0000 | (num3 & 0xFFFF), biosPtr);
			write(28680u, 0x3C1E0000 | (num4 >> 16), biosPtr);
			write(28684u, 0x37DE0000 | (num4 & 0xFFFF), biosPtr);
			write(28688u, 16777224, biosPtr);
			write(28692u, 0, biosPtr);
		}
		else
		{
			write(28672u, 16777224, biosPtr);
			write(28676u, 0, biosPtr);
		}
	}
}
