using AutoMapper;
using HackerNews.API.Models;
using HackerNews.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryService service;
        private readonly IMapper mapper;

        public StoriesController(IStoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet("Best")]
        public async Task<ActionResult<IEnumerable<StoriesViewModel>>> GetBestStories()
        {
            var result = await service.GetBestStoriesAsync();
            return Ok(mapper.Map<IEnumerable<StoriesViewModel>>(result));
        }
    }
}
