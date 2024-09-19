using AutoMapper;
using InfoPortalWpf.Models;
using InfoPortalWpf.ViewModels.Services.Interfaces;
using InfoPortal.Api.Client.ApIClient.Interfaces;
using InfoPortal.Api.Models.Request;

namespace InfoPortalWpf.ViewModels.Services
{
    public class NewsService : INewsService
    {
        internal readonly IApiNewsClient _apiClient;
        internal readonly IMapper _mapper;
        public NewsService(IApiNewsClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public async Task<List<News>> GetAllAsync()
        {
            var newsmodel = await _apiClient.GetAllNewsAsync();
            return _mapper.Map<List<News>>(newsmodel);
        }
        public async Task<List<News>> GetAllSortedAsync()
        {
            var newsmodel = await _apiClient.GetAllSortedAsync();
            return _mapper.Map<List<News>>(newsmodel);
        }
        public async Task CreateAsync(CreateNews newNews)
        {
            await _apiClient.CreateAsync(_mapper.Map<CreateNewsModel>(newNews));
        }
        public async Task UpdateAsync(UpdateNews newNews)
        {
            await _apiClient.Update(_mapper.Map<UpdateNewsModel>(newNews));
        }
        public async Task DeleteAsync(Guid id)
        {
            await _apiClient.DeleteNewsAsync(id);
        }
    }
}
