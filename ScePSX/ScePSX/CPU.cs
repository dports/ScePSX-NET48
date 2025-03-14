using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ScePSX.Disassembler;

namespace ScePSX;

[Serializable]
public class CPU
{
	[Serializable]
	private struct MEM
	{
		public uint register;

		public uint value;
	}

	[Serializable]
	public struct Instr
	{
		public uint value;

		public uint opcode => value >> 26;

		public uint rs => (value >> 21) & 0x1F;

		public uint rt => (value >> 16) & 0x1F;

		public uint imm => (ushort)value;

		public uint imm_s => (uint)(short)value;

		public uint rd => (value >> 11) & 0x1F;

		public uint sa => (value >> 6) & 0x1F;

		public uint function => value & 0x3F;

		public uint addr => value & 0x3FFFFFF;

		public uint id => opcode & 3;
	}

	public enum EX
	{
		INTERRUPT = 0,
		READ_ADRESS_ERROR = 4,
		WRITE_ADRESS_ERROR = 5,
		BUS_ERROR_FETCH = 6,
		SYSCALL = 8,
		BREAK = 9,
		ILLEGAL_INSTR = 10,
		COPROCESSOR_ERROR = 11,
		OVERFLOW = 12
	}

	private static Action<CPU> handleFetchDecodeException;

	private static Action<CPU, uint> handleLWException;

	private static Action<CPU, uint> handleSWException;

	private static Action<CPU, uint, uint, uint> handleAddException;

	private static Action<CPU, uint, uint, uint> handleAddiException;

	private static Action<CPU, uint, uint, uint> handleSubException;

	private static Action<CPU, uint> handleLHException;

	private static Action<CPU, uint> handleLHUException;

	private static Action<CPU, uint> handleSHException;

	private static Action<CPU, uint> handleLWC2Exception;

	private static Action<CPU, uint> handleSWC2Exception;

	private uint PC_Now;

	private uint PC;

	private uint PC_Predictor;

	private uint[] GPR;

	private uint HI;

	private uint LO;

	private bool opcodeIsBranch;

	private bool opcodeIsDelaySlot;

	private bool opcodeTookBranch;

	private bool opcodeInDelaySlotTookBranch;

	private static uint[] ExceptionAdress;

	private uint[] COP0_GPR;

	private const int SR = 12;

	private const int CAUSE = 13;

	private const int EPC = 14;

	private const int BADA = 8;

	private const int JUMPDEST = 6;

	private bool dontIsolateCache;

	private MEM writeBack;

	private MEM memoryread;

	private MEM delayedMemoryread;

	private Instr instr;

	private GTE gte;

	private BUS bus;

	private BIOS_Disassembler bios;

	private MIPS_Disassembler mips;

	public bool debug;

	public bool biosdebug;

	public bool ttydebug;

	public int cylesfix = 2;

	private unsafe static delegate*<CPU, void>[] opcodeMainTable = new delegate*<CPU, void>[64]
	{
		&SPECIAL,
		&BCOND,
		&J,
		&JAL,
		&BEQ,
		&BNE,
		&BLEZ,
		&BGTZ,
		&ADDI,
		&ADDIU,
		&SLTI,
		&SLTIU,
		&ANDI,
		&ORI,
		&XORI,
		&LUI,
		&COP0,
		&NOP,
		&COP2,
		&NOP,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&LB,
		&LH,
		&LWL,
		&LW,
		&LBU,
		&LHU,
		&LWR,
		&NA,
		&SB,
		&SH,
		&SWL,
		&SW,
		&NA,
		&NA,
		&SWR,
		&NA,
		&NOP,
		&NOP,
		&LWC2,
		&NOP,
		&NA,
		&NA,
		&NA,
		&NA,
		&NOP,
		&NOP,
		&SWC2,
		&NOP,
		&NA,
		&NA,
		&NA,
		&NA
	};

	private unsafe static delegate*<CPU, void>[] opcodeSpecialTable = new delegate*<CPU, void>[64]
	{
		&SLL,
		&NA,
		&SRL,
		&SRA,
		&SLLV,
		&NA,
		&SRLV,
		&SRAV,
		&JR,
		&JALR,
		&NA,
		&NA,
		&SYSCALL,
		&BREAK,
		&NA,
		&NA,
		&MFHI,
		&MTHI,
		&MFLO,
		&MTLO,
		&NA,
		&NA,
		&NA,
		&NA,
		&MULT,
		&MULTU,
		&DIV,
		&DIVU,
		&NA,
		&NA,
		&NA,
		&NA,
		&ADD,
		&ADDU,
		&SUB,
		&SUBU,
		&AND,
		&OR,
		&XOR,
		&NOR,
		&NA,
		&NA,
		&SLT,
		&SLTU,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA,
		&NA
	};

	public CPU(BUS bus, bool isExecept)
	{
		this.bus = bus;
		gte = new GTE();
		Reset();
		SetExecution(isExecept);
	}

	public void Reset()
	{
		PC = 3217031168u;
		PC_Predictor = 3217031172u;
		GPR = new uint[32];
		opcodeIsBranch = false;
		opcodeIsDelaySlot = false;
		opcodeTookBranch = false;
		opcodeInDelaySlotTookBranch = false;
		ExceptionAdress = new uint[2] { 2147483776u, 3217031552u };
		COP0_GPR = new uint[16];
		COP0_GPR[15] = 2u;
		bios = new BIOS_Disassembler(bus);
		mips = new MIPS_Disassembler(ref HI, ref LO, GPR, COP0_GPR);
	}

	public void disassemblePC()
	{
		mips.PrintRegs();
		mips.disassemble(instr, PC_Now, PC_Predictor);
	}

	private void TTY()
	{
		if ((PC == 176 && GPR[9] == 61) || (PC == 160 && GPR[9] == 60))
		{
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write((char)GPR[4]);
			Console.ResetColor();
		}
	}

	public static void SetExecution(bool enableExceptions)
	{
		if (enableExceptions)
		{
			handleFetchDecodeException = delegate(CPU cpu)
			{
				if ((cpu.PC_Now & 3) != 0)
				{
					cpu.COP0_GPR[8] = cpu.PC_Now;
					EXCEPTION(cpu, EX.READ_ADRESS_ERROR);
				}
			};
			handleLWException = delegate(CPU cpu, uint addr)
			{
				if ((addr & 3) != 0)
				{
					cpu.COP0_GPR[8] = addr;
					EXCEPTION(cpu, EX.READ_ADRESS_ERROR, cpu.instr.id);
				}
			};
			handleSWException = delegate(CPU cpu, uint addr)
			{
				if ((addr & 3) != 0)
				{
					cpu.COP0_GPR[8] = addr;
					EXCEPTION(cpu, EX.WRITE_ADRESS_ERROR, cpu.instr.id);
				}
			};
			handleAddException = delegate(CPU cpu, uint rs, uint rt, uint result)
			{
				if (checkOverflow(rs, rt, result))
				{
					EXCEPTION(cpu, EX.OVERFLOW, cpu.instr.id);
				}
				else
				{
					cpu.setGPR(cpu.instr.rd, result);
				}
			};
			handleAddiException = delegate(CPU cpu, uint rs, uint imm_s, uint result)
			{
				if (checkOverflow(rs, imm_s, result))
				{
					EXCEPTION(cpu, EX.OVERFLOW, cpu.instr.id);
				}
				else
				{
					cpu.setGPR(cpu.instr.rt, result);
				}
			};
			handleSubException = delegate(CPU cpu, uint rs, uint rt, uint result)
			{
				if (checkUnderflow(rs, rt, result))
				{
					EXCEPTION(cpu, EX.OVERFLOW, cpu.instr.id);
				}
				else
				{
					cpu.setGPR(cpu.instr.rd, result);
				}
			};
			handleLHException = delegate(CPU cpu, uint addr)
			{
				if ((addr & 1) != 0)
				{
					cpu.COP0_GPR[8] = addr;
					EXCEPTION(cpu, EX.READ_ADRESS_ERROR, cpu.instr.id);
				}
			};
			handleLHUException = delegate(CPU cpu, uint addr)
			{
				if ((addr & 1) != 0)
				{
					cpu.COP0_GPR[8] = addr;
					EXCEPTION(cpu, EX.READ_ADRESS_ERROR, cpu.instr.id);
				}
			};
			handleSHException = delegate(CPU cpu, uint addr)
			{
				if ((addr & 1) != 0)
				{
					cpu.COP0_GPR[8] = addr;
					EXCEPTION(cpu, EX.WRITE_ADRESS_ERROR, cpu.instr.id);
				}
			};
			handleLWC2Exception = delegate(CPU cpu, uint addr)
			{
				if ((addr & 3) != 0)
				{
					cpu.COP0_GPR[8] = addr;
					EXCEPTION(cpu, EX.READ_ADRESS_ERROR, cpu.instr.id);
				}
			};
			handleSWC2Exception = delegate(CPU cpu, uint addr)
			{
				if ((addr & 3) != 0)
				{
					cpu.COP0_GPR[8] = addr;
					EXCEPTION(cpu, EX.READ_ADRESS_ERROR, cpu.instr.id);
				}
			};
		}
		else
		{
			handleFetchDecodeException = delegate
			{
			};
			handleLWException = delegate
			{
			};
			handleSWException = delegate
			{
			};
			handleAddException = delegate(CPU cpu, uint rs, uint rt, uint result)
			{
				cpu.setGPR(cpu.instr.rd, result);
			};
			handleAddiException = delegate(CPU cpu, uint rs, uint imm_s, uint result)
			{
				cpu.setGPR(cpu.instr.rt, result);
			};
			handleSubException = delegate(CPU cpu, uint rs, uint rt, uint result)
			{
				cpu.setGPR(cpu.instr.rd, result);
			};
			handleLHException = delegate
			{
			};
			handleLHUException = delegate
			{
			};
			handleSHException = delegate
			{
			};
			handleLWC2Exception = delegate
			{
			};
			handleSWC2Exception = delegate
			{
			};
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe int tick()
	{
		int result = fetchDecode();
		if (instr.value != 0)
		{
			((delegate*<CPU, void>)((IntPtr[])(object)opcodeMainTable)[instr.opcode])(this);
		}
		MemAccess();
		WriteBack();
		if (debug)
		{
			disassemblePC();
		}
		if (biosdebug)
		{
			bios.verbose(PC_Now, GPR);
		}
		if (ttydebug)
		{
			TTY();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void handleInterrupts()
	{
		uint num = PC & 0x1FFFFFFF;
		uint num2 = ((num >= 520093696) ? bus.ReadBios(num) : bus.ReadRam(num));
		if (num2 >> 26 != 18)
		{
			if (bus.IRQCTL.interruptPending())
			{
				COP0_GPR[13] |= 1024u;
			}
			else
			{
				COP0_GPR[13] &= 4294966271u;
			}
			bool num3 = (COP0_GPR[12] & 1) == 1;
			byte b = (byte)((COP0_GPR[12] >> 8) & 0xFF);
			byte b2 = (byte)((COP0_GPR[13] >> 8) & 0xFF);
			if (num3 && (b & b2) > 0)
			{
				EXCEPTION(this, EX.INTERRUPT);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int fetchDecode()
	{
		uint num = PC & 0x1FFFFFFF;
		PC_Now = PC;
		PC = PC_Predictor;
		PC_Predictor += 4u;
		opcodeIsDelaySlot = opcodeIsBranch;
		opcodeInDelaySlotTookBranch = opcodeTookBranch;
		opcodeIsBranch = false;
		opcodeTookBranch = false;
		handleFetchDecodeException(this);
		if (num < 520093696)
		{
			instr.value = bus.ReadRam(num);
			return 1;
		}
		instr.value = bus.ReadBios(num);
		return 20;
	}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private unsafe void MemAccess()
    {
        if (delayedMemoryread.register != memoryread.register)
        {
            fixed (uint* gprPtr = GPR)
            {
                *(gprPtr + (int)memoryread.register) = memoryread.value;
            }
        }
        memoryread = delayedMemoryread;
        delayedMemoryread.register = 0u;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private unsafe void WriteBack()
    {
        fixed (uint* gprPtr = GPR)
        {
            *(gprPtr + (int)writeBack.register) = writeBack.value;
            writeBack.register = 0u;
            *gprPtr = 0u;
        }
    }

    private static void NOP(CPU cpu)
	{
	}

	private static void NA(CPU cpu)
	{
		EXCEPTION(cpu, EX.ILLEGAL_INSTR, cpu.instr.id);
	}

	private unsafe static void SPECIAL(CPU cpu)
	{
		((delegate*<CPU, void>)((IntPtr[])(object)opcodeSpecialTable)[cpu.instr.function])(cpu);
	}

	private static void BCOND(CPU cpu)
	{
		cpu.opcodeIsBranch = true;
		uint rt = cpu.instr.rt;
		bool flag = (rt & 0x1E) == 16;
		bool num = (int)(cpu.GPR[cpu.instr.rs] ^ (rt << 31)) < 0;
		if (flag)
		{
			cpu.GPR[31] = cpu.PC_Predictor;
		}
		if (num)
		{
			BRANCH(cpu);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void J(CPU cpu)
	{
		cpu.opcodeIsBranch = true;
		cpu.opcodeTookBranch = true;
		cpu.PC_Predictor = (cpu.PC_Predictor & 0xF0000000u) | (cpu.instr.addr << 2);
	}

	private static void JAL(CPU cpu)
	{
		cpu.setGPR(31u, cpu.PC_Predictor);
		J(cpu);
	}

	private static void BEQ(CPU cpu)
	{
		cpu.opcodeIsBranch = true;
		if (cpu.GPR[cpu.instr.rs] == cpu.GPR[cpu.instr.rt])
		{
			BRANCH(cpu);
		}
	}

	private static void BNE(CPU cpu)
	{
		cpu.opcodeIsBranch = true;
		if (cpu.GPR[cpu.instr.rs] != cpu.GPR[cpu.instr.rt])
		{
			BRANCH(cpu);
		}
	}

	private static void BLEZ(CPU cpu)
	{
		cpu.opcodeIsBranch = true;
		if ((int)cpu.GPR[cpu.instr.rs] <= 0)
		{
			BRANCH(cpu);
		}
	}

	private static void BGTZ(CPU cpu)
	{
		cpu.opcodeIsBranch = true;
		if ((int)cpu.GPR[cpu.instr.rs] > 0)
		{
			BRANCH(cpu);
		}
	}

	private static void ADDI(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs];
		uint imm_s = cpu.instr.imm_s;
		uint arg = num + imm_s;
		handleAddiException(cpu, num, imm_s, arg);
	}

	private static void ADDIU(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rt, cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s);
	}

	private static void SLTI(CPU cpu)
	{
		bool source = (int)cpu.GPR[cpu.instr.rs] < (int)cpu.instr.imm_s;
		cpu.setGPR(cpu.instr.rt, Unsafe.As<bool, uint>(ref source));
	}

	private static void SLTIU(CPU cpu)
	{
		bool source = cpu.GPR[cpu.instr.rs] < cpu.instr.imm_s;
		cpu.setGPR(cpu.instr.rt, Unsafe.As<bool, uint>(ref source));
	}

	private static void ANDI(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rt, cpu.GPR[cpu.instr.rs] & cpu.instr.imm);
	}

	private static void ORI(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rt, cpu.GPR[cpu.instr.rs] | cpu.instr.imm);
	}

	private static void XORI(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rt, cpu.GPR[cpu.instr.rs] ^ cpu.instr.imm);
	}

	private static void LUI(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rt, cpu.instr.imm << 16);
	}

	private static void COP0(CPU cpu)
	{
		if (cpu.instr.rs == 0)
		{
			MFC0(cpu);
		}
		else if (cpu.instr.rs == 4)
		{
			MTC0(cpu);
		}
		else if (cpu.instr.rs == 16)
		{
			RFE(cpu);
		}
		else
		{
			EXCEPTION(cpu, EX.ILLEGAL_INSTR, cpu.instr.id);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void MFC0(CPU cpu)
	{
		uint rd = cpu.instr.rd;
		switch (rd)
		{
		default:
			if (rd < 11 || rd > 15)
			{
				break;
			}
			goto case 3u;
		case 3u:
		case 5u:
		case 6u:
		case 7u:
		case 8u:
		case 9u:
			delayedread(cpu, cpu.instr.rt, cpu.COP0_GPR[rd]);
			return;
		}
		EXCEPTION(cpu, EX.ILLEGAL_INSTR, cpu.instr.id);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void MTC0(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rt];
		uint rd = cpu.instr.rd;
		switch (rd)
		{
		case 13u:
			cpu.COP0_GPR[13] &= 4294966527u;
			cpu.COP0_GPR[13] |= num & 0x300;
			break;
		case 12u:
		{
			cpu.dontIsolateCache = (num & 0x10000) == 0;
			bool num2 = (cpu.COP0_GPR[12] & 1) == 1;
			bool flag = (num & 1) == 1;
			cpu.COP0_GPR[12] = num;
			uint num3 = (num >> 8) & 3;
			uint num4 = (cpu.COP0_GPR[13] >> 8) & 3;
			if (!num2 && flag && (num3 & num4) != 0)
			{
				cpu.PC = cpu.PC_Predictor;
				EXCEPTION(cpu, EX.INTERRUPT, cpu.instr.id);
			}
			break;
		}
		default:
			cpu.COP0_GPR[rd] = num;
			break;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void RFE(CPU cpu)
	{
		uint num = cpu.COP0_GPR[12] & 0x3F;
		cpu.COP0_GPR[12] &= 4294967280u;
		cpu.COP0_GPR[12] |= num >> 2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void EXCEPTION(CPU cpu, EX cause, uint coprocessor = 0u)
	{
		uint num = cpu.COP0_GPR[12] & 0x3F;
		cpu.COP0_GPR[12] &= 4294967232u;
		cpu.COP0_GPR[12] |= (num << 2) & 0x3F;
		uint num2 = cpu.COP0_GPR[13] & 0xFF00;
		cpu.COP0_GPR[13] = (uint)((int)cause << 2);
		cpu.COP0_GPR[13] |= num2;
		cpu.COP0_GPR[13] |= coprocessor << 28;
		if (cause == EX.INTERRUPT)
		{
			cpu.COP0_GPR[14] = cpu.PC;
			cpu.opcodeIsDelaySlot = cpu.opcodeIsBranch;
			cpu.opcodeInDelaySlotTookBranch = cpu.opcodeTookBranch;
		}
		else
		{
			cpu.COP0_GPR[14] = cpu.PC_Now;
		}
		if (cpu.opcodeIsDelaySlot)
		{
			cpu.COP0_GPR[14] -= 4u;
			cpu.COP0_GPR[13] |= 2147483648u;
			cpu.COP0_GPR[6] = cpu.PC;
			if (cpu.opcodeInDelaySlotTookBranch)
			{
				cpu.COP0_GPR[13] |= 1073741824u;
			}
		}
		cpu.PC = ExceptionAdress[cpu.COP0_GPR[12] & 1];
		cpu.PC_Predictor = cpu.PC + 4;
	}

	private static void COP2(CPU cpu)
	{
		if ((cpu.instr.rs & 0x10) == 0)
		{
			switch (cpu.instr.rs)
			{
			case 0u:
				MFC2(cpu);
				break;
			case 2u:
				CFC2(cpu);
				break;
			case 4u:
				MTC2(cpu);
				break;
			case 6u:
				CTC2(cpu);
				break;
			default:
				EXCEPTION(cpu, EX.ILLEGAL_INSTR, cpu.instr.id);
				break;
			}
		}
		else
		{
			cpu.gte.execute(cpu.instr.value);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void MFC2(CPU cpu)
	{
		delayedread(cpu, cpu.instr.rt, cpu.gte.readData(cpu.instr.rd));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void CFC2(CPU cpu)
	{
		delayedread(cpu, cpu.instr.rt, cpu.gte.readControl(cpu.instr.rd));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void MTC2(CPU cpu)
	{
		cpu.gte.writeData(cpu.instr.rd, cpu.GPR[cpu.instr.rt]);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void CTC2(CPU cpu)
	{
		cpu.gte.writeControl(cpu.instr.rd, cpu.GPR[cpu.instr.rt]);
	}

	private static void LWC2(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
		handleLWC2Exception(cpu, num);
		uint v = cpu.bus.read32(num);
		cpu.gte.writeData(cpu.instr.rt, v);
	}

	private static void SWC2(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
		handleSWC2Exception(cpu, num);
		cpu.bus.write32(num, cpu.gte.readData(cpu.instr.rt));
	}

	private static void LB(CPU cpu)
	{
		if (cpu.dontIsolateCache)
		{
			uint value = (uint)(sbyte)cpu.bus.read32(cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s);
			delayedread(cpu, cpu.instr.rt, value);
		}
	}

	private static void LBU(CPU cpu)
	{
		if (cpu.dontIsolateCache)
		{
			uint value = (byte)cpu.bus.read32(cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s);
			delayedread(cpu, cpu.instr.rt, value);
		}
	}

	private static void LH(CPU cpu)
	{
		if (cpu.dontIsolateCache)
		{
			uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
			handleLHException(cpu, num);
			uint value = (uint)(short)cpu.bus.read32(num);
			delayedread(cpu, cpu.instr.rt, value);
		}
	}

	private static void LHU(CPU cpu)
	{
		if (cpu.dontIsolateCache)
		{
			uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
			handleLHUException(cpu, num);
			uint value = (ushort)cpu.bus.read32(num);
			delayedread(cpu, cpu.instr.rt, value);
		}
	}

	private static void LW(CPU cpu)
	{
		if (cpu.dontIsolateCache)
		{
			uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
			handleLWException(cpu, num);
			uint value = cpu.bus.read32(num);
			delayedread(cpu, cpu.instr.rt, value);
		}
	}

	private static void LWL(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
		uint address = num & 0xFFFFFFFCu;
		uint num2 = cpu.bus.read32(address);
		uint num3 = cpu.GPR[cpu.instr.rt];
		if (cpu.instr.rt == cpu.memoryread.register)
		{
			num3 = cpu.memoryread.value;
		}
		int num4 = (int)((num & 3) << 3);
		uint num5 = 16777215u >> num4;
		uint value = (num3 & num5) | (num2 << 24 - num4);
		delayedread(cpu, cpu.instr.rt, value);
	}

	private static void LWR(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
		uint address = num & 0xFFFFFFFCu;
		uint num2 = cpu.bus.read32(address);
		uint num3 = cpu.GPR[cpu.instr.rt];
		if (cpu.instr.rt == cpu.memoryread.register)
		{
			num3 = cpu.memoryread.value;
		}
		int num4 = (int)((num & 3) << 3);
		uint num5 = (uint)(-256 << 24 - num4);
		uint value = (num3 & num5) | (num2 >> num4);
		delayedread(cpu, cpu.instr.rt, value);
	}

	private static void SB(CPU cpu)
	{
		if (cpu.dontIsolateCache)
		{
			cpu.bus.write8(cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s, (byte)cpu.GPR[cpu.instr.rt]);
		}
	}

	private static void SH(CPU cpu)
	{
		if (cpu.dontIsolateCache)
		{
			uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
			handleSHException(cpu, num);
			cpu.bus.write16(num, (ushort)cpu.GPR[cpu.instr.rt]);
		}
	}

	private static void SW(CPU cpu)
	{
		if (cpu.dontIsolateCache)
		{
			uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
			handleSWException(cpu, num);
			cpu.bus.write32(num, cpu.GPR[cpu.instr.rt]);
		}
	}

	private static void SWR(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
		uint address = num & 0xFFFFFFFCu;
		uint num2 = cpu.bus.read32(address);
		int num3 = (int)((num & 3) << 3);
		uint num4 = 16777215u >> 24 - num3;
		uint value = (num2 & num4) | (cpu.GPR[cpu.instr.rt] << num3);
		cpu.bus.write32(address, value);
	}

	private static void SWL(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs] + cpu.instr.imm_s;
		uint address = num & 0xFFFFFFFCu;
		uint num2 = cpu.bus.read32(address);
		int num3 = (int)((num & 3) << 3);
		uint num4 = (uint)(-256 << num3);
		uint value = (num2 & num4) | (cpu.GPR[cpu.instr.rt] >> 24 - num3);
		cpu.bus.write32(address, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void BRANCH(CPU cpu)
	{
		cpu.opcodeTookBranch = true;
		cpu.PC_Predictor = cpu.PC + (cpu.instr.imm_s << 2);
	}

	private static void SLL(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.GPR[cpu.instr.rt] << (int)cpu.instr.sa);
	}

	private static void SRL(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.GPR[cpu.instr.rt] >> (int)cpu.instr.sa);
	}

	private static void SRA(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, (uint)((int)cpu.GPR[cpu.instr.rt] >> (int)cpu.instr.sa));
	}

	private static void SLLV(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.GPR[cpu.instr.rt] << (int)(cpu.GPR[cpu.instr.rs] & 0x1F));
	}

	private static void SRLV(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.GPR[cpu.instr.rt] >> (int)(cpu.GPR[cpu.instr.rs] & 0x1F));
	}

	private static void SRAV(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, (uint)((int)cpu.GPR[cpu.instr.rt] >> (int)(cpu.GPR[cpu.instr.rs] & 0x1F)));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void JR(CPU cpu)
	{
		cpu.opcodeIsBranch = true;
		cpu.opcodeTookBranch = true;
		cpu.PC_Predictor = cpu.GPR[cpu.instr.rs];
	}

	private static void SYSCALL(CPU cpu)
	{
		EXCEPTION(cpu, EX.SYSCALL, cpu.instr.id);
	}

	private static void BREAK(CPU cpu)
	{
		EXCEPTION(cpu, EX.BREAK);
	}

	private static void JALR(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.PC_Predictor);
		JR(cpu);
	}

	private static void MFHI(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.HI);
	}

	private static void MTHI(CPU cpu)
	{
		cpu.HI = cpu.GPR[cpu.instr.rs];
	}

	private static void MFLO(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.LO);
	}

	private static void MTLO(CPU cpu)
	{
		cpu.LO = cpu.GPR[cpu.instr.rs];
	}

	private static void MULT(CPU cpu)
	{
		long num = (long)(int)cpu.GPR[cpu.instr.rs] * (long)(int)cpu.GPR[cpu.instr.rt];
		cpu.HI = (uint)(num >> 32);
		cpu.LO = (uint)num;
	}

	private static void MULTU(CPU cpu)
	{
		ulong num = (ulong)cpu.GPR[cpu.instr.rs] * (ulong)cpu.GPR[cpu.instr.rt];
		cpu.HI = (uint)(num >> 32);
		cpu.LO = (uint)num;
	}

	private static void DIV(CPU cpu)
	{
		int num = (int)cpu.GPR[cpu.instr.rs];
		int num2 = (int)cpu.GPR[cpu.instr.rt];
		if (num2 == 0)
		{
			cpu.HI = (uint)num;
			if (num >= 0)
			{
				cpu.LO = uint.MaxValue;
			}
			else
			{
				cpu.LO = 1u;
			}
		}
		else if (num == int.MinValue && num2 == -1)
		{
			cpu.HI = 0u;
			cpu.LO = 2147483648u;
		}
		else
		{
			cpu.HI = (uint)(num % num2);
			cpu.LO = (uint)(num / num2);
		}
	}

	private static void DIVU(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs];
		uint num2 = cpu.GPR[cpu.instr.rt];
		if (num2 == 0)
		{
			cpu.HI = num;
			cpu.LO = uint.MaxValue;
		}
		else
		{
			cpu.HI = num % num2;
			cpu.LO = num / num2;
		}
	}

	private static void ADD(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs];
		uint num2 = cpu.GPR[cpu.instr.rt];
		uint arg = num + num2;
		handleAddException(cpu, num, num2, arg);
	}

	private static void ADDU(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.GPR[cpu.instr.rs] + cpu.GPR[cpu.instr.rt]);
	}

	private static void SUB(CPU cpu)
	{
		uint num = cpu.GPR[cpu.instr.rs];
		uint num2 = cpu.GPR[cpu.instr.rt];
		uint arg = num - num2;
		handleSubException(cpu, num, num2, arg);
	}

	private static void SUBU(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.GPR[cpu.instr.rs] - cpu.GPR[cpu.instr.rt]);
	}

	private static void AND(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.GPR[cpu.instr.rs] & cpu.GPR[cpu.instr.rt]);
	}

	private static void OR(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.GPR[cpu.instr.rs] | cpu.GPR[cpu.instr.rt]);
	}

	private static void XOR(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, cpu.GPR[cpu.instr.rs] ^ cpu.GPR[cpu.instr.rt]);
	}

	private static void NOR(CPU cpu)
	{
		cpu.setGPR(cpu.instr.rd, ~(cpu.GPR[cpu.instr.rs] | cpu.GPR[cpu.instr.rt]));
	}

	private static void SLT(CPU cpu)
	{
		bool source = (int)cpu.GPR[cpu.instr.rs] < (int)cpu.GPR[cpu.instr.rt];
		cpu.setGPR(cpu.instr.rd, Unsafe.As<bool, uint>(ref source));
	}

	private static void SLTU(CPU cpu)
	{
		bool source = cpu.GPR[cpu.instr.rs] < cpu.GPR[cpu.instr.rt];
		cpu.setGPR(cpu.instr.rd, Unsafe.As<bool, uint>(ref source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool checkOverflow(uint a, uint b, uint r)
	{
		return ((r ^ a) & (r ^ b) & 0x80000000u) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool checkUnderflow(uint a, uint b, uint r)
	{
		return ((r ^ a) & (a ^ b) & 0x80000000u) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void setGPR(uint regN, uint value)
	{
		writeBack.register = regN;
		writeBack.value = value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void delayedread(CPU cpu, uint regN, uint value)
	{
		cpu.delayedMemoryread.register = regN;
		cpu.delayedMemoryread.value = value;
	}
}
