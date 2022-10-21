using System;

public interface IClient : INetNode
{
    event Action OnClientStarted;
    event Action OnClientStopped;
   
    bool IsClientRunning { get; }

    bool TryInitClient();
    bool TryStopClient();
}