using HackerNews.Application.Interfaces;
using HackerNews.Domain.Entities;
using HackerNews.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Application.Services
{
    public class StoryService: IStoryService
    {
        private readonly IHackerNewsService hackerNewsService;
        private readonly IMemoryCache cache;
        private readonly int storiesToRetrieve;
        private readonly int cacheLimit;
        private const string CACHE_KEY = "BEST_STORIES_CACHE";

        public StoryService(IHackerNewsService hackerNewsService, IConfiguration configuration, IMemoryCache cache)
        {
            this.hackerNewsService = hackerNewsService;
            this.cache = cache;
            int.TryParse(configuration["StoriesToRetrieve"], out storiesToRetrieve);
            int.TryParse(configuration["CacheLimit"], out cacheLimit);
        }

        public async Task<IEnumerable<BestStory>> GetBestStoriesAsync()
        {
            IEnumerable<BestStory> result = null;
            if (!cache.TryGetValue(CACHE_KEY, out result))
            {
                result = await hackerNewsService.GetBestStoriesAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(cacheLimit));
                cache.Set(CACHE_KEY, result, cacheEntryOptions);
            }
            return result.OrderByDescending(story => story.Score).Take(storiesToRetrieve);
        }
    }
}
