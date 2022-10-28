using System;
using System.Net;

public class LNLServer : IServer
{
	#region LNL TYPES

	internal readonly LiteNetLib.EventBasedNetListener listener;
	private LiteNetLib.NetManager netManager;

	#endregion LNL TYPES

	public event Action OnServerStarted = delegate {  };
    public event Action OnServerStopped = delegate {  };
	public event Action OnConnectionRequestReceived = delegate {  };

	public bool IsServerRunning { get; private set; }

	public string ip { get; }
	public int port { get; }

	public NetChannel ServiceTunnel { get; }

	public LNLServer(int port)
	{
		listener   = new LiteNetLib.EventBasedNetListener();
		netManager = new LiteNetLib.NetManager(listener);
		this.port  = port;

		ServiceTunnel = new NetChannel();

		RegisterSubscriptions();
	}

	void RegisterSubscriptions()
	{
		listener.ConnectionRequestEvent += ReceiveConnectionRequest;

	}

	public bool TryInitServer()
    {
		if (IsServerRunning == true)
			return false;

        IsServerRunning = true;
        OnServerStarted.Invoke();

		bool result = netManager.Start(IPAddress.Any, IPAddress.IPv6Any, port);
		netManager.BroadcastReceiveEnabled = true;
        return result;
    }

    public void StopServer()
    {
		netManager.Stop(true);
		netManager.BroadcastReceiveEnabled = false;

        IsServerRunning = false;
        OnServerStopped.Invoke();
    }
    
    public void Poll()
    {
		netManager.PollEvents();
    }

	void ReceiveConnectionRequest(LiteNetLib.ConnectionRequest connRequest)
	{
		OnConnectionRequestReceived.Invoke();

		connRequest.Accept();
	}
}
