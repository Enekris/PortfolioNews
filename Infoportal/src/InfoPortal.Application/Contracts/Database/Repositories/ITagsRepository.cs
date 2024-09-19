using InfoPortal.Domains.Entities;

namespace InfoPortal.Application.Contracts.Database.Repositories
{
    public interface ITagsRepository : IBaseRepository<TagDb>
    {
        public Task<List<TagDb>> GetAllAsync();
    }
}
