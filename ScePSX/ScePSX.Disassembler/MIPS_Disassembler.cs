using System;
using System.IO;
using System.Text;

namespace ScePSX.Disassembler;

[Serializable]
internal class MIPS_Disassembler
{
	private int dev;

	private StringBuilder str = new StringBuilder();

	private uint HI;

	private uint LO;

	private uint[] GPR;

	private uint[] COP0_GPR;

	private const int SR = 12;

	private const int CAUSE = 13;

	private const int EPC = 14;

	private const int BADA = 8;

	private const int JUMPDEST = 6;

	public MIPS_Disassembler(ref uint HI, ref uint LO, uint[] GPR, uint[] COP0_GPR)
	{
		this.HI = HI;
		this.LO = LO;
		this.GPR = GPR;
		this.COP0_GPR = COP0_GPR;
	}

	public void output(CPU.Instr instr, uint PC_Now)
	{
		dev++;
		string value = PC_Now.ToString("x8") + " " + instr.value.ToString("x8");
		string text = "";
		for (int i = 0; i < 32; i++)
		{
			string text2 = ((i < 10) ? "0" : "");
			text = text + "R" + text2 + i + ":" + GPR[i].ToString("x8") + "  ";
			if ((i + 1) % 6 == 0)
			{
				text += "\n";
			}
		}
		text = text + " HI:" + HI.ToString("x8") + "  ";
		text = text + " LO:" + LO.ToString("x8") + "  ";
		text = text + " SR:" + COP0_GPR[12].ToString("x8") + "  ";
		text = text + "EPC:" + COP0_GPR[14].ToString("x8") + "\n";
		if (dev == 1)
		{
			using (StreamWriter streamWriter = new StreamWriter("log.txt", append: true))
			{
				streamWriter.WriteLine(value);
				streamWriter.WriteLine(text);
			}
			str.Clear();
			dev = 0;
		}
	}

	public void disassemble(CPU.Instr instr, uint PC_Now, uint PC_Predictor)
	{
		string text = PC_Now.ToString("x8");
		string text2 = instr.value.ToString("x8");
		string text3 = "";
		string text4 = "";
		switch (instr.opcode)
		{
		case 0u:
			switch (instr.function)
			{
			case 0u:
				text3 = ((instr.value != 0) ? ("SLL " + instr.rd) : "NOP");
				break;
			case 2u:
				text3 = "SRL R" + instr.rs + " " + (GPR[instr.rt] >> (int)instr.sa);
				break;
			case 3u:
				text3 = "SRA";
				break;
			case 4u:
				text3 = "SLLV";
				break;
			case 6u:
				text3 = "SRLV";
				break;
			case 7u:
				text3 = "SRAV";
				break;
			case 8u:
				text3 = "JR R" + instr.rs + " " + GPR[instr.rs].ToString("x8");
				break;
			case 9u:
				text3 = "JALR";
				break;
			case 12u:
				text3 = "SYSCALL";
				break;
			case 13u:
				text3 = "BREAK";
				break;
			case 16u:
				text3 = "MFHI";
				break;
			case 18u:
				text3 = "MFLO";
				break;
			case 19u:
				text3 = "MTLO";
				break;
			case 24u:
				text3 = "MULT";
				break;
			case 25u:
				text3 = "MULTU";
				break;
			case 26u:
				text3 = "DIV";
				break;
			case 27u:
				text3 = "DIVU";
				break;
			case 32u:
				text3 = "ADD";
				break;
			case 33u:
				text3 = "ADDU";
				break;
			case 34u:
				text3 = "SUB";
				break;
			case 35u:
				text3 = "SUBU";
				break;
			case 36u:
				text3 = "AND R" + instr.rd + " R" + instr.rs + " & R" + instr.rt + " " + GPR[instr.rs].ToString("x8") + " & " + GPR[instr.rt].ToString("x8");
				break;
			case 37u:
				text3 = "OR";
				text4 = "R" + instr.rd + "," + (GPR[instr.rs] | GPR[instr.rt]).ToString("x8");
				break;
			case 38u:
				text3 = "XOR R" + instr.rd + " R" + instr.rs + " ^ R" + instr.rt + " " + GPR[instr.rs].ToString("x8") + " ^ " + GPR[instr.rt].ToString("x8");
				break;
			case 39u:
				text3 = "NOR";
				break;
			case 42u:
				text3 = "SLT";
				break;
			case 43u:
				text3 = "SLTU";
				break;
			}
			break;
		case 1u:
			switch (instr.rt)
			{
			case 0u:
				text3 = "BLTZ";
				break;
			case 1u:
				text3 = "BGEZ";
				break;
			}
			break;
		case 2u:
			text3 = "J";
			text4 = ((PC_Predictor & 0xF0000000u) | (instr.addr << 2)).ToString("x8");
			break;
		case 3u:
			text3 = "JAL";
			break;
		case 4u:
			text3 = "BEQ";
			text4 = "R" + instr.rs + ": " + GPR[instr.rs] + " R" + instr.rt + ": " + GPR[instr.rt] + " " + (GPR[instr.rs] == GPR[instr.rt]);
			break;
		case 5u:
			text3 = "BNE";
			text4 = "R" + instr.rs + "[" + GPR[instr.rs].ToString("x8") + "],R" + instr.rt + "[" + GPR[instr.rt].ToString("x8") + "], (" + (PC_Now + (instr.imm_s << 2)).ToString("x8") + ")";
			break;
		case 6u:
			text3 = "BLEZ";
			break;
		case 7u:
			text3 = "BGTZ";
			break;
		case 8u:
		{
			text3 = "ADDI";
			int num = (int)GPR[instr.rs];
			int imm_s = (int)instr.imm_s;
			try
			{
				uint num2 = (uint)checked(num + imm_s);
				text4 = "R" + instr.rs + "," + num2.ToString("x8") + " R" + instr.rs + "=" + GPR[instr.rs].ToString("x8");
			}
			catch (OverflowException)
			{
				text4 = "R" + instr.rt + "," + GPR[instr.rs].ToString("x8") + " + " + instr.imm_s.ToString("x8") + " UNHANDLED OVERFLOW";
			}
			break;
		}
		case 9u:
			text3 = "ADDIU";
			text4 = "R" + instr.rt + "," + (GPR[instr.rs] + instr.imm_s).ToString("x8");
			break;
		case 10u:
			text3 = "SLTI";
			break;
		case 11u:
			text3 = "SLTIU";
			break;
		case 12u:
			text3 = "ANDI";
			text4 = "R" + instr.rt + ", R " + GPR[instr.rs] + "AND " + instr.imm + "=" + (GPR[instr.rs] & instr.imm).ToString("x8");
			break;
		case 13u:
			text3 = "ORI";
			text4 = "R" + instr.rt + "," + (GPR[instr.rs] | instr.imm).ToString("x8");
			break;
		case 15u:
			text3 = "LUI";
			text4 = "R" + instr.rt + "," + (instr.imm << 16).ToString("x8");
			break;
		case 16u:
			switch (instr.rs)
			{
			case 0u:
				text3 = "MFC0";
				break;
			case 4u:
				text3 = "MTC0";
				text4 = "R" + instr.rd + ",R" + instr.rt + "[" + GPR[instr.rt].ToString("x8") + "]";
				break;
			case 16u:
				text3 = "RFE";
				break;
			}
			break;
		case 32u:
			text3 = "LB";
			break;
		case 33u:
			text3 = "LH";
			break;
		case 34u:
			text3 = "LWL";
			break;
		case 36u:
			text3 = "LBU";
			break;
		case 37u:
			text3 = "LHU";
			text4 = "cached " + ((COP0_GPR[12] & 0x10000) == 0) + "addr:" + (GPR[instr.rs] + instr.imm_s).ToString("x8") + "on R" + instr.rt;
			break;
		case 35u:
			text4 = (((COP0_GPR[12] & 0x10000) != 0) ? ("R" + instr.rt + "[" + GPR[instr.rt].ToString("x8") + "], " + instr.imm_s.ToString("x8") + "(" + GPR[instr.rs].ToString("x8") + ")[" + (instr.imm_s + GPR[instr.rs]).ToString("x8") + "] WARNING IGNORED LOAD") : ("R" + instr.rt + "[" + GPR[instr.rt].ToString("x8") + "], " + instr.imm_s.ToString("x8") + "(" + GPR[instr.rs].ToString("x8") + ")[" + (instr.imm_s + GPR[instr.rs]).ToString("x8") + "]"));
			text3 = "LW";
			break;
		case 41u:
			text3 = "SH";
			break;
		case 42u:
			text3 = "SWL";
			break;
		case 38u:
			text3 = "LWR";
			break;
		case 40u:
			text3 = "SB";
			break;
		case 43u:
			text3 = "SW";
			text4 = (((COP0_GPR[12] & 0x10000) != 0) ? ("R" + instr.rt + "[" + GPR[instr.rt].ToString("x8") + "], " + instr.imm_s.ToString("x8") + "(" + GPR[instr.rs].ToString("x8") + ")[" + (instr.imm_s + GPR[instr.rs]).ToString("x8") + "] WARNING IGNORED WRITE") : ("R" + instr.rt + "[" + GPR[instr.rt].ToString("x8") + "], " + instr.imm_s.ToString("x8") + "(" + GPR[instr.rs].ToString("x8") + ")[" + (instr.imm_s + GPR[instr.rs]).ToString("x8") + "]"));
			break;
		case 46u:
			text3 = "SWR";
			break;
		case 50u:
			text3 = "LWC2";
			break;
		case 58u:
			text3 = "SWC2";
			text4 = "GTE R" + instr.rt + " -> R" + instr.rs + "= " + GPR[instr.rs].ToString("x8") + " + imm: " + instr.imm.ToString("x8") + " = " + (GPR[instr.rs] + instr.imm).ToString("x8");
			break;
		}
		Console.WriteLine("{0,-8} {1,-8} {2,-8} {3,-20}", text, text2, text3, text4);
	}

	public void PrintRegs()
	{
		string text = "";
		for (int i = 0; i < 32; i++)
		{
			string text2 = ((i < 10) ? "0" : "");
			text = text + "R" + text2 + i + ":" + GPR[i].ToString("x8") + "  ";
			if ((i + 1) % 6 == 0)
			{
				text += "\n";
			}
		}
		Console.Write(text);
		Console.Write(" HI:" + HI.ToString("x8") + "  ");
		Console.Write(" LO:" + LO.ToString("x8") + "  ");
		Console.Write(" SR:" + COP0_GPR[12].ToString("x8") + "  ");
		Console.Write("EPC:" + COP0_GPR[14].ToString("x8") + "\n");
	}
}
