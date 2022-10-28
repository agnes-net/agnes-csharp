using System;

public interface IServer : INetNode
{
	string ip { get; }
	int port { get; }

    event Action OnServerStarted;
    event Action OnServerStopped;
	event Action OnConnectionRequestReceived;

	NetChannel ServiceTunnel { get; }

    bool IsServerRunning { get; }
    
    bool TryInitServer();
    void StopServer();
}
