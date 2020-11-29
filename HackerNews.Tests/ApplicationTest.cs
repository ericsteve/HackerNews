using HackerNews.Application.Interfaces;
using HackerNews.Application.Services;
using HackerNews.Domain.Entities;
using HackerNews.Domain.Interfaces.Providers;
using HackerNews.Domain.Interfaces.Services;
using HackerNews.Domain.Services;
using HackerNews.Infrastructure.API.Providers.Implementation;
using HackerNews.Tests.Mocks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Tests
{
    [TestClass]
    public class ApplicationTest
    {
        private Mock<IConfiguration> configurationMock;

        [TestInitialize()]
        public void Initialize()
        {
            configurationMock = MocksConfigurator.CreateConfigurationMock();
        }

        [TestMethod]
        public async Task SortsDataCorrectly()
        {
            var result = await GetStoriesData();
            BestStory previousStory = null;
            foreach (var item in result)
            {
                if (previousStory == null)
                {
                    previousStory = item;
                    continue;
                }

                Assert.IsTrue(previousStory.Score > item.Score);
            }
        }

        [TestMethod]
        public async Task RetrievesTheRightStoriesQty()
        {
            var result = await GetStoriesData();
            Assert.IsTrue(result.Count() == Convert.ToInt32(configurationMock.Object["StoriesToRetrieve"]));
        }

        private async Task<IEnumerable<BestStory>> GetStoriesData()
        {
            MemoryCacheOptions options = new MemoryCacheOptions();
            IMemoryCache memoryCache = new MemoryCache(options);
            IDataProvider dataProvider = new HackerNewsProvider(configurationMock.Object);
            IHackerNewsService hackerNewsService = new HackerNewsService(dataProvider);
            IStoryService storyService = new StoryService(hackerNewsService, configurationMock.Object, memoryCache);
            return await storyService.GetBestStoriesAsync();
        }
    }
}
