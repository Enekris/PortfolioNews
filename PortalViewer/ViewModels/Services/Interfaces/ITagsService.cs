using InfoPortalWpf.Models;

namespace InfoPortalWpf.ViewModels.Services.Interfaces
{
    public interface ITagsService
    {
        public Task<List<Tag>> GetAllAsync();
        public Task CreateAsync(CreateTag tag);
        public Task UpdateAsync(UpdateTag tag);
        public Task DeleteAsync(Guid id);

    }
}
