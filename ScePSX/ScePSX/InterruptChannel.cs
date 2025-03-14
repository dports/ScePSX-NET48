using System;

namespace ScePSX;

[Serializable]
public sealed class InterruptChannel : Channel
{
	private uint control;

	private bool forceIRQ;

	private uint irqEnable;

	private bool masterEnable;

	private uint irqFlag;

	private bool masterFlag;

	private bool edgeInterruptTrigger;

	public InterruptChannel()
	{
		control = 124076833u;
	}

	public override uint read(uint register)
	{
		switch (register)
		{
		case 0u:
			return control;
		case 4u:
			return readInterrupt();
		case 6u:
			return readInterrupt() >> 16;
		default:
			Console.WriteLine("Unhandled register on interruptChannel DMA load " + register);
			return uint.MaxValue;
		}
	}

	private uint readInterrupt()
	{
		return 0 | ((forceIRQ ? 1u : 0u) << 15) | (irqEnable << 16) | ((masterEnable ? 1u : 0u) << 23) | (irqFlag << 24) | ((masterFlag ? 1u : 0u) << 31);
	}

	public override void write(uint register, uint value)
	{
		switch (register)
		{
		case 0u:
			control = value;
			return;
		case 4u:
			writeInterrupt(value);
			return;
		case 6u:
			writeInterrupt((value << 16) | ((forceIRQ ? 1u : 0u) << 15));
			return;
		}
		Console.WriteLine($"Unhandled write on DMA Interrupt register {register}");
	}

	private void writeInterrupt(uint value)
	{
		forceIRQ = ((value >> 15) & 1) != 0;
		irqEnable = (value >> 16) & 0x7F;
		masterEnable = ((value >> 23) & 1) != 0;
		irqFlag &= ~((value >> 24) & 0x7F);
		masterFlag = updateMasterFlag();
	}

	public void handleInterrupt(int channel)
	{
		if ((irqEnable & (1 << channel)) != 0L)
		{
			irqFlag |= (uint)(1 << channel);
		}
		masterFlag = updateMasterFlag();
		edgeInterruptTrigger |= masterFlag;
	}

	public bool isDMAControlMasterEnabled(int channelNumber)
	{
		return ((control >> 3 >> 4 * channelNumber) & 1) != 0;
	}

	private bool updateMasterFlag()
	{
		if (!forceIRQ)
		{
			if (masterEnable)
			{
				return (irqEnable & irqFlag) != 0;
			}
			return false;
		}
		return true;
	}

	public bool tick()
	{
		if (edgeInterruptTrigger)
		{
			edgeInterruptTrigger = false;
			return true;
		}
		return false;
	}
}
