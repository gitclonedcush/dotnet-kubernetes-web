using System;
using System.Net.Http;
using System.Threading.Tasks;
using KubernetesApp.Config;
using Xunit;

namespace KubernetesApp.Tests
{
    [Collection("TestServer collection")]
    public class ValuesControllerTests
    {
        private readonly HttpClient _client;

        public ValuesControllerTests(TestServerFixture testServerFixture)
        {
            _client = testServerFixture.TestServer.CreateClient();
        }

        [Theory]
        [InlineData("v1.0/values")]
        public async Task GetAllValues(string valuesEndpoint)
        {
            var response = await _client.GetAsync(valuesEndpoint);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("[\"value1\",\"value2\"]", await response.Content.ReadAsStringAsync());
        }
    }
}
