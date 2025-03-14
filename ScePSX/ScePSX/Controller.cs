using System;
using System.Collections.Generic;

namespace ScePSX;

[Serializable]
public class Controller
{
	private enum Mode
	{
		Idle,
		Connected,
		Transfering
	}

	public enum InputAction
	{
		DPadUp,
		DPadDown,
		DPadLeft,
		DPadRight,
		Triangle,
		Circle,
		Cross,
		Square,
		Select,
		Start,
		L1,
		L2,
		L3,
		R1,
		R2,
		R3
	}

	public byte RightJoyX;

	public byte RightJoyY;

	public byte LeftJoyX;

	public byte LeftJoyY;

	public bool IsAnalog;

	protected Queue<byte> DataFifo = new Queue<byte>();

	public bool ack;

	private Mode mode;

	private Dictionary<InputAction, byte> InputActions = new Dictionary<InputAction, byte>
	{
		{
			InputAction.DPadUp,
			1
		},
		{
			InputAction.DPadDown,
			1
		},
		{
			InputAction.DPadLeft,
			1
		},
		{
			InputAction.DPadRight,
			1
		},
		{
			InputAction.Triangle,
			1
		},
		{
			InputAction.Circle,
			1
		},
		{
			InputAction.Cross,
			1
		},
		{
			InputAction.Square,
			1
		},
		{
			InputAction.Select,
			1
		},
		{
			InputAction.Start,
			1
		},
		{
			InputAction.L1,
			1
		},
		{
			InputAction.L2,
			1
		},
		{
			InputAction.L3,
			1
		},
		{
			InputAction.R1,
			1
		},
		{
			InputAction.R2,
			1
		},
		{
			InputAction.R3,
			1
		}
	};

	public byte process(byte b)
	{
		switch (mode)
		{
		case Mode.Idle:
			if (b == 1)
			{
				mode = Mode.Connected;
				ack = true;
				return byte.MaxValue;
			}
			DataFifo.Clear();
			ack = false;
			return byte.MaxValue;
		case Mode.Connected:
			if (b == 66)
			{
				mode = Mode.Transfering;
				GenRepsone();
				ack = true;
				return DataFifo.Dequeue();
			}
			mode = Mode.Idle;
			DataFifo.Clear();
			ack = false;
			return byte.MaxValue;
		case Mode.Transfering:
		{
			byte result = DataFifo.Dequeue();
			ack = DataFifo.Count > 0;
			if (!ack)
			{
				mode = Mode.Idle;
			}
			return result;
		}
		default:
			return byte.MaxValue;
		}
	}

	public void resetToIdle()
	{
		mode = Mode.Idle;
	}

	private void GenRepsone()
	{
		if (IsAnalog)
		{
			DataFifo.Enqueue(115);
		}
		else
		{
			DataFifo.Enqueue(65);
		}
		DataFifo.Enqueue(90);
		byte b = InputActions[InputAction.Select];
		byte b2 = 1;
		byte b3 = 1;
		byte b4 = InputActions[InputAction.Start];
		byte b5 = InputActions[InputAction.DPadUp];
		byte b6 = InputActions[InputAction.DPadRight];
		byte b7 = InputActions[InputAction.DPadDown];
		byte b8 = InputActions[InputAction.DPadLeft];
		byte b9 = InputActions[InputAction.L2];
		byte b10 = InputActions[InputAction.R2];
		byte b11 = InputActions[InputAction.L1];
		byte b12 = InputActions[InputAction.R1];
		byte b13 = InputActions[InputAction.Triangle];
		byte b14 = InputActions[InputAction.Circle];
		byte b15 = InputActions[InputAction.Cross];
		byte b16 = InputActions[InputAction.Square];
		byte b17 = 0;
		b17 |= b8;
		b17 <<= 1;
		b17 |= b7;
		b17 <<= 1;
		b17 |= b6;
		b17 <<= 1;
		b17 |= b5;
		b17 <<= 1;
		b17 |= b4;
		b17 <<= 1;
		b17 |= b3;
		b17 <<= 1;
		b17 |= b2;
		b17 <<= 1;
		b17 |= b;
		byte b18 = 0;
		b18 |= b16;
		b18 <<= 1;
		b18 |= b15;
		b18 <<= 1;
		b18 |= b14;
		b18 <<= 1;
		b18 |= b13;
		b18 <<= 1;
		b18 |= b12;
		b18 <<= 1;
		b18 |= b11;
		b18 <<= 1;
		b18 |= b10;
		b18 <<= 1;
		b18 |= b9;
		DataFifo.Enqueue(b17);
		DataFifo.Enqueue(b18);
		if (IsAnalog)
		{
			DataFifo.Enqueue(RightJoyX);
			DataFifo.Enqueue(RightJoyY);
			DataFifo.Enqueue(LeftJoyX);
			DataFifo.Enqueue(LeftJoyY);
		}
	}

	public void Button(InputAction inputCode, bool Down = false)
	{
		InputActions[inputCode] = ((!Down) ? ((byte)1) : ((byte)0));
	}

	public void AnalogAxis(float lx, float ly, float rx, float ry)
	{
		RightJoyX = (byte)((rx + 1f) / 2f * 255f);
		LeftJoyX = (byte)((lx + 1f) / 2f * 255f);
		RightJoyY = (byte)((ry + 1f) / 2f * 255f);
		LeftJoyY = (byte)((ly + 1f) / 2f * 255f);
	}
}
