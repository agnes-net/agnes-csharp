using System;

public class LNLServer : IServer
{
    public event Action OnServerStarted = delegate {  };
    public event Action OnServerStopped = delegate {  };
    public bool IsServerRunning { get; private set; }
    public bool TryInitServer()
    {
        IsServerRunning = true;
        OnServerStarted.Invoke();
        return true;
    }

    public bool TryStopServer()
    {
        IsServerRunning = false;
        OnServerStopped.Invoke();
        return true;    
    }
    
    public void Poll()
    {
        throw new NotImplementedException();
    }
}