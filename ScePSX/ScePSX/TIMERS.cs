using System;

namespace ScePSX;

[Serializable]
public class TIMERS
{
	[Serializable]
	public class TIMER
	{
		private int timerNumber;

		private uint counterValue;

		private uint counterTargetValue;

		private byte syncEnable;

		private byte syncMode;

		private byte resetCounterOnTarget;

		private byte irqWhenCounterTarget;

		private byte irqWhenCounterFFFF;

		private byte irqRepeat;

		private byte irqPulse;

		private byte clockSource;

		private byte interruptRequest;

		private byte reachedTarget;

		private byte reachedFFFF;

		private bool vblank;

		private bool hblank;

		private int dotDiv = 1;

		private bool prevHblank;

		private bool prevVblank;

		private bool irq;

		private bool alreadFiredIrq;

		private int cycles;

		public TIMER(int timerNumber)
		{
			this.timerNumber = timerNumber;
		}

		public void write(uint addr, uint value)
		{
			switch (addr & 0xF)
			{
			case 0u:
				counterValue = (ushort)value;
				break;
			case 4u:
				setCounterMode(value);
				break;
			case 8u:
				counterTargetValue = value;
				break;
			default:
				Console.WriteLine("[TIMER] " + timerNumber + "Unhandled Write" + addr);
				Console.ReadLine();
				break;
			}
		}

		public uint read(uint addr)
		{
			switch (addr & 0xF)
			{
			case 0u:
				return counterValue;
			case 4u:
				return getCounterMode();
			case 8u:
				return counterTargetValue;
			default:
				Console.WriteLine("[TIMER] " + timerNumber + "Unhandled load" + addr);
				Console.ReadLine();
				return 0u;
			}
		}

		public void syncGPU((int dotDiv, bool hblank, bool vblank) sync)
		{
			prevHblank = hblank;
			prevVblank = vblank;
			(dotDiv, hblank, vblank) = sync;
		}

		public bool tick(int cyclesTicked)
		{
			cycles += cyclesTicked;
			switch (timerNumber)
			{
			case 0:
				if (syncEnable == 1)
				{
					switch (syncMode)
					{
					case 0:
						if (hblank)
						{
							return false;
						}
						break;
					case 1:
						if (hblank)
						{
							counterValue = 0u;
						}
						break;
					case 2:
						if (hblank)
						{
							counterValue = 0u;
						}
						if (!hblank)
						{
							return false;
						}
						break;
					case 3:
						if (!prevHblank && hblank)
						{
							syncEnable = 0;
							break;
						}
						return false;
					}
				}
				if (clockSource == 0 || clockSource == 2)
				{
					counterValue += (ushort)cycles;
					cycles = 0;
				}
				else
				{
					ushort num = (ushort)(cycles * 11 / 7 / dotDiv);
					counterValue += num;
					cycles = 0;
				}
				return handleIrq();
			case 1:
				if (syncEnable == 1)
				{
					switch (syncMode)
					{
					case 0:
						if (vblank)
						{
							return false;
						}
						break;
					case 1:
						if (vblank)
						{
							counterValue = 0u;
						}
						break;
					case 2:
						if (vblank)
						{
							counterValue = 0u;
						}
						if (!vblank)
						{
							return false;
						}
						break;
					case 3:
						if (!prevVblank && vblank)
						{
							syncEnable = 0;
							break;
						}
						return false;
					}
				}
				if (clockSource == 0 || clockSource == 2)
				{
					counterValue += (ushort)cycles;
					cycles = 0;
				}
				else if (!prevHblank && hblank)
				{
					counterValue++;
				}
				return handleIrq();
			case 2:
				if ((syncEnable == 1 && syncMode == 0) || syncMode == 3)
				{
					return false;
				}
				if (clockSource == 0 || clockSource == 1)
				{
					counterValue += (ushort)cycles;
					cycles = 0;
				}
				else
				{
					counterValue += (ushort)(cycles / 8);
					cycles %= 8;
				}
				return handleIrq();
			default:
				return false;
			}
		}

		private bool handleIrq()
		{
			irq = false;
			if (counterValue >= counterTargetValue)
			{
				reachedTarget = 1;
				if (resetCounterOnTarget == 1)
				{
					counterValue = 0u;
				}
				if (irqWhenCounterTarget == 1)
				{
					irq = true;
				}
			}
			if (counterValue >= 65535)
			{
				reachedFFFF = 1;
				if (irqWhenCounterFFFF == 1)
				{
					irq = true;
				}
			}
			counterValue &= 65535u;
			if (!irq)
			{
				return false;
			}
			if (irqPulse == 0)
			{
				interruptRequest = 0;
			}
			else
			{
				interruptRequest = (byte)((interruptRequest + 1) & 1);
			}
			bool flag = interruptRequest == 0;
			if (irqRepeat == 0)
			{
				if (!(!alreadFiredIrq && flag))
				{
					return false;
				}
				alreadFiredIrq = true;
			}
			interruptRequest = 1;
			return flag;
		}

		private void setCounterMode(uint value)
		{
			syncEnable = (byte)(value & 1);
			syncMode = (byte)((value >> 1) & 3);
			resetCounterOnTarget = (byte)((value >> 3) & 1);
			irqWhenCounterTarget = (byte)((value >> 4) & 1);
			irqWhenCounterFFFF = (byte)((value >> 5) & 1);
			irqRepeat = (byte)((value >> 6) & 1);
			irqPulse = (byte)((value >> 7) & 1);
			clockSource = (byte)((value >> 8) & 3);
			interruptRequest = 1;
			alreadFiredIrq = false;
			counterValue = 0u;
		}

		private uint getCounterMode()
		{
			int result = 0 | syncEnable | (syncMode << 1) | (resetCounterOnTarget << 3) | (irqWhenCounterTarget << 4) | (irqWhenCounterFFFF << 5) | (irqRepeat << 6) | (irqPulse << 7) | (clockSource << 8) | (interruptRequest << 10) | (reachedTarget << 11) | (reachedFFFF << 12);
			reachedTarget = 0;
			reachedFFFF = 0;
			return (uint)result;
		}
	}

	private TIMER[] timer = new TIMER[3];

	public TIMERS()
	{
		timer[0] = new TIMER(0);
		timer[1] = new TIMER(1);
		timer[2] = new TIMER(2);
	}

	public void write(uint addr, uint value)
	{
		int num = (int)(addr & 0xF0) >> 4;
		if (num > 2)
		{
			Console.WriteLine($"[TIMER] WRITE WARNING: Access to unavailable hardware timer {num}");
		}
		else
		{
			timer[num].write(addr, value);
		}
	}

	public uint read(uint addr)
	{
		int num = (int)(addr & 0xF0) >> 4;
		if (num > 2)
		{
			Console.WriteLine($"[TIMER] LOAD WARNING: Access to unavailable hardware timer {num}");
			return uint.MaxValue;
		}
		return timer[num].read(addr);
	}

	public bool tick(int timerNumber, int cycles)
	{
		return timer[timerNumber].tick(cycles);
	}

	public void syncGPU((int, bool, bool) sync)
	{
		timer[0].syncGPU(sync);
		timer[1].syncGPU(sync);
	}
}
