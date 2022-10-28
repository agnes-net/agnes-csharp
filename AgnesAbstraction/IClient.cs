using System;

public interface IClient : INetNode
{
    event Action OnClientStarted;
    event Action OnClientStopped;
	event Action OnConnectionResponseReceived;
	event Action OnClientConnected;
	
    bool IsClientRunning { get; }

    bool TryInitClient();
    void StopClient();

	IDelayedResult<bool> TryConnect(string ip, int port);
	void ReceiveConnectionResponse();
}
