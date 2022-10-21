using System;

public class LNLFactory : IFactory
{
    public IServer CreateServer()
    {
        return new LNLServer();
    }

    public IClient CreateClient()
    {
        return new LNLClient();
    }
};