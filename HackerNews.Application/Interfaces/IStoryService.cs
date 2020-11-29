using HackerNews.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Application.Interfaces
{
    public interface IStoryService
    {
        Task<IEnumerable<BestStory>> GetBestStoriesAsync();
    }
}
