using System;

namespace ScePSX;

public interface Socket
{
	void Send(byte[] buffer);

	byte[] Receive();

	void ConnectToServer();

	void AcceptClientConnection();

	void BeginReceiving();

	void Stop(IAsyncResult result);

	bool IsConnected();

	void Terminate();

	void SetIP(string ip);
}
