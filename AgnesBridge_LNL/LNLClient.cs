using System;

public class LNLClient : IClient
{
	#region LNL TYPES

	internal readonly LiteNetLib.EventBasedNetListener listener;
	private LiteNetLib.NetManager netManager;

	#endregion LNL TYPES

    public event Action OnClientStarted = delegate {  };
    public event Action OnClientStopped = delegate {  };
	public event Action OnConnectionResponseReceived = delegate {  };
	public event Action OnClientConnected = delegate {  };

	public bool IsClientRunning { get; private set; }

	public LNLClient()
	{
		listener   = new LiteNetLib.EventBasedNetListener();
		netManager = new LiteNetLib.NetManager(listener);
	}

    public bool TryInitClient()
    {
        IsClientRunning = true;
        OnClientStarted.Invoke();
        return netManager.Start();
    }

    public void StopClient()
    {
		netManager.Stop(true);

        IsClientRunning = false;
        OnClientStopped.Invoke();
    }
    
    public void Poll()
    {
        netManager.PollEvents();
    }

	public IDelayedResult<bool> TryConnect(string ip, int port)
	{
		var netPeer = netManager.Connect(ip, port, "agnes");
		return new LNLClientConnectionResult(netPeer);
	}

	public void ReceiveConnectionResponse()
	{
		throw new NotImplementedException();
	}
}
