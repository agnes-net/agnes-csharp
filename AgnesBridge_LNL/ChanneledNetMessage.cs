public struct ChanneledNetMessage : INetMessage
{
    public readonly ChannelID channelId;
    public readonly INetMessage msg;

    public ChanneledNetMessage(ChannelID channelId, INetMessage msg)
    {
        this.channelId	= channelId;
        this.msg		= msg;
    }
}