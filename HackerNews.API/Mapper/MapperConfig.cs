using AutoMapper;
using HackerNews.API.Models;
using HackerNews.Domain.Entities;

namespace HackerNews.API.Mapper
{
    public class MapperConfig
    {
        public static IMapper Create()
        {
            var mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BestStory, StoriesViewModel>();
            });

            return mapperCfg.CreateMapper();
        }
    }
}
