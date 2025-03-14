using System;
using System.Net;
using System.Net.Sockets;

namespace ScePSX;

public class Client : Socket
{
	public IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

	public int port = 1234;

	private TcpClient TCP_Client;

	private NetworkStream Stream;

	public byte[] buffer = new byte[2];

	private AsyncCallback DataReceivedHandler;

	public Client(AsyncCallback handler)
	{
		DataReceivedHandler = handler;
	}

	public void SetIP(string ip)
	{
		ipAddress = IPAddress.Parse(ip);
	}

	public void ConnectToServer()
	{
		TCP_Client = new TcpClient();
		try
		{
			TCP_Client.Connect(ipAddress, port);
			Stream = TCP_Client.GetStream();
			BeginReceiving();
			Console.WriteLine("[SIO1] Connected to " + ipAddress?.ToString() + ":" + port);
		}
		catch
		{
			Console.WriteLine("[SIO1] Could not connect to server");
			TCP_Client = null;
			Stream = null;
		}
	}

	public byte[] Receive()
	{
		return buffer;
	}

	public void Send(byte[] buffer)
	{
		if (buffer.Length > 2 || Stream == null)
		{
			throw new Exception();
		}
		Stream.Write(buffer, 0, buffer.Length);
	}

	public void AcceptClientConnection()
	{
		throw new NotSupportedException();
	}

	public void BeginReceiving()
	{
		if (DataReceivedHandler == null)
		{
			throw new NullReferenceException();
		}
		Stream.BeginRead(buffer, 0, 2, DataReceivedHandler, null);
	}

	public void Stop(IAsyncResult result)
	{
		Stream.EndRead(result);
	}

	public bool IsConnected()
	{
		return Stream != null;
	}

	public void Terminate()
	{
		if (Stream != null)
		{
			Stream.Close();
		}
		if (TCP_Client != null)
		{
			TCP_Client.Close();
		}
	}
}
