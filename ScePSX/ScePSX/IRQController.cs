using System;

namespace ScePSX;

[Serializable]
public class IRQController
{
	private uint ISTAT;

	private uint IMASK;

	internal void set(Interrupt interrupt)
	{
		ISTAT |= (uint)interrupt;
	}

	internal void writeISTAT(uint value)
	{
		ISTAT &= value & 0x7FF;
	}

	internal void writeIMASK(uint value)
	{
		IMASK = value & 0x7FF;
	}

	internal uint readSTAT()
	{
		return ISTAT;
	}

	internal uint readIMASK()
	{
		return IMASK;
	}

	internal bool interruptPending()
	{
		return (ISTAT & IMASK) != 0;
	}

	internal void write(uint addr, uint value)
	{
		switch (addr & 0xF)
		{
		case 0u:
			ISTAT &= value & 0x7FF;
			break;
		case 4u:
			IMASK = value & 0x7FF;
			break;
		}
	}

	internal uint read(uint addr)
	{
		return (addr & 0xF) switch
		{
			0u => ISTAT, 
			4u => IMASK, 
			_ => uint.MaxValue, 
		};
	}
}
