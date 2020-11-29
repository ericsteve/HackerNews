using Microsoft.Extensions.Configuration;
using Moq;

namespace HackerNews.Tests.Mocks
{
    public static class MocksConfigurator
    {
        public static Mock<IConfiguration> CreateConfigurationMock()
        {
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.SetupGet(cfg => cfg[It.Is<string>(key => key == "ApiVersion")]).Returns("v0");
            configurationMock.SetupGet(cfg => cfg[It.Is<string>(key => key == "StoriesToRetrieve")]).Returns("20");
            configurationMock.SetupGet(cfg => cfg[It.Is<string>(key => key == "CacheLimit")]).Returns("120");
            return configurationMock;
        }
    }
}
