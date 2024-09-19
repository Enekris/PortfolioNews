using AutoMapper;
using InfoPortal.Api.Models.Request;
using InfoPortal.Api.Models.Response;
using InfoPortal.Application.Contracts.Logic.Services.Tags;
using InfoPortal.Application.Contracts.Logic.Services.Tags.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.Host.Controllers.v1
{
    public class TagController : BaseController
    {
        private readonly ITagsService _tagsService;
        
        public TagController(
            ITagsService tagsService,
            IMapper mapper) : base(mapper)
        {
            _tagsService = tagsService;
        }

        [HttpGet("get-all")]
        public async Task<List<TagModel>> GetAllAsync()
        {
            var tagDto = await _tagsService.GetAllAsync();
            return _mapper.Map<List<TagModel>>(tagDto);
        }

        [HttpGet("get/{id}")]
        public async Task<TagModel> GetAsync(Guid id)
        {
            var tagDto = await _tagsService.GetAsync(id);
            return _mapper.Map<TagModel>(tagDto);
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateAsync([FromBody] CreateTagModel tagApi)
        {
            await _tagsService.CreateAsync(_mapper.Map<CreateTagDto>(tagApi));
        }

        [HttpPost("update")]
        public async Task Update([FromBody] UpdateTagModel tagApi)
        {
            var tagUpdate = _mapper.Map<UpdateTagDto>(tagApi);
            await _tagsService.UpdateAsync(tagUpdate);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _tagsService.DeleteAsync(id);
        }
    }
}
