using HackerNews.Application.Interfaces;
using HackerNews.Application.Services;
using HackerNews.Domain.Interfaces.Providers;
using HackerNews.Domain.Interfaces.Services;
using HackerNews.Domain.Services;
using HackerNews.Infrastructure.API.Providers.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace HackerNews.Application.DI
{
    public static class HackerNewsDIConfiguration
    {
        public static void AddHackerNews(this IServiceCollection services)
        {
            services.AddScoped<IDataProvider, HackerNewsProvider>();
            services.AddScoped<IHackerNewsService, HackerNewsService>();
            services.AddScoped<IStoryService, StoryService>();
        }
    }
}
