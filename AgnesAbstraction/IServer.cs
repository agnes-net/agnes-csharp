using System;

public interface IServer : INetNode
{
    event Action OnServerStarted;
    event Action OnServerStopped;

    bool IsServerRunning { get; }
    
    bool TryInitServer();
    bool TryStopServer();
}