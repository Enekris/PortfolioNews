using InfoPortal.Domains.Entities;

namespace InfoPortal.Application.Contracts.Database.Repositories
{
    public interface INewsRepository : IBaseRepository<NewsDb>
    {
        public Task<List<NewsDb>> GetAllAsync();
    }
}
