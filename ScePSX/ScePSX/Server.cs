using System;
using System.Net;
using System.Net.Sockets;

namespace ScePSX;

public class Server : Socket
{
	public IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

	public int port = 1234;

	private TcpClient client;

	private NetworkStream Stream;

	private TcpListener listener;

	private AsyncCallback DataReceivedHandler;

	public byte[] buffer = new byte[2];

	public Server(AsyncCallback handler)
	{
		DataReceivedHandler = handler;
	}

	public void SetIP(string ip)
	{
		ipAddress = IPAddress.Parse(ip);
	}

	public void AcceptClientConnection()
	{
		listener = new TcpListener(ipAddress, port);
		Console.WriteLine("[SIO1] Server started, waiting for a connection...");
		listener.Start();
		listener.BeginAcceptTcpClient(ClientConnected, null);
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

	public void BeginReceiving()
	{
		if (DataReceivedHandler == null)
		{
			Console.WriteLine("[SIO1] DataReceivedHandler == null");
		}
		Stream.BeginRead(buffer, 0, 2, DataReceivedHandler, null);
	}

	public void Stop(IAsyncResult result)
	{
		Stream.EndRead(result);
	}

	public void ClientConnected(IAsyncResult result)
	{
		if (!listener.Server.IsBound)
		{
			return;
		}
		try
		{
			client = listener.EndAcceptTcpClient(result);
			Stream = client.GetStream();
			IPEndPoint iPEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
			Console.WriteLine("[SIO1] Client Connected: " + (iPEndPoint?.Address)?.ToString() + ":" + iPEndPoint?.Port);
			BeginReceiving();
		}
		catch (Exception ex)
		{
			Console.WriteLine("[SIO1] Error: " + ex.Message);
		}
	}

	public void ConnectToServer()
	{
		throw new NotSupportedException();
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
		if (client != null)
		{
			client.Close();
		}
		if (listener != null)
		{
			listener.Stop();
		}
	}
}
