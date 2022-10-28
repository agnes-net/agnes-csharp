using System;
using System.IO;
using System.Text;
using LiteNetLib;

public static class LNLMessageSerializer
{
    public static ChanneledNetMessage ReadChanneledMessage(NetPacketReader reader)
    {
        string guidString = reader.GetString();
        Guid guid = Guid.Parse(guidString);

        ChannelID channelId = new ChannelID(guid);

        int byteArrayLength = reader.GetInt();
    }

    INetMessage GetMessageContents(int byteArrayLength, NetPacketReader netPacketReader)
    {
        using (var stream = new MemoryStream())
        {
            using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
            {
                var bytes = new byte[byteArrayLength];
                netPacketReader.GetBytes(bytes, byteArrayLength);
                INetMessage contents = (INetMessage)reader.ReadBytes(bytes);
            }
        }
    }
    
    public static ChanneledNetMessage WriteChanneledMessage(NetPacketReader reader)
    {
        
    }
}