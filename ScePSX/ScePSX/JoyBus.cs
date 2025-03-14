using System;

namespace ScePSX;

[Serializable]
public class JoyBus
{
	[Serializable]
	private enum ControllerDevice
	{
		None,
		Controller,
		MemoryCard
	}

	private byte TX_DATA;

	private byte RX_DATA;

	private bool fifoFull;

	private bool TXreadyFlag1 = true;

	private bool TXreadyFlag2 = true;

	private bool RXparityError;

	private bool ackInputLevel;

	private bool interruptRequest;

	private int baudrateTimer;

	private uint baudrateReloadFactor;

	private uint characterLength;

	private bool parityEnable;

	private bool parityTypeOdd;

	private bool clkOutputPolarity;

	private bool TXenable;

	private bool Output;

	private bool RXenable;

	private bool Control_unknow_bit3;

	private bool controlAck;

	private bool Control_unknow_bit5;

	private bool controlReset;

	private uint RXinterruptMode;

	private bool TXinterruptEnable;

	private bool RXinterruptEnable;

	private bool ACKinterruptEnable;

	private uint desiredSlotNumber;

	private ushort BUS_BAUD;

	private ControllerDevice Device;

	private Controller controller1;

	private Controller controller2;

	private MemCard memoryCard1;

	private MemCard memoryCard2;

	private int counter;

	public JoyBus(Controller controller1, Controller controller2, MemCard memoryCard1, MemCard memoryCard2)
	{
		this.controller1 = controller1;
		this.controller2 = controller2;
		this.memoryCard1 = memoryCard1;
		this.memoryCard2 = memoryCard2;
	}

	public bool tick()
	{
		if (counter > 0)
		{
			counter -= 100;
			if (counter == 0)
			{
				ackInputLevel = false;
				interruptRequest = true;
			}
		}
		if (interruptRequest)
		{
			return true;
		}
		return false;
	}

	private void reloadTimer()
	{
		baudrateTimer = (int)(BUS_BAUD * baudrateReloadFactor) & -2;
	}

	public void write(uint addr, uint value)
	{
		switch (addr & 0xFF)
		{
		case 64u:
			TX_DATA = (byte)value;
			RX_DATA = byte.MaxValue;
			fifoFull = true;
			TXreadyFlag1 = true;
			TXreadyFlag2 = false;
			if (Output)
			{
				TXreadyFlag2 = true;
				if (Device == ControllerDevice.None)
				{
					switch (value)
					{
					case 1u:
						Device = ControllerDevice.Controller;
						break;
					case 129u:
						Device = ControllerDevice.MemoryCard;
						break;
					}
				}
				if (Device == ControllerDevice.Controller)
				{
					if (desiredSlotNumber == 0)
					{
						RX_DATA = controller1.process(TX_DATA);
						ackInputLevel = controller1.ack;
					}
					else
					{
						RX_DATA = controller2.process(TX_DATA);
						ackInputLevel = controller2.ack;
					}
					if (ackInputLevel)
					{
						counter = 500;
					}
				}
				else if (Device == ControllerDevice.MemoryCard)
				{
					if (desiredSlotNumber == 0)
					{
						RX_DATA = memoryCard1.process(TX_DATA);
						ackInputLevel = memoryCard1.ack;
					}
					else
					{
						RX_DATA = memoryCard2.process(TX_DATA);
						ackInputLevel = memoryCard2.ack;
					}
					if (ackInputLevel)
					{
						counter = 500;
					}
				}
				else
				{
					ackInputLevel = false;
				}
				if (!ackInputLevel)
				{
					Device = ControllerDevice.None;
				}
			}
			else
			{
				Device = ControllerDevice.None;
				memoryCard1.resetToIdle();
				memoryCard2.resetToIdle();
				controller1.resetToIdle();
				controller2.resetToIdle();
				ackInputLevel = false;
			}
			break;
		case 72u:
			set_MODE(value);
			break;
		case 74u:
			set_CTRL(value);
			break;
		case 78u:
			BUS_BAUD = (ushort)value;
			reloadTimer();
			break;
		default:
			Console.WriteLine($"Unhandled JOYPAD Write {addr:x8} {value:x8}");
			break;
		}
	}

	private void set_CTRL(uint value)
	{
		TXenable = (value & 1) != 0;
		Output = ((value >> 1) & 1) != 0;
		RXenable = ((value >> 2) & 1) != 0;
		Control_unknow_bit3 = ((value >> 3) & 1) != 0;
		controlAck = ((value >> 4) & 1) != 0;
		Control_unknow_bit5 = ((value >> 5) & 1) != 0;
		controlReset = ((value >> 6) & 1) != 0;
		RXinterruptMode = (value >> 8) & 3;
		TXinterruptEnable = ((value >> 10) & 1) != 0;
		RXinterruptEnable = ((value >> 11) & 1) != 0;
		ACKinterruptEnable = ((value >> 12) & 1) != 0;
		desiredSlotNumber = (value >> 13) & 1;
		if (controlAck)
		{
			RXparityError = false;
			interruptRequest = false;
			controlAck = false;
		}
		if (controlReset)
		{
			Device = ControllerDevice.None;
			memoryCard1.resetToIdle();
			memoryCard2.resetToIdle();
			controller1.resetToIdle();
			controller2.resetToIdle();
			fifoFull = false;
			set_MODE(0u);
			set_CTRL(0u);
			BUS_BAUD = 0;
			RX_DATA = byte.MaxValue;
			TX_DATA = byte.MaxValue;
			TXreadyFlag1 = true;
			TXreadyFlag2 = true;
			controlReset = false;
		}
		if (!Output)
		{
			Device = ControllerDevice.None;
			memoryCard1.resetToIdle();
			memoryCard2.resetToIdle();
			controller1.resetToIdle();
			controller2.resetToIdle();
		}
	}

	private void set_MODE(uint value)
	{
		baudrateReloadFactor = value & 3;
		characterLength = (value >> 2) & 3;
		parityEnable = ((value >> 4) & 1) != 0;
		parityTypeOdd = ((value >> 5) & 1) != 0;
		clkOutputPolarity = ((value >> 8) & 1) != 0;
	}

	public uint read(uint addr)
	{
		switch (addr & 0xFF)
		{
		case 64u:
			fifoFull = false;
			return RX_DATA;
		case 68u:
			return get_STAT();
		case 72u:
			return get_MODE();
		case 74u:
			return get_CTRL();
		case 78u:
			return BUS_BAUD;
		default:
			return uint.MaxValue;
		}
	}

	private uint get_CTRL()
	{
		return 0u | (TXenable ? 1u : 0u) | ((Output ? 1u : 0u) << 1) | ((RXenable ? 1u : 0u) << 2) | ((Control_unknow_bit3 ? 1u : 0u) << 3) | ((Control_unknow_bit5 ? 1u : 0u) << 5) | (RXinterruptMode << 8) | ((TXinterruptEnable ? 1u : 0u) << 10) | ((RXinterruptEnable ? 1u : 0u) << 11) | ((ACKinterruptEnable ? 1u : 0u) << 12) | (desiredSlotNumber << 13);
	}

	private uint get_MODE()
	{
		return 0 | baudrateReloadFactor | (characterLength << 2) | ((parityEnable ? 1u : 0u) << 4) | ((parityTypeOdd ? 1u : 0u) << 5) | ((clkOutputPolarity ? 1u : 0u) << 4);
	}

	private uint get_STAT()
	{
		int result = (int)(0u | (TXreadyFlag1 ? 1u : 0u) | ((fifoFull ? 1u : 0u) << 1) | ((TXreadyFlag2 ? 1u : 0u) << 2) | ((RXparityError ? 1u : 0u) << 3) | ((ackInputLevel ? 1u : 0u) << 7) | ((interruptRequest ? 1u : 0u) << 9)) | (baudrateTimer << 11);
		ackInputLevel = false;
		return (uint)result;
	}
}
