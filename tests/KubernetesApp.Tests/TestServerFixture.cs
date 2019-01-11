using KubernetesApp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace KubernetesApp.Tests
{
    public class TestServerFixture : System.IDisposable
    {
        public TestServer TestServer { get; protected set; }

        public TestServerFixture()
        {
            var builder = new ConfigurationBuilder();
            var config = builder.Build();
            TestServer = new TestServer(Program.CreateWebHostBuilder(null).UseConfiguration(config));
        }

        public void Dispose()
        {
            TestServer?.Dispose();
            TestServer = null;
        }
    }

    [CollectionDefinition("TestServer collection")]
    public class TestServerCollection : ICollectionFixture<TestServerFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}