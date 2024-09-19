using InfoPortal.Application.Contracts.Logic.Services.News.Models;

namespace InfoPortal.Application.Contracts.Logic.Services.News
{
    public interface INewsService
    {
        Task CreateAsync(CreateNewsDto newsDto);
        Task UpdateAsync(UpdateNewsDto newsDto);
        Task DeleteAsync(Guid Id);
        Task<NewsDto> GetAsync(Guid Id);
        public Task<List<NewsDto>> GetAllAsync();
        public Task<List<NewsDto>> GetAllSortedAsync();
    }
}
