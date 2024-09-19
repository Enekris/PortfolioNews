using InfoPortalWpf.Models;

namespace InfoPortalWpf.ViewModels.Services.Interfaces
{
    public interface INewsService
    {
        public Task<List<News>> GetAllAsync();

        public Task<List<News>> GetAllSortedAsync();

        public Task CreateAsync(CreateNews newNews);

        public Task UpdateAsync(UpdateNews newNews);

        public Task DeleteAsync(Guid id);

    }
}
