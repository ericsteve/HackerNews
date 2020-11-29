using HackerNews.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Domain.Interfaces.Providers
{
    public interface IDataProvider
    {
        Task<Story> GetStoryDetailAsync(int id);
        Task<IEnumerable<int>> GetBestStoriesIdsAsync();
    }
}
