using HackerNews.Domain.Entities;
using HackerNews.Domain.Interfaces.Providers;
using HackerNews.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Domain.Services
{
    public class HackerNewsService: IHackerNewsService
    {
        private readonly IDataProvider dataProvider;

        public HackerNewsService(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public async Task<IEnumerable<BestStory>> GetBestStoriesAsync()
        {
            var storiesIds = await dataProvider.GetBestStoriesIdsAsync();
            IList<BestStory> result = new List<BestStory>();
            await Task.Run(() =>
            {
                Parallel.ForEach(storiesIds, (id) =>
                {
                    var story = GetStoryDetailAsync(id).Result;
                    result.Add(story);
                });
            });

            return result;
        }

        private async Task<BestStory> GetStoryDetailAsync(int id)
        {
            var detailedStory = await dataProvider.GetStoryDetailAsync(id);
            return detailedStory.ToBestStory();
        }
    }
}
