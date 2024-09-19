using AutoMapper;
using InfoPortal.Api.Models.Request;
using InfoPortal.Api.Models.Response;
using InfoPortal.Application.Contracts.Logic.Services.News;
using InfoPortal.Application.Contracts.Logic.Services.News.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.Host.Controllers.v1
{
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;

        public NewsController(
            INewsService newsService,
            IMapper mapper) : base(mapper)
        {
            _newsService = newsService;
        }

        [HttpGet("get-all")]
        public async Task<List<NewsModel>> GetAllAsync()
        {
            var newsDto = await _newsService.GetAllAsync();
            return _mapper.Map<List<NewsModel>>(newsDto);
        }

        [HttpGet("get-all-sorted")]
        public async Task<List<NewsModel>> GetAllSortedAsync()
        {
            var newsDto = await _newsService.GetAllSortedAsync();
            return _mapper.Map<List<NewsModel>>(newsDto);
        }

        [HttpGet("get/{id}")]
        public async Task<NewsModel> GetAsync(Guid id)
        {
            var newsDto = await _newsService.GetAsync(id);
            return _mapper.Map<NewsModel>(newsDto);
        }

        [HttpPost("create")]
        public async Task CreateAsync([FromBody] CreateNewsModel newsApi)
        {
            await _newsService.CreateAsync(_mapper.Map<CreateNewsDto>(newsApi));
        }


        [HttpPost("update")]
        public async Task Update([FromBody] UpdateNewsModel newsApi)
        {
            var newsUpdate = _mapper.Map<UpdateNewsDto>(newsApi);
            await _newsService.UpdateAsync(newsUpdate);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _newsService.DeleteAsync(id);
        }
    }
}

