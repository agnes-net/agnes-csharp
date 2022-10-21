using System;

public class LNLClient : IClient
{
    public event Action OnClientStarted = delegate {  };
    public event Action OnClientStopped = delegate {  };
    
    public bool IsClientRunning { get; private set; }

    public bool TryInitClient()
    {
        IsClientRunning = true;
        OnClientStarted.Invoke();
        return true;
    }

    public bool TryStopClient()
    {
        IsClientRunning = false;
        OnClientStopped.Invoke();
        return true;       
    }
    
    public void Poll()
    {
        throw new NotImplementedException();
    }

}