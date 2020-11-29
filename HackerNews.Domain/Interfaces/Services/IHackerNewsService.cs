using HackerNews.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Domain.Interfaces.Services
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<BestStory>> GetBestStoriesAsync();
    }
}
