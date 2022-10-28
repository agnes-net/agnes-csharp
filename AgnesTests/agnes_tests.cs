using NUnit.Framework;
using System;


[TestFixture(typeof(LNLFactory))]
public class agnes_tests<T> where T : IFactory, new()
{
    T factory;

    private IServer server;
    private IClient client;

	const string IP = "localhost";
	const int PORT = 9050;
    
    [SetUp]
    public void SetUp()
    {
        factory = new T();
        server = factory.CreateServer();
        client = factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
		client.StopClient();
		server.StopServer();
    }

    [Test]
    public void server_can_start()
    {
        // Arrange
        Assert.False(server.IsServerRunning);

        // Act
        bool hasServerStarted = server.TryInitServer();
        
        // Assert
        Assert.True(hasServerStarted);
        Assert.True(server.IsServerRunning);
    }

    [Test]
    public void server_can_stop()
    {
        // Arrange
        server.TryInitServer();
        Assert.True(server.IsServerRunning);

        // Act
        server.StopServer();
        
        // Assert
        Assert.False(server.IsServerRunning);
    }

    [Test]
    public void client_can_start()
    {
        // Arrange
        Assert.False(client.IsClientRunning);

        // Act
        bool hasClientStarted = client.TryInitClient();
        
        // Assert
        Assert.True(hasClientStarted);
        Assert.True(client.IsClientRunning);
    }

    [Test]
    public void client_can_stop()
    {
        // Arrange
        client.TryInitClient();
        Assert.True(client.IsClientRunning);

        // Act
        client.StopClient();
        
        // Assert
        Assert.False(client.IsClientRunning);
    }

    [Test]
    public void server_can_receive_connection_request()
    {
        // Arrange
		server.TryInitServer();
		client.TryInitClient();

		// Act
		var hasClientConnected = client.TryConnect(IP, PORT);

		bool connRequestReceived = false;
		server.OnConnectionRequestReceived += () => connRequestReceived = true;

		int counter = 0;

		while (connRequestReceived == false)
		{
			server.Poll();
			client.Poll();

			counter++;

			if (counter > 250)
				Assert.Fail("Wait timed out - hit maximum loop count");
		}
        
        // Assert
        Assert.True(connRequestReceived);
    }

    [Test]
    public void client_can_connect_to_server()
    {
        // Arrange
		server.TryInitServer();
		client.TryInitClient();

		// Act
		var hasClientConnected = client.TryConnect(IP, PORT);

		int counter = 0;

		while (hasClientConnected.IsCompleted == false)
		{
			server.Poll();
			client.Poll();

			counter++;

			if (counter > 250)
				Assert.Fail("Wait timed out - hit maximum loop count");
		}
        
        // Assert
        Assert.True(hasClientConnected.Result);
    }

    [Test]
    public void client_connection_callback_fires()
    {
        // Arrange

        // Act
        
        // Assert
        Assert.Ignore();
    }

    [Test]
    public void server_endpoint_has_valid_channel()
    {
        // Arrange

        // Act
        
        // Assert
        Assert.Ignore();
    }

    [Test]
    public void client_receives_correct_channel_id()
    {
        // Arrange

        // Act
        
        // Assert
        Assert.Ignore();
    }

    [Test]
    public void client_receives_server_message()
    {
        // Arrange

        // Act
        
        // Assert
        Assert.Ignore();
    }

    [Test]
    public void server_receives_client_message()
    {
        // Arrange

        // Act
        
        // Assert
        Assert.Ignore();
    }

    [Test]
    public void all_clients_receive_service_tunnel_multicast_message()
    {
        // Arrange

        // Act
        
        // Assert
        Assert.Ignore();
    }

    [Test]
    public void server_receives_service_tunnel_multicast_messages_from_client()
    {
        // Arrange

        // Act
        
        // Assert
        Assert.Ignore();
    }

    [Test]
    public void all_client_receive_custom_preconstructed_multicast_message()
    {
        // Arrange

        // Act
        
        // Assert
        Assert.Ignore();
    }

    [Test]
    public void server_receives_custom_multicast_messages_from_clients()
    {
        // Arrange

        // Act
        
        // Assert
        Assert.Ignore();
    }
}

