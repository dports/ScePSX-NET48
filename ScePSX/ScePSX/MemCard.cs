using System;
using System.IO;

namespace ScePSX;

[Serializable]
public class MemCard
{
	[Serializable]
	private enum Mode
	{
		Idle,
		Transfer
	}

	[Serializable]
	private enum TransferMode
	{
		Read,
		Write,
		Id,
		Undefined
	}

	private const byte MEMORY_CARD_ID_1 = 90;

	private const byte MEMORY_CARD_ID_2 = 93;

	private const byte MEMORY_CARD_COMMAND_ACK_1 = 92;

	private const byte MEMORY_CARD_COMMAND_ACK_2 = 93;

	private byte[] memory = new byte[131072];

	public bool ack;

	private const byte FLAG_ERROR = 4;

	private const byte FLAG_NOT_READED = 8;

	private byte flag = 8;

	private byte addressMSB;

	private byte addressLSB;

	private ushort address;

	private byte checksum;

	private int readPointer;

	private byte endTransfer;

	private string memCardFilePath;

	private Mode mode;

	private TransferMode transferMode = TransferMode.Undefined;

	public MemCard(string memCardFile)
	{
		memCardFilePath = memCardFile;
		try
		{
			memory = File.ReadAllBytes(memCardFilePath);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[MEMCARD] " + Path.GetFileName(memCardFilePath) + " Loaded.");
			Console.ResetColor();
		}
		catch
		{
			Console.WriteLine("[MEMCARD] generate " + Path.GetFileName(memCardFilePath));
		}
	}

	public byte process(byte value)
	{
		switch (transferMode)
		{
		case TransferMode.Read:
			return readMemory(value);
		case TransferMode.Write:
			return writeMemory(value);
		case TransferMode.Id:
			return byte.MaxValue;
		default:
			switch (mode)
			{
			case Mode.Idle:
				if (value == 129)
				{
					mode = Mode.Transfer;
					ack = true;
					return byte.MaxValue;
				}
				ack = false;
				return byte.MaxValue;
			case Mode.Transfer:
			{
				switch (value)
				{
				case 82:
					transferMode = TransferMode.Read;
					break;
				case 87:
					transferMode = TransferMode.Write;
					break;
				case 83:
					transferMode = TransferMode.Undefined;
					break;
				default:
					transferMode = TransferMode.Undefined;
					ack = false;
					return byte.MaxValue;
				}
				byte result = flag;
				ack = true;
				flag &= 251;
				return result;
			}
			default:
				ack = false;
				return byte.MaxValue;
			}
		}
	}

	public void resetToIdle()
	{
		readPointer = 0;
		transferMode = TransferMode.Undefined;
		mode = Mode.Idle;
	}

	private byte readMemory(byte value)
	{
		ack = true;
		int num = readPointer++;
		switch (num)
		{
		case 0:
			return 90;
		case 1:
			return 93;
		case 2:
			addressMSB = (byte)(value & 3);
			return 0;
		case 3:
			addressLSB = value;
			address = (ushort)((addressMSB << 8) | addressLSB);
			checksum = (byte)(addressMSB ^ addressLSB);
			return 0;
		case 4:
			return 92;
		case 5:
			return 93;
		case 6:
			return addressMSB;
		case 7:
			return addressLSB;
		default:
		{
			if (readPointer - 1 < 8 || readPointer - 1 >= 136)
			{
				switch (num)
				{
				case 136:
					return checksum;
				case 137:
					transferMode = TransferMode.Undefined;
					mode = Mode.Idle;
					readPointer = 0;
					ack = false;
					return 71;
				default:
					Console.WriteLine($"[MEMCARD] Unreachable! {readPointer}");
					transferMode = TransferMode.Undefined;
					mode = Mode.Idle;
					readPointer = 0;
					ack = false;
					return byte.MaxValue;
				}
			}
			byte b = memory[address * 128 + (num - 8)];
			checksum ^= b;
			return b;
		}
		}
	}

	private byte writeMemory(byte value)
	{
		int num = readPointer++;
		switch (num)
		{
		case 0:
			return 90;
		case 1:
			return 93;
		case 2:
			addressMSB = value;
			return 0;
		case 3:
			addressLSB = value;
			address = (ushort)((addressMSB << 8) | addressLSB);
			endTransfer = 71;
			if (address > 1023)
			{
				flag |= 4;
				endTransfer = byte.MaxValue;
				address &= 1023;
				addressMSB &= 3;
			}
			checksum = (byte)(addressMSB ^ addressLSB);
			return 0;
		default:
			if (readPointer - 1 < 4 || readPointer - 1 >= 132)
			{
				switch (num)
				{
				case 132:
					if (checksum != value)
					{
						flag |= 4;
					}
					return 0;
				case 133:
					return 92;
				case 134:
					return 93;
				case 135:
					transferMode = TransferMode.Undefined;
					mode = Mode.Idle;
					readPointer = 0;
					ack = false;
					flag &= 247;
					handleSave();
					return endTransfer;
				default:
					transferMode = TransferMode.Undefined;
					mode = Mode.Idle;
					readPointer = 0;
					ack = false;
					return byte.MaxValue;
				}
			}
			memory[address * 128 + (num - 4)] = value;
			checksum ^= value;
			return 0;
		}
	}

	private void handleSave()
	{
		try
		{
			File.WriteAllBytes(memCardFilePath, memory);
			Console.WriteLine("[MEMCARD] Saved");
		}
		catch (Exception ex)
		{
			Console.WriteLine("[MEMCARD] Error trying to save memCard file\n" + ex);
		}
	}

	private byte idMemory(byte value)
	{
		Console.WriteLine($"[MEMORY CARD] WARNING Id UNHANDLED COMMAND {value:1x}");
		transferMode = TransferMode.Undefined;
		mode = Mode.Idle;
		return byte.MaxValue;
	}
}
