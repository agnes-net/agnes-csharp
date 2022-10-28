using System;

public class LNLClientConnectionResult : IDelayedResult<bool>
{
	public bool IsCompleted => peer.ConnectionState != LiteNetLib.ConnectionState.Outgoing;

	public bool Result => peer.ConnectionState == LiteNetLib.ConnectionState.Connected;

	LiteNetLib.NetPeer peer;

	public LiteNetLib.ConnectionState CurrentConnectionState => peer.ConnectionState;

	public LNLClientConnectionResult(LiteNetLib.NetPeer peer)
	{
		this.peer = peer;
	}
}