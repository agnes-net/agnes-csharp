using System;

public class LNLFactory : IFactory
{
    public IServer CreateServer()
    {
        return new LNLServer(9050);
    }

    public IClient CreateClient()
    {
        return new LNLClient();
    }
};