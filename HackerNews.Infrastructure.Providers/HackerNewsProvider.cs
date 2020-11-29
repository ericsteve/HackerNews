using HackerNews.Domain.Entities;
using HackerNews.Domain.Interfaces.Providers;
using HackerNews.Infrastructure.CrossCutting.Communication;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Infrastructure.API.Providers.Implementation
{
    public class HackerNewsProvider: IDataProvider
    {
        private readonly string apiVersion;
        public HackerNewsProvider(IConfiguration configuration)
        {
            apiVersion = configuration["ApiVersion"];
        }

        public async Task<Story> GetStoryDetailAsync(int id)
        {
            var url = $"https://hacker-news.firebaseio.com/{apiVersion}/item/{id}.json";
            return await HttpCommunication.GetAsync<Story>(url);
        }

        public async Task<IEnumerable<int>> GetBestStoriesIdsAsync()
        {
            var url = $"https://hacker-news.firebaseio.com/{apiVersion}/beststories.json";
            return await HttpCommunication.GetAsync<IEnumerable<int>>(url);
        }
    }
}
