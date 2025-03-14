using System;

namespace ScePSX;

[Serializable]
public class DMA
{
	private Channel[] channels = new Channel[8];

	public DMA(BUS bus)
	{
		InterruptChannel interruptChannel = new InterruptChannel();
		channels[0] = new DmaChannel(0, interruptChannel, bus);
		channels[1] = new DmaChannel(1, interruptChannel, bus);
		channels[2] = new DmaChannel(2, interruptChannel, bus);
		channels[3] = new DmaChannel(3, interruptChannel, bus);
		channels[4] = new DmaChannel(4, interruptChannel, bus);
		channels[5] = new DmaChannel(5, interruptChannel, bus);
		channels[6] = new DmaChannel(6, interruptChannel, bus);
		channels[7] = interruptChannel;
	}

	public uint read(uint addr)
	{
		uint num = (addr & 0x70) >> 4;
		uint regiter = addr & 0xF;
		return channels[num].read(regiter);
	}

	public void write(uint addr, uint value)
	{
		uint num = (addr & 0x70) >> 4;
		uint register = addr & 0xF;
		channels[num].write(register, value);
	}

	public bool tick()
	{
		for (int i = 0; i < 7; i++)
		{
			((DmaChannel)channels[i]).transferBlockIfPending();
		}
		return ((InterruptChannel)channels[7]).tick();
	}
}
