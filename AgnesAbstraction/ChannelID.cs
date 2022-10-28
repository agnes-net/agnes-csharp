using System;

[Serializable]
public record ChannelID
{
	public Guid Guid { get; }

	public ChannelID()
	{
		this.Guid = new Guid();
	}
	
	public ChannelID(Guid guid)
	{
		this.Guid = guid;
	}
}