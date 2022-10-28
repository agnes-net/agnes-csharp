using System;

[Serializable]
public class NetChannel
{
	public Guid Id { get; }

	// Server generates a new guid
	public NetChannel()
	{
		Id = Guid.NewGuid();
	}

	// Client receives guid from server
	public NetChannel(Guid guid)
	{
		Id = guid;
	}
}