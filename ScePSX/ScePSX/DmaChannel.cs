using System;

namespace ScePSX;

[Serializable]
public sealed class DmaChannel : Channel
{
	private uint baseAddress;

	private uint blockSize;

	private uint blockCount;

	private uint transferDirection;

	private uint memoryStep;

	private uint choppingEnable;

	private uint syncMode;

	private uint choppingDMAWindowSize;

	private uint choppingCPUWindowSize;

	private bool enable;

	private bool trigger;

	private uint unknownBit29;

	private uint unknownBit30;

	private BUS bus;

	private InterruptChannel interrupt;

	private int channelNumber;

	private uint pendingBlocks;

	public DmaChannel(int channelNumber, InterruptChannel interrupt, BUS bus)
	{
		this.channelNumber = channelNumber;
		this.interrupt = interrupt;
		this.bus = bus;
	}

	public override uint read(uint register)
	{
		return register switch
		{
			0u => baseAddress, 
			4u => (blockCount << 16) | blockSize, 
			8u => readChannelControl(), 
			_ => 0u, 
		};
	}

	private uint readChannelControl()
	{
		uint num = 0u;
		num |= transferDirection;
		num |= ((memoryStep != 4) ? 1u : 0u) << 1;
		num |= choppingEnable << 8;
		num |= syncMode << 9;
		num |= choppingDMAWindowSize << 16;
		num |= choppingCPUWindowSize << 20;
		num |= (enable ? 1u : 0u) << 24;
		num |= (trigger ? 1u : 0u) << 28;
		num |= unknownBit29 << 29;
		num |= unknownBit30 << 30;
		if (channelNumber == 6)
		{
			return (num & 0x50000002) | 2;
		}
		return num;
	}

	public override void write(uint register, uint value)
	{
		switch (register)
		{
		case 0u:
			baseAddress = value & 0xFFFFFF;
			return;
		case 4u:
			blockCount = value >> 16;
			blockSize = value & 0xFFFF;
			return;
		case 8u:
			writeChannelControl(value);
			return;
		}
		Console.WriteLine($"Unhandled Write on DMA Channel: {channelNumber} register: {register} value: {value}");
	}

	private void writeChannelControl(uint value)
	{
		transferDirection = value & 1;
		memoryStep = ((((value >> 1) & 1) == 0) ? 4u : 4294967292u);
		choppingEnable = (value >> 8) & 1;
		syncMode = (value >> 9) & 3;
		choppingDMAWindowSize = (value >> 16) & 7;
		choppingCPUWindowSize = (value >> 20) & 7;
		enable = ((value >> 24) & 1) != 0;
		trigger = ((value >> 28) & 1) != 0;
		unknownBit29 = (value >> 29) & 1;
		unknownBit30 = (value >> 30) & 1;
		if (!enable)
		{
			pendingBlocks = 0u;
		}
		handleDMA();
	}

	private void handleDMA()
	{
		if (!isActive() || !interrupt.isDMAControlMasterEnabled(channelNumber))
		{
			return;
		}
		if (syncMode == 0)
		{
			blockCopy((blockSize == 0) ? 65536u : blockSize);
			finishDMA();
		}
		else if (syncMode == 1)
		{
			if ((channelNumber == 2 && transferDirection == 1) || channelNumber == 0)
			{
				blockCopy(blockSize * blockCount);
				finishDMA();
			}
			else
			{
				trigger = false;
				pendingBlocks = blockCount;
				transferBlockIfPending();
			}
		}
		else if (syncMode == 2)
		{
			linkedList();
			finishDMA();
		}
	}

	private void finishDMA()
	{
		enable = false;
		trigger = false;
		interrupt.handleInterrupt(channelNumber);
	}

	private void blockCopy(uint size)
	{
		if (transferDirection == 0)
		{
			switch (channelNumber)
			{
			case 1:
				bus.DmaFromMdecOut(baseAddress, (int)size);
				break;
			case 2:
				bus.DmaFromGpu(baseAddress, (int)size);
				break;
			case 3:
				bus.DmaFromCD(baseAddress, (int)size);
				break;
			case 4:
				bus.DmaFromSpu(baseAddress, (int)size);
				break;
			case 6:
				bus.DmaOTC(baseAddress, (int)size);
				break;
			default:
				Console.WriteLine($"[DMA] [BLOCK COPY] Unsupported Channel (to Ram) {channelNumber}");
				break;
			}
			baseAddress += memoryStep * size;
		}
		else
		{
			Span<uint> span = bus.DmaFromRam(baseAddress & 0x1FFFFC, size);
			switch (channelNumber)
			{
			case 0:
				bus.DmaToMdecIn(span);
				break;
			case 2:
				bus.DmaToGpu(span);
				break;
			case 4:
				bus.DmaToSpu(span);
				break;
			default:
				Console.WriteLine($"[DMA] [BLOCK COPY] Unsupported Channel (from Ram) {channelNumber}");
				break;
			}
			baseAddress += memoryStep * size;
		}
	}

	private void linkedList()
	{
		uint num = 0u;
		uint num2 = 65535u;
		while ((num & 0x800000) == 0 && num2-- != 0)
		{
			num = bus.ReadRam(baseAddress);
			uint num3 = num >> 24;
			if (num3 != 0)
			{
				baseAddress = (baseAddress + 4) & 0x1FFFFC;
				Span<uint> buffer = bus.DmaFromRam(baseAddress, num3);
				bus.DmaToGpu(buffer);
			}
			if (baseAddress != (num & 0x1FFFFC))
			{
				baseAddress = num & 0x1FFFFC;
				continue;
			}
			break;
		}
	}

	private bool isActive()
	{
		if (syncMode != 0)
		{
			return enable;
		}
		if (enable)
		{
			return trigger;
		}
		return false;
	}

	public void transferBlockIfPending()
	{
		if (pendingBlocks != 0)
		{
			pendingBlocks--;
			blockCopy(blockSize);
			if (pendingBlocks == 0)
			{
				finishDMA();
			}
		}
	}
}
