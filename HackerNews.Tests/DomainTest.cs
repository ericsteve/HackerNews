using HackerNews.Domain.Interfaces.Providers;
using HackerNews.Domain.Interfaces.Services;
using HackerNews.Domain.Services;
using HackerNews.Infrastructure.API.Providers.Implementation;
using HackerNews.Tests.Mocks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Tests
{
    [TestClass]
    public class DomainTest
    {
        private Mock<IConfiguration> configurationMock;
        [TestInitialize()]
        public void Initialize() 
        {
            configurationMock = MocksConfigurator.CreateConfigurationMock();
        }

        [TestMethod]
        public async Task RetrievesData()
        {
            IDataProvider dataProvider = new HackerNewsProvider(configurationMock.Object);
            IHackerNewsService hackerNewsService = new HackerNewsService(dataProvider);
            var result = await hackerNewsService.GetBestStoriesAsync();
            Assert.IsTrue(result.Any());
        }
    }
}
