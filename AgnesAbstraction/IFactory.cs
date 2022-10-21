public interface IFactory
{
    IServer CreateServer();
    IClient CreateClient();
}