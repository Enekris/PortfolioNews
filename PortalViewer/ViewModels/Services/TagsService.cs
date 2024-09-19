using AutoMapper;
using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Services.Interfaces;
using InfoPortal.Api.Client.ApIClient.Interfaces;
using InfoPortal.Api.Models.Request;

namespace InfoPortalWpf.ViewModels.Services
{
    public class TagsService : ITagsService
    {
        internal readonly IApiTagClient _apiClient;
        internal readonly IMapper _mapper;
        public TagsService(IApiTagClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }
        public async Task<List<Tag>> GetAllAsync()
        {
            var tagsModel = await _apiClient.GetAllTagsAsync();
            return _mapper.Map<List<Tag>>(tagsModel);
        }
        public async Task CreateAsync(CreateTag tag)
        {
            var tag1 = _mapper.Map<CreateTagModel>(tag);
            await _apiClient.CreateAsync(_mapper.Map<CreateTagModel>(tag));
        }
        public async Task UpdateAsync(UpdateTag tag)
        {
            await _apiClient.Update(_mapper.Map<UpdateTagModel>(tag));
        }
        public async Task DeleteAsync(Guid id)
        {
            await _apiClient.DeleteTagsAsync(id);
        }

    }
}
