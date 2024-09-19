using InfoPortal.Application.Contracts.Logic.Services.Tags.Models;

namespace InfoPortal.Application.Contracts.Logic.Services.Tags
{
    public interface ITagsService
    {
        Task CreateAsync(CreateTagDto tagDto);
        Task UpdateAsync(UpdateTagDto tagDto);
        Task DeleteAsync(Guid Id);
        Task<TagDto?> GetAsync(Guid Id);
        public Task<List<TagDto>> GetAllAsync();
    }
}
