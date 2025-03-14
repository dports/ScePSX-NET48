using System;
using System.Collections.Generic;

namespace ScePSX;

public class SerialIO : IDisposable
{
	private struct StatusRegister
	{
		public byte TX_FIFO_Not_Full;

		public byte RX_FIFO_Not_Empty;

		public byte TX_Idle;

		public byte RX_Parity_Error;

		public byte RX_FIFO_Overrun;

		public byte RX_BadStopBit;

		public byte RX_InputLevel;

		public byte DSR_InputLevel;

		public byte CTS_InputLevel;

		public byte InterruptRequest;

		public int Baud;
	}

	private struct ModeRegister
	{
		public byte BaudrateReloadFactor;

		public byte CharacterLength;

		public byte ParityEnable;

		public byte ParityType;

		public byte StopBitLength;

		public byte ClockPolarity;
	}

	private struct CtrlRegister
	{
		public byte TX_Enable;

		public byte DTR_OutputLevel;

		public byte RX_Enable;

		public byte TX_OutputLevel;

		public byte Acknowledge;

		public byte RTS_OutputLevel;

		public byte Reset;

		public byte RX_InterruptMode;

		public byte TX_InterruptEnable;

		public byte RX_InterruptEnable;

		public byte DSR_InterruptEnable;

		public byte PortSelect;
	}

	public struct Command
	{
		public byte address;

		public byte value;
	}

	private const uint CPU_CLOCK = 33868800u;

	public byte TX_Data;

	public ushort BoudReload;

	private StatusRegister Status;

	private ModeRegister Mode;

	private CtrlRegister Ctrl;

	private Socket Socket;

	private bool IsConnected;

	private bool IsServer;

	private int delay = -1;

	private int CyclesPerInterrupt = 500;

	private Queue<int> IRQ = new Queue<int>();

	private Queue<byte> RXBuffer = new Queue<byte>();

	private Queue<Command> Cmdbuffer = new Queue<Command>();

	public SerialIO()
	{
		Status.RX_InputLevel = 0;
	}

	public void Active(bool isSrv, string localip, string srvip)
	{
		IsServer = isSrv;
		AsyncCallback handler = DataReceived;
		if (IsServer)
		{
			Socket = new Server(handler);
			Socket.SetIP(localip);
			Socket.AcceptClientConnection();
		}
		else
		{
			Socket = new Client(handler);
			Socket.SetIP(srvip);
			Socket.ConnectToServer();
		}
		Status.TX_Idle = 1;
		IsConnected = true;
	}

	public void Close()
	{
		IsConnected = false;
		if (Socket != null)
		{
			Socket.Terminate();
		}
	}

	public uint read(uint address)
	{
		switch (address & 0xF)
		{
		case 0u:
			return GetData();
		case 4u:
			return GetStatus();
		case 8u:
			return GetMode();
		case 10u:
			return GetCtrl();
		case 14u:
			return BoudReload;
		default:
			Console.WriteLine("[SIO1] Attempting to read from: " + address.ToString("x"));
			return 0u;
		}
	}

	public void write(uint address, uint data)
	{
		switch (address & 0xF)
		{
		case 0u:
			Transfare((byte)data);
			break;
		case 8u:
			WriteMode((ushort)data);
			break;
		case 10u:
			WriteCtrl((ushort)data);
			break;
		case 14u:
			BoudReload = (ushort)data;
			Reload();
			break;
		case 4u:
			Console.WriteLine("[SIO1] Attempting to write to STAT");
			break;
		default:
			Console.WriteLine("[SIO1] Attempting to write to: " + address.ToString("x"));
			break;
		}
	}

	private void Transfare(byte data)
	{
		if (IsConnected && Socket.IsConnected())
		{
			TX_Data = data;
			if (Status.CTS_InputLevel == 1 && Ctrl.TX_Enable == 1)
			{
				byte b = 0;
				Socket.Send(new byte[2] { b, data });
			}
			if (Ctrl.TX_InterruptEnable == 1 && (Status.TX_FIFO_Not_Full == 1 || Status.TX_Idle == 1))
			{
				Status.InterruptRequest = 1;
				IRQ.Enqueue(CyclesPerInterrupt);
			}
		}
	}

	private uint GetStatus()
	{
		return (uint)(0 | (Status.TX_FIFO_Not_Full & 1) | ((Status.RX_FIFO_Not_Empty & 1) << 1) | ((Status.TX_Idle & 1) << 2) | ((Status.RX_Parity_Error & 1) << 3) | ((Status.RX_FIFO_Overrun & 1) << 4) | ((Status.RX_BadStopBit & 1) << 5) | ((Status.RX_InputLevel & 1) << 6) | ((Status.DSR_InputLevel & 1) << 7) | ((Status.CTS_InputLevel & 1) << 8) | ((Status.InterruptRequest & 1) << 9) | ((Status.Baud & 0xFFFF) << 11));
	}

	private ushort GetMode()
	{
		return (ushort)((ushort)((ushort)((ushort)((ushort)((ushort)(0 | (byte)(Mode.BaudrateReloadFactor & 3)) | (byte)((Mode.CharacterLength & 3) << 2)) | (byte)((Mode.ParityEnable & 1) << 4)) | (byte)((Mode.ParityType & 1) << 5)) | (byte)((Mode.StopBitLength & 3) << 6)) | (byte)((Mode.ClockPolarity & 1) << 8));
	}

	private void WriteMode(ushort value)
	{
		Mode.BaudrateReloadFactor = (byte)(value & 3);
		Mode.CharacterLength = (byte)((value >> 2) & 3);
		Mode.ParityEnable = (byte)((value >> 4) & 1);
		Mode.ParityType = (byte)((value >> 5) & 1);
		Mode.StopBitLength = (byte)((value >> 6) & 3);
		Mode.ClockPolarity = (byte)((value >> 8) & 1);
	}

	private ushort GetCtrl()
	{
		return (ushort)((ushort)((ushort)((ushort)((ushort)((ushort)((ushort)((ushort)((ushort)((ushort)(0 | (byte)(Ctrl.TX_Enable & 1)) | (byte)((Ctrl.DTR_OutputLevel & 1) << 1)) | (byte)((Ctrl.RX_Enable & 1) << 2)) | (byte)((Ctrl.TX_OutputLevel & 1) << 3)) | (byte)((Ctrl.RTS_OutputLevel & 1) << 5)) | (byte)((Ctrl.RX_InterruptMode & 3) << 8)) | (byte)((Ctrl.TX_InterruptEnable & 1) << 10)) | (byte)((Ctrl.RX_InterruptEnable & 1) << 11)) | (byte)((Ctrl.DSR_InterruptEnable & 1) << 12)) | (byte)((Ctrl.PortSelect & 1) << 13));
	}

	private void WriteCtrl(ushort control)
	{
		Ctrl.TX_Enable = (byte)(control & 1);
		Ctrl.DTR_OutputLevel = (byte)((control >> 1) & 1);
		Ctrl.RX_Enable = (byte)((control >> 2) & 1);
		Ctrl.TX_OutputLevel = (byte)((control >> 3) & 1);
		Ctrl.Acknowledge = (byte)((control >> 4) & 1);
		Ctrl.RTS_OutputLevel = (byte)((control >> 5) & 1);
		Ctrl.Reset = (byte)((control >> 6) & 1);
		Ctrl.RX_InterruptMode = (byte)((control >> 8) & 3);
		Ctrl.TX_InterruptEnable = (byte)((control >> 10) & 1);
		Ctrl.RX_InterruptEnable = (byte)((control >> 11) & 1);
		Ctrl.DSR_InterruptEnable = (byte)((control >> 12) & 1);
		Ctrl.PortSelect = (byte)((control >> 13) & 1);
		if (Ctrl.Acknowledge == 1)
		{
			Ctrl.Acknowledge = 0;
			Status.InterruptRequest = 0;
			Status.RX_Parity_Error = 0;
			Status.RX_FIFO_Overrun = 0;
			Status.RX_BadStopBit = 0;
		}
		if (Ctrl.Reset == 1)
		{
			Ctrl.Reset = 0;
			Ctrl.Acknowledge = 0;
			Status.InterruptRequest = 0;
			Status.RX_Parity_Error = 0;
			Status.RX_FIFO_Overrun = 0;
			Status.RX_BadStopBit = 0;
			TX_Data = byte.MaxValue;
			RXBuffer.Clear();
		}
		if (Ctrl.RX_Enable == 0)
		{
			RXBuffer.Clear();
		}
		if (IsConnected && Socket.IsConnected())
		{
			byte b = 10;
			byte b2 = (byte)(GetCtrl() & 0xFF);
			Socket.Send(new byte[2] { b, b2 });
		}
	}

	public bool tick(int cycles)
	{
		bool result = false;
		if (delay > 0)
		{
			delay -= cycles;
			if (delay <= 0)
			{
				result = true;
				if (IRQ.Count > 0)
				{
					delay = IRQ.Dequeue();
				}
			}
		}
		Status.Baud -= cycles;
		if (Status.Baud <= 0)
		{
			Reload();
		}
		return result;
	}

	public void HandleCommand(Command cmd)
	{
		switch (cmd.address)
		{
		case 0:
		{
			RXBuffer.Enqueue(cmd.value);
			Status.RX_FIFO_Not_Empty = Ctrl.RX_Enable;
			int num = 0;
			switch (Ctrl.RX_InterruptMode)
			{
			case 0:
				num = 1;
				break;
			case 1:
				num = 2;
				break;
			case 2:
				num = 4;
				break;
			case 3:
				num = 8;
				break;
			}
			if (RXBuffer.Count >= num && Ctrl.RX_InterruptEnable == 1)
			{
				Status.InterruptRequest = 1;
				IRQ.Enqueue(CyclesPerInterrupt);
			}
			break;
		}
		case 10:
			Status.DSR_InputLevel = (byte)((cmd.value >> 1) & 1);
			Status.CTS_InputLevel = (byte)((cmd.value >> 5) & 1);
			Status.TX_FIFO_Not_Full = Status.CTS_InputLevel;
			Status.TX_Idle = (byte)(Status.CTS_InputLevel & Ctrl.TX_Enable);
			if (Ctrl.DSR_InterruptEnable == 1 && Status.DSR_InputLevel == 1)
			{
				Status.InterruptRequest = 1;
				IRQ.Enqueue(CyclesPerInterrupt);
			}
			break;
		default:
			Console.WriteLine("[SIO1] Unknown addr: " + cmd.address.ToString("x"));
			break;
		}
	}

	public byte GetData()
	{
		if (!IsConnected || !Socket.IsConnected())
		{
			return byte.MaxValue;
		}
		byte result = byte.MaxValue;
		if (RXBuffer.Count > 0)
		{
			result = RXBuffer.Dequeue();
		}
		Status.RX_FIFO_Not_Empty = (byte)((RXBuffer.Count > 0 && Ctrl.RX_Enable == 1) ? 1u : 0u);
		return result;
	}

	public void Reload()
	{
		Status.Baud = BoudReload * Mode.BaudrateReloadFactor / 2;
		if (Status.Baud > 0)
		{
			CyclesPerInterrupt = (int)(33868800L / (long)(Status.Baud * 8));
		}
	}

	public void DataReceived(IAsyncResult result)
	{
		Socket.Stop(result);
		byte[] array = Socket.Receive();
		Command cmd = default(Command);
		cmd.address = array[0];
		cmd.value = array[1];
		HandleCommand(cmd);
		Socket.BeginReceiving();
	}

	public void Dispose()
	{
		if (Socket != null)
		{
			Socket.Terminate();
		}
	}
}
